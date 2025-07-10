unit TImageCreatorUnit;

{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, Graphics,ImageCreatorUnit, FPImage, FPReadJPEG, FPReadPNG, FPReadBMP, ReSizeBilinearUnit, ViewerBy2ndFileTypes, ImageCacheUnit, LoggerUnit;

type
  TImageCreator = class(TInterfacedObject, IDocmentImageCreator)
  private
    FBitmap: TBitmap;
    FFilePath: string;
    FUseCache: Boolean;
    procedure LoadFromFile(const AFileName: string);
  public
    constructor Create(const AFileName: string);
    destructor Destroy; override;
    function GetBitmap(Width, Height: Integer): TBitmap;
    function GetRatio(): Double;

    function GetPageIndex: Integer ;
    procedure SetPageIndex(AValue : Integer);
    function GetPageCount : Integer ;
    procedure SetUseCache(AValue: Boolean);
    function GetUseCache: Boolean;
    property UseCache: Boolean read FUseCache write SetUseCache;
  end;

implementation

constructor TImageCreator.Create(const AFileName : String);
begin
  inherited Create;
  FBitmap := TBitmap.Create;
  FFilePath := AFileName;
  FUseCache := True;  // デフォルトでキャッシュを有効
  LoadFromFile(AFileName);
end;

destructor TImageCreator.Destroy;
begin
  FBitmap.Free;
  inherited Destroy;
end;

function TImageCreator.GetBitmap(Width, Height: Integer): TBitmap;
var
  CachedBitmap: TBitmap;
begin
  if (FBitmap.Width = 0) or (FBitmap.Height = 0) then
    raise Exception.Create('No image loaded.');

  // キャッシュをチェック
  if FUseCache and Assigned(ImageCache) then
  begin
    CachedBitmap := ImageCache.Get(FFilePath, 0, Width, Height);
    if Assigned(CachedBitmap) then
    begin
      Logger.Debug('画像キャッシュから取得: ' + FFilePath);
      Result := CachedBitmap;
      Exit;
    end;
  end;

  // キャッシュにない場合は新しく生成
  Logger.Debug('画像を新規生成: ' + FFilePath);
  Result := ReSizeBilinear(FBitmap, Width, Height);

  // キャッシュに保存
  if FUseCache and Assigned(ImageCache) then
  begin
    ImageCache.Put(FFilePath, 0, Width, Height, Result);
    Logger.Debug('画像をキャッシュに保存: ' + FFilePath);
  end;
end;

function TImageCreator.GetRatio(): Double;
begin
  if (FBitmap.Width = 0) or (FBitmap.Height = 0) then
    raise Exception.Create('No image loaded.');
  Result := FBitmap.Width / FBitmap.Height;
end;

procedure TImageCreator.LoadFromFile(const AFileName: string);
var
  Image: TFPCustomImage;
  Reader: TFPCustomImageReader;
begin
  if not IsImageFile(AFileName) then
    raise Exception.Create('Not an image file');

  Image := TFPMemoryImage.Create(0, 0);
  try
    Reader := GetTFPReader(AFileName);
    try
      Image.LoadFromFile(AFileName, Reader);
      FBitmap.Assign(Image);
    finally
      Reader.Free;
    end;
  finally
    Image.Free;
  end;
end;

function TImageCreator.GetPageIndex: Integer ;
begin
  Result := 0;
end;

procedure TImageCreator.SetPageIndex(AValue : Integer);
begin
  //No opration
end;

function TImageCreator.GetPageCount : Integer ;
begin
  Result := 1;
end;

procedure TImageCreator.SetUseCache(AValue: Boolean);
begin
  FUseCache := AValue;
  Logger.Debug('画像キャッシュ設定: ' + BoolToStr(AValue, True));
end;

function TImageCreator.GetUseCache: Boolean;
begin
  Result := FUseCache;
end;

end.

