unit AsyncImageGeneratorUnit;

{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, Graphics, LoggerUnit, ImageCacheUnit, DateUtils;

type
  TAsyncImageGenerator = class; // 前方宣言を追加

  TAsyncImageResult = record
    Success: Boolean;
    Bitmap: TBitmap;
    ErrorMessage: string;
  end;

  TAsyncImageCallback = procedure(const Result: TAsyncImageResult) of object;

  TAsyncImageTask = class
  private
    FFilePath: string;
    FPageIndex: Integer;
    FWidth: Integer;
    FHeight: Integer;
    FCallback: TAsyncImageCallback;
    FLogger: TLogger;
  public
    constructor Create(const AFilePath: string; APageIndex: Integer; 
      AWidth, AHeight: Integer; ACallback: TAsyncImageCallback);
    property FilePath: string read FFilePath;
    property PageIndex: Integer read FPageIndex;
    property Width: Integer read FWidth;
    property Height: Integer read FHeight;
    property Callback: TAsyncImageCallback read FCallback;
  end;

  TAsyncImageWorkerThread = class(TThread)
  private
    FGenerator: TAsyncImageGenerator;
    FTask: TAsyncImageTask;
    FResult: TAsyncImageResult;
    procedure DoCallback;
  protected
    procedure Execute; override;
  public
    constructor Create(AGenerator: TAsyncImageGenerator);
  end;

  TAsyncImageGenerator = class
  private
    FThread: TThread;
    FTaskQueue: TThreadList;
    FIsRunning: Boolean;
    FLogger: TLogger;
    
    procedure ExecuteTask(Task: TAsyncImageTask);
    function GenerateImage(const FilePath: string; PageIndex: Integer; 
      Width, Height: Integer): TAsyncImageResult;
  public
    constructor Create;
    destructor Destroy; override;
    
    procedure QueueTask(const FilePath: string; PageIndex: Integer; 
      Width, Height: Integer; Callback: TAsyncImageCallback);
    procedure Stop;
    
    property IsRunning: Boolean read FIsRunning;
  end;

var
  AsyncImageGenerator: TAsyncImageGenerator;

implementation

uses
  PdfImageCreator;

{ TAsyncImageTask }

constructor TAsyncImageTask.Create(const AFilePath: string; APageIndex: Integer; 
  AWidth, AHeight: Integer; ACallback: TAsyncImageCallback);
begin
  inherited Create;
  FFilePath := AFilePath;
  FPageIndex := APageIndex;
  FWidth := AWidth;
  FHeight := AHeight;
  FCallback := ACallback;
  FLogger := Logger;
end;

{ TAsyncImageWorkerThread }

constructor TAsyncImageWorkerThread.Create(AGenerator: TAsyncImageGenerator);
begin
  inherited Create(False);
  FreeOnTerminate := False;
  FGenerator := AGenerator;
end;

procedure TAsyncImageWorkerThread.Execute;
var
  List: TList;
  Task: TAsyncImageTask;
  Result: TAsyncImageResult;
begin
  while FGenerator.FIsRunning do
  begin
    List := FGenerator.FTaskQueue.LockList;
    try
      if List.Count > 0 then
      begin
        Task := TAsyncImageTask(List[0]);
        List.Delete(0);
      end
      else
        Task := nil;
    finally
      FGenerator.FTaskQueue.UnlockList;
    end;
    if Assigned(Task) then
    begin
      FGenerator.FLogger.Debug('非同期画像生成開始: ' + Task.FilePath);
      Result := FGenerator.GenerateImage(Task.FilePath, Task.PageIndex, Task.Width, Task.Height);
      // コールバック用にフィールドへ保存し、Synchronizeで呼び出す
      FTask := Task;
      FResult := Result;
      Synchronize(@DoCallback);
      Task.Free;
    end
    else
      Sleep(10); // 10ms待機
  end;
end;

procedure TAsyncImageWorkerThread.DoCallback;
begin
  if Assigned(FTask) and Assigned(FTask.Callback) then
    FTask.Callback(FResult);
end;

{ TAsyncImageGenerator }

constructor TAsyncImageGenerator.Create;
begin
  inherited Create;
  FTaskQueue := TThreadList.Create;
  FIsRunning := False;
  FLogger := Logger;
end;

destructor TAsyncImageGenerator.Destroy;
begin
  Stop;
  FTaskQueue.Free;
  inherited Destroy;
end;

procedure TAsyncImageGenerator.QueueTask(const FilePath: string; PageIndex: Integer; 
  Width, Height: Integer; Callback: TAsyncImageCallback);
var
  Task: TAsyncImageTask;
  List: TList;
  CachedBitmap: TBitmap;
  Result: TAsyncImageResult;
begin
  // まずキャッシュをチェック
  if Assigned(ImageCache) then
  begin
    CachedBitmap := ImageCache.Get(FilePath, PageIndex, Width, Height);
    if Assigned(CachedBitmap) then
    begin
             FLogger.Debug('キャッシュから画像を取得: ' + FilePath);
      if Assigned(Callback) then
      begin
        Result.Success := True;
        Result.Bitmap := CachedBitmap;
        Result.ErrorMessage := '';
        Callback(Result);
      end;
      Exit;
    end;
  end;
  
  Task := TAsyncImageTask.Create(FilePath, PageIndex, Width, Height, Callback);
  
  List := FTaskQueue.LockList;
  try
    List.Add(Task);
         FLogger.Debug('非同期タスクをキューに追加: ' + FilePath + ' (' + IntToStr(Width) + 'x' + IntToStr(Height) + ')');
  finally
    FTaskQueue.UnlockList;
  end;
  
  // スレッドが実行中でない場合は開始
  if not FIsRunning then
  begin
    FIsRunning := True;
    FThread := TAsyncImageWorkerThread.Create(Self);
  end;
end;

procedure TAsyncImageGenerator.ExecuteTask(Task: TAsyncImageTask);
var
  Result: TAsyncImageResult;
begin
  FLogger.Debug('画像生成タスク実行: ' + Task.FilePath);
  Result := GenerateImage(Task.FilePath, Task.PageIndex, Task.Width, Task.Height);
  
  if Result.Success and Assigned(ImageCache) then
  begin
    ImageCache.Put(Task.FilePath, Task.PageIndex, Task.Width, Task.Height, Result.Bitmap);
  end;
  
  if Assigned(Task.Callback) then
    Task.Callback(Result);
end;

function TAsyncImageGenerator.GenerateImage(const FilePath: string; PageIndex: Integer; 
  Width, Height: Integer): TAsyncImageResult;
var
  PdfImageCreator: TPdfImageCreator;
  Bitmap: TBitmap;
begin
  Result.Success := False;
  Result.Bitmap := nil;
  Result.ErrorMessage := '';
  
  try
    PdfImageCreator := TPdfImageCreator.Create(FilePath, PageIndex);
    try
      
      Bitmap := PdfImageCreator.GetBitmap(Width, Height);
      if Assigned(Bitmap) then
      begin
        Result.Success := True;
        Result.Bitmap := Bitmap;
        FLogger.Debug('非同期画像生成完了: ' + FilePath + ' (' + IntToStr(Width) + 'x' + IntToStr(Height) + ')');
      end
      else
      begin
        Result.ErrorMessage := '画像の生成に失敗しました';
        FLogger.Error('非同期画像生成失敗: ' + FilePath);
      end;
    finally
      PdfImageCreator.Free;
    end;
  except
    on E: Exception do
    begin
      Result.ErrorMessage := E.Message;
             FLogger.Error('非同期画像生成でエラー: ' + FilePath + ' - ' + E.Message);
    end;
  end;
end;

procedure TAsyncImageGenerator.Stop;
begin
  FIsRunning := False;
  if Assigned(FThread) then
  begin
    FThread.WaitFor;
    FThread.Free;
    FThread := nil;
  end;
end;

initialization
  AsyncImageGenerator := TAsyncImageGenerator.Create;

finalization
  if Assigned(AsyncImageGenerator) then
    AsyncImageGenerator.Free;

end. 
