unit LoggerUnit;

{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, DateUtils, TypInfo, SyncObjs;

type
  TLogLevel = (llDebug, llInfo, llWarning, llError);

  TLogger = class
  private
    FLogLevel: TLogLevel;
    FLogFile: string;
    FLogToFile: Boolean;
    FIndentLevel: Integer;
    FIndentString: string;
    FLogStream: TFileStream;
    FCriticalSection: TCriticalSection;
    FLogBuffer: TStringList;
    FBufferSize: Integer;
    FMaxBufferSize: Integer;
    
    procedure WriteLog(const AMessage: string; ALevel: TLogLevel);
    function GetIndentString: string;
    procedure FlushBuffer;
    procedure OpenLogFile;
    procedure CloseLogFile;
  public
    constructor Create;
    destructor Destroy; override;
    
    // 基本ログ機能
    procedure Debug(const AMessage: string);
    procedure Info(const AMessage: string);
    procedure Warning(const AMessage: string);
    procedure Error(const AMessage: string);
    
    // 時間計測機能
    procedure StartTimer(const ATimerName: string);
    procedure EndTimer(const ATimerName: string);
    procedure LogTimer(const ATimerName: string; AElapsedMs: Integer);
    
    // セクション機能
    procedure BeginSection(const ASectionName: string);
    procedure EndSection(const ASectionName: string);
    
    // 設定
    procedure SetLogLevel(ALevel: TLogLevel);
    procedure SetLogFile(const AFileName: string);
    procedure SetLogToFile(AEnabled: Boolean);
    
    property LogLevel: TLogLevel read FLogLevel write SetLogLevel;
    property LogFile: string read FLogFile write SetLogFile;
    property LogToFile: Boolean read FLogToFile write SetLogToFile;
  end;

var
  Logger: TLogger;

implementation

uses
  Forms;

type
  TTimerInfo = record
    StartTime: TDateTime;
    Name: string;
  end;

var
  FTimers: array of TTimerInfo;

constructor TLogger.Create;
begin
  inherited Create;
  FLogLevel := llInfo;
  FLogToFile := True;
  FIndentLevel := 0;
  FIndentString := '';
  FLogStream := nil;
  FCriticalSection := TCriticalSection.Create;
  FLogBuffer := TStringList.Create;
  FBufferSize := 0;
  FMaxBufferSize := 8192; // 8KB
  SetLength(FTimers, 0);
end;

destructor TLogger.Destroy;
begin
  FlushBuffer;
  CloseLogFile;
  if Assigned(FCriticalSection) then
    FCriticalSection.Free;
  if Assigned(FLogBuffer) then
    FLogBuffer.Free;
  inherited Destroy;
end;

procedure TLogger.OpenLogFile;
begin
  if (FLogFile = '') or (FLogStream <> nil) then
    Exit;
    
  try
    if FileExists(FLogFile) then
      FLogStream := TFileStream.Create(FLogFile, fmOpenReadWrite or fmShareDenyNone)
    else
      FLogStream := TFileStream.Create(FLogFile, fmCreate or fmShareDenyNone);
    FLogStream.Seek(0, soEnd);
  except
    FLogStream := nil;
  end;
end;

procedure TLogger.CloseLogFile;
begin
  if Assigned(FLogStream) then
  begin
    try
      FlushBuffer;
      FLogStream.Free;
    except
      // ファイルハンドルエラーは無視
    end;
    FLogStream := nil;
  end;
end;

procedure TLogger.FlushBuffer;
var
  i: Integer;
  BufferText: string;
begin
  if (not Assigned(FLogBuffer)) or (FLogBuffer.Count = 0) or (FLogStream = nil) then
    Exit;
    
  try
    BufferText := FLogBuffer.Text;
    FLogStream.WriteBuffer(PChar(BufferText)^, Length(BufferText));
    // FPCではTFileStreamにFlushメソッドがないため削除
    FLogBuffer.Clear;
    FBufferSize := 0;
  except
    // ファイル書き込みエラーは無視
  end;
end;

procedure TLogger.WriteLog(const AMessage: string; ALevel: TLogLevel);
var
  LogMessage: string;
begin

  if ALevel < FLogLevel then
    Exit;
    
  LogMessage := Format('[%s] [%s] %s%s' + LineEnding, [
    FormatDateTime('yyyy-mm-dd hh:nn:ss.zzz', Now),
    Copy(GetEnumName(TypeInfo(TLogLevel), Ord(ALevel)), 3, MaxInt),
    GetIndentString,
    AMessage
  ]);
    
  // Windowsアプリケーションではコンソール出力は使用しない
  // ファイル出力のみ
    
  // ファイル出力
  if FLogToFile and (FLogFile <> '') then
  begin
    FCriticalSection.Enter;
    try
      if FLogStream = nil then
        OpenLogFile;
        
      if FLogStream <> nil then
      begin
        // バッファに追加
        FLogBuffer.Add(Copy(LogMessage, 1, Length(LogMessage) - Length(LineEnding)));
        FBufferSize := FBufferSize + Length(LogMessage);
        
        // バッファサイズが上限に達したらフラッシュ
        if FBufferSize >= FMaxBufferSize then
          FlushBuffer;
      end;
    finally
      FCriticalSection.Leave;
    end;
  end;
end;

function TLogger.GetIndentString: string;
begin
  Result := StringOfChar(' ', FIndentLevel * 2);
end;

procedure TLogger.Debug(const AMessage: string);
begin
  WriteLog(AMessage, llDebug);
end;

procedure TLogger.Info(const AMessage: string);
begin
  WriteLog(AMessage, llInfo);
end;

procedure TLogger.Warning(const AMessage: string);
begin
  WriteLog(AMessage, llWarning);
end;

procedure TLogger.Error(const AMessage: string);
begin
  WriteLog(AMessage, llError);
end;

procedure TLogger.StartTimer(const ATimerName: string);
var
  i: Integer;
  TimerInfo: TTimerInfo;
begin
  // 既存のタイマーを検索
  for i := 0 to High(FTimers) do
  begin
    if FTimers[i].Name = ATimerName then
    begin
      FTimers[i].StartTime := Now;
      Debug(Format('タイマー再開: %s', [ATimerName]));
      Exit;
    end;
  end;
  
  // 新しいタイマーを追加
  TimerInfo.Name := ATimerName;
  TimerInfo.StartTime := Now;
  SetLength(FTimers, Length(FTimers) + 1);
  FTimers[High(FTimers)] := TimerInfo;
  Debug(Format('タイマー開始: %s', [ATimerName]));
end;

procedure TLogger.EndTimer(const ATimerName: string);
var
  i: Integer;
  ElapsedMs: Integer;
begin
  for i := 0 to High(FTimers) do
  begin
    if FTimers[i].Name = ATimerName then
    begin
      ElapsedMs := MilliSecondsBetween(Now, FTimers[i].StartTime);
      LogTimer(ATimerName, ElapsedMs);
      
      // タイマーを削除
      if i < High(FTimers) then
        FTimers[i] := FTimers[High(FTimers)];
      SetLength(FTimers, Length(FTimers) - 1);
      Exit;
    end;
  end;
  
  Warning(Format('タイマーが見つかりません: %s', [ATimerName]));
end;

procedure TLogger.LogTimer(const ATimerName: string; AElapsedMs: Integer);
begin
  Info(Format('タイマー完了: %s - %d ミリ秒', [ATimerName, AElapsedMs]));
end;

procedure TLogger.BeginSection(const ASectionName: string);
begin
  Info(Format('=== %s 開始 ===', [ASectionName]));
  Inc(FIndentLevel);
end;

procedure TLogger.EndSection(const ASectionName: string);
begin
  Dec(FIndentLevel);
  Info(Format('=== %s 完了 ===', [ASectionName]));
end;

procedure TLogger.SetLogLevel(ALevel: TLogLevel);
begin
  FLogLevel := ALevel;
end;

procedure TLogger.SetLogFile(const AFileName: string);
begin
  FCriticalSection.Enter;
  try
    if FLogFile <> AFileName then
    begin
      FlushBuffer;
      CloseLogFile;
      FLogFile := AFileName;
      if FLogToFile and (FLogFile <> '') then
        OpenLogFile;
    end;
  finally
    FCriticalSection.Leave;
  end;
end;

procedure TLogger.SetLogToFile(AEnabled: Boolean);
begin
  FCriticalSection.Enter;
  try
    if FLogToFile <> AEnabled then
    begin
      FlushBuffer;
      if AEnabled then
      begin
        FLogToFile := True;
        if FLogFile <> '' then
          OpenLogFile;
      end
      else
      begin
        FLogToFile := False;
        CloseLogFile;
      end;
    end;
  finally
    FCriticalSection.Leave;
  end;
end;



initialization
  Logger := TLogger.Create;

finalization
  if Assigned(Logger) then
  begin
    Logger.Free;
    Logger := nil;
  end;

end. 
