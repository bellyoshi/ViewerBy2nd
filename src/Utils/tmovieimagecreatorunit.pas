unit TMovieImageCreatorUnit;

{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, Graphics, ImageCreatorUnit, ImageCacheUnit, LoggerUnit;

type
  TMovieImageCreator = class(TInterfacedObject, IDocmentImageCreator)
  private
    FFileName: string;
    FUseCache: Boolean;
  public
    constructor Create(const AFileName: string);
    destructor Destroy; override;
    
    // IImageCreator interface
    function GetBitmap(Width, Height: Integer): TBitmap;
    function GetRatio(): Double;
    
    // IDocmentImageCreator interface
    function GetPageIndex: Integer;
    procedure SetPageIndex(AValue: Integer);
    function GetPageCount: Integer;
    function GetUseCache: Boolean;
    procedure SetUseCache(AValue: Boolean);
    
    property UseCache: Boolean read GetUseCache write SetUseCache;
  end;

implementation

constructor TMovieImageCreator.Create(const AFileName: string);
begin
  inherited Create;
  FFileName := AFileName;
  FUseCache := True;  // デフォルトでキャッシュを有効
end;

destructor TMovieImageCreator.Destroy;
begin
  inherited Destroy;
end;

function TMovieImageCreator.GetBitmap(Width, Height: Integer): TBitmap;
var
  CachedBitmap: TBitmap;
begin
  // キャッシュをチェック
  if FUseCache and Assigned(ImageCache) then
  begin
    CachedBitmap := ImageCache.Get(FFileName, 0, Width, Height);
    if Assigned(CachedBitmap) then
    begin
      Logger.Debug('動画キャッシュから取得: ' + FFileName);
      Result := CachedBitmap;
      Exit;
    end;
  end;

  // キャッシュにない場合は新しく生成
  Logger.Debug('動画画像を新規生成: ' + FFileName);
  Result := TBitmap.Create;
  try
    Result.Width := Width;
    Result.Height := Height;
    Result.Canvas.Brush.Color := clBlack;
    Result.Canvas.FillRect(Rect(0, 0, Width, Height));
  except
    Result.Free;
    raise;
  end;

  // キャッシュに保存
  if FUseCache and Assigned(ImageCache) then
  begin
    ImageCache.Put(FFileName, 0, Width, Height, Result);
    Logger.Debug('動画画像をキャッシュに保存: ' + FFileName);
  end;
end;

function TMovieImageCreator.GetRatio(): Double;
begin
  Result := 16.0 / 9.0; // 一般的な動画のアスペクト比
end;

function TMovieImageCreator.GetPageIndex: Integer;
begin
  Result := 0;
end;

procedure TMovieImageCreator.SetPageIndex(AValue: Integer);
begin
  // 動画はページの概念がないため、何もしない
end;

function TMovieImageCreator.GetPageCount: Integer;
begin
  Result := 1; // 動画は1つのストリームとして扱う
end;

function TMovieImageCreator.GetUseCache: Boolean;
begin
  Result := FUseCache;
end;

procedure TMovieImageCreator.SetUseCache(AValue: Boolean);
begin
  FUseCache := AValue;
  Logger.Debug('動画キャッシュ設定: ' + BoolToStr(AValue, True));
end;

end. 