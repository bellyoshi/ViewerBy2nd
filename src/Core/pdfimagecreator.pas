unit PdfImageCreator;

{$mode ObjFPC}{$H+}

interface
uses
  Classes, SysUtils, PdfiumCore, Graphics, ImageCreatorUnit, LoggerUnit;

procedure DrawToBitmap(Page: TPdfPage; Bitmap: TBitmap; w,h : Integer);

type


  TPdfImageCreator  = class(TInterfacedObject, IDocmentImageCreator)

  private
    FPdfDocument: TPdfDocument;
    FPageIndex: Integer;

  public
    constructor Create(const Filename: string; PageIndex: Integer = 0);  // コンストラクタ
    destructor Destroy; override;  // デストラクタ
    function GetBitmap(Width, Height: Integer): TBitmap;  // ビットマップ取得
    function GetRatio(): Double;
    procedure SetPageIndex(AValue : Integer);
    function GetPageIndex() : Integer;
    function GetPageCount : Integer ;
    property PageCount : Integer read GetPageCount;
  end;




implementation

uses
  GraphType;
procedure TPdfImageCreator.SetPageIndex(AValue : Integer);
begin
   FPageIndex := AValue;
end;

function TPdfImageCreator.GetPageIndex : Integer ;
begin
   Result := FPageIndex;
end;

function TPdfImageCreator.GetPageCount : Integer;
begin
  Result := FPdfDocument.PageCount;
end;

function TPdfImageCreator.GetRatio() : Double;
var
  Page : TPdfPage;
begin
  Page := FPdfDocument.Pages[FPageIndex];
  Result := Page.Width / Page.Height;     // 画像のアスペクト比を計算
end;
procedure DrawToBitmap(Page: TPdfPage; Bitmap: TBitmap; w,h : Integer);
var
  SizeInt: Integer;
  PdfBitmap: TPdfBitmap;
  AIMarge: TBytes;
  buffer: Pointer;
  RawImage: TRawImage;
begin
  Logger.BeginSection('PDF画像変換');
  Logger.Info(Format('変換サイズ: %dx%d ピクセル', [w, h]));
  Logger.StartTimer('PDF画像変換');

  // PDFium ビットマップを作成
  Logger.Debug('1. PDFiumビットマップ作成開始');
  PdfBitmap := TPdfBitmap.Create(w, h, bfBGRA);
  try
    Logger.Debug('2. 背景色設定開始');
    PdfBitmap.FillRect(0, 0, w, h, $FFFFFFFF); // 背景を白色で塗りつぶし
    
    Logger.Debug('3. PDFページ描画開始 (最も時間がかかる可能性)');
    Page.DrawToPdfBitmap(PdfBitmap, 0, 0, w, h);
    Logger.Debug('4. PDFページ描画完了');

    // PDFium ビットマップのバッファサイズを計算
    SizeInt := w * h * 4; // 4バイト/ピクセル (RGBA)
    Logger.Debug(Format('5. バッファサイズ計算: %d バイト', [SizeInt]));

    // バイト配列を初期化
    Logger.Debug('6. バイト配列初期化開始');
    SetLength(AIMarge, SizeInt);
    Logger.Debug('7. バイト配列初期化完了');

    // PDFium のバッファを取得して、バイト配列にコピー
    Logger.Debug('8. バッファコピー開始');
    buffer := PdfBitmap.GetBuffer;
    Move(buffer^, AIMarge[0], SizeInt);
    Logger.Debug('9. バッファコピー完了');

    // バイト配列から Delphi のビットマップにデータをコピー
    Logger.Debug('10. RawImage作成開始');
    RawImage.Init;
    RawImage.Description.Init_BPP32_B8G8R8A8_M1_BIO_TTB(w, h);
    RawImage.CreateData(true);
    RawImage.Data:=@AIMarge[0];
    Logger.Debug('11. RawImage作成完了');

    Logger.Debug('12. ビットマップ読み込み開始');
    Bitmap.LoadFromRawImage(RawImage, false);
    Logger.Debug('13. ビットマップ読み込み完了');
  finally
    PdfBitmap.Free;
    Logger.Debug('14. PDFiumビットマップ解放完了');
  end;

  Logger.EndTimer('PDF画像変換');
  Logger.EndSection('PDF画像変換');
end;
{ TPdfImageCreator }

constructor TPdfImageCreator.Create(const Filename: string; PageIndex: Integer = 0);
begin
  inherited Create;
  Logger.BeginSection('PDFドキュメント初期化');
  Logger.StartTimer('PDFドキュメント初期化');

  {initialize}
    {$IFDEF CPUX64}
  //PDFiumDllDir := ExtractFilePath(ParamStr(0)) + 'x64\V8XFA';
  PDFiumDllDir := ExtractFilePath(ParamStr(0)) + 'x64';
  {$ELSE}
  PDFiumDllDir := ExtractFilePath(ParamStr(0)) + 'x86';
  {$ENDIF CPUX64}
  {initialize end}

  Logger.Debug(Format('1. PDFiumDllDir設定: %s', [PDFiumDllDir]));

  // PDF ドキュメントをロード
  Logger.Debug('2. TPdfDocument作成開始');
  FPdfDocument := TPdfDocument.Create;
  Logger.Debug('3. TPdfDocument作成完了');

  if not FileExists(Filename) then
    raise Exception.Create('File not found: ' + Filename);

  Logger.Debug(Format('4. PDFファイル読み込み開始: %s', [Filename]));
  FPdfDocument.LoadFromFile(Filename);
  Logger.Debug('5. PDFファイル読み込み完了');

  // デフォルトでは、最初のページ (0) を表示
  FPageIndex := PageIndex;
  Logger.Debug(Format('6. ページインデックス設定: %d', [FPageIndex]));

  if (FPageIndex < 0) or (FPageIndex >= FPdfDocument.PageCount) then
    raise Exception.Create('Invalid page index');

  Logger.EndTimer('PDFドキュメント初期化');
  Logger.Info(Format('総ページ数: %d', [FPdfDocument.PageCount]));
  Logger.EndSection('PDFドキュメント初期化');
end;

destructor TPdfImageCreator.Destroy;
begin
  Logger.BeginSection('PDFドキュメント解放');
  FPdfDocument.Free();
  Logger.EndSection('PDFドキュメント解放');
  inherited;
end;

function TPdfImageCreator.GetBitmap(Width, Height: Integer): TBitmap;
var
  PdfPage: TPdfPage;
  Bitmap: TBitmap;
begin
  Logger.BeginSection('GetBitmap');
  Logger.Info(Format('要求サイズ: %dx%d', [Width, Height]));
  Logger.StartTimer('GetBitmap');

  if not Assigned(FPdfDocument) then
    raise Exception.Create('PDF document not loaded');

  Logger.Debug('1. PDFページ取得開始');
  PdfPage := FPdfDocument.Pages[FPageIndex];  // 指定されたページを取得
  Logger.Debug('2. PDFページ取得完了');

  // ビットマップの作成
  Logger.Debug('3. TBitmap作成開始');
  Bitmap := TBitmap.Create;
  Bitmap.Width := Width;
  Bitmap.Height := Height;
  Logger.Debug('4. TBitmap作成完了');

  Logger.Debug('5. DrawToBitmap呼び出し開始');
  DrawToBitmap(PdfPage, Bitmap, Width, Height);
  Logger.Debug('6. DrawToBitmap呼び出し完了');

  Logger.EndTimer('GetBitmap');
  Logger.EndSection('GetBitmap');

  Result := Bitmap;
end;


end.

