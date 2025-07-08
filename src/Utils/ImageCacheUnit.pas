unit ImageCacheUnit;

{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, Graphics, Contnrs, SyncObjs, LoggerUnit, DateUtils;

type
  TCacheItem = class
    Key: string;
    Bitmap: TBitmap;
    LastAccessTime: TDateTime;
    Size: Integer;
  end;

  TImageCache = class
  private
    FCache: TObjectList;
    FMaxSize: Integer; // 最大キャッシュサイズ（バイト）
    FCurrentSize: Integer;
    FLock: TCriticalSection;
    FLogger: TLogger;
    
    function GenerateCacheKey(const FilePath: string; PageIndex: Integer; 
      Width, Height: Integer): string;
    function GetItemSize(Bitmap: TBitmap): Integer;
    procedure RemoveOldestItems(RequiredSize: Integer);
    procedure UpdateAccessTime(Item: TCacheItem);
    
  public
    constructor Create(AMaxSize: Integer = 100 * 1024 * 1024); // デフォルト100MB
    destructor Destroy; override;
    
    function Get(const FilePath: string; PageIndex: Integer; 
      Width, Height: Integer): TBitmap;
    procedure Put(const FilePath: string; PageIndex: Integer; 
      Width, Height: Integer; Bitmap: TBitmap);
    procedure Clear;
    procedure SetMaxSize(AMaxSize: Integer);
    
    property MaxSize: Integer read FMaxSize write SetMaxSize;
    property CurrentSize: Integer read FCurrentSize;
  end;

var
  ImageCache: TImageCache;

implementation

function CompareCacheItems(Item1, Item2: Pointer): Integer;
begin
  Result := CompareDateTime(
    TCacheItem(Item1).LastAccessTime,
    TCacheItem(Item2).LastAccessTime
  );
end;

{ TImageCache }

constructor TImageCache.Create(AMaxSize: Integer);
begin
  inherited Create;
  FCache := TObjectList.Create(True);
  FMaxSize := AMaxSize;
  FCurrentSize := 0;
  FLock := TCriticalSection.Create;
  FLogger := Logger;
end;

destructor TImageCache.Destroy;
begin
  FLock.Free;
  FCache.Free;
  inherited Destroy;
end;

function TImageCache.GenerateCacheKey(const FilePath: string; PageIndex: Integer; 
  Width, Height: Integer): string;
begin
  Result := Format('%s_%d_%dx%d', [FilePath, PageIndex, Width, Height]);
end;

function TImageCache.GetItemSize(Bitmap: TBitmap): Integer;
begin
  if Assigned(Bitmap) then
    Result := Bitmap.Width * Bitmap.Height * 4 // 32bit RGBA
  else
    Result := 0;
end;

procedure TImageCache.RemoveOldestItems(RequiredSize: Integer);
var
  i: Integer;
  Item: TCacheItem;
  ItemsToRemove: TList;
begin
  ItemsToRemove := TList.Create;
  try
    // アクセス時間でソートして古いアイテムを特定
    for i := 0 to FCache.Count - 1 do
    begin
      Item := TCacheItem(FCache[i]);
      ItemsToRemove.Add(Item);
    end;
    
    // アクセス時間でソート（古い順）
    ItemsToRemove.Sort(@CompareCacheItems);
    
    // 必要なサイズが確保されるまで古いアイテムを削除
    for i := 0 to ItemsToRemove.Count - 1 do
    begin
      Item := TCacheItem(ItemsToRemove[i]);
      FCurrentSize := FCurrentSize - Item.Size;
      FCache.Remove(Item);
      
      if FCurrentSize + RequiredSize <= FMaxSize then
        Break;
    end;
  finally
    ItemsToRemove.Free;
  end;
end;

procedure TImageCache.UpdateAccessTime(Item: TCacheItem);
begin
  if Assigned(Item) then
    Item.LastAccessTime := Now;
end;

function TImageCache.Get(const FilePath: string; PageIndex: Integer; 
  Width, Height: Integer): TBitmap;
var
  Key: string;
  i: Integer;
  Item: TCacheItem;
begin
  Result := nil;
  Key := GenerateCacheKey(FilePath, PageIndex, Width, Height);
  
  FLock.Enter;
  try
    for i := 0 to FCache.Count - 1 do
    begin
      Item := TCacheItem(FCache[i]);
      if Item.Key = Key then
      begin
        Result := Item.Bitmap;
                 UpdateAccessTime(Item);
         FLogger.Debug('キャッシュヒット: ' + Key);
         Exit;
       end;
     end;
     
     FLogger.Debug('キャッシュミス: ' + Key);
  finally
    FLock.Leave;
  end;
end;

procedure TImageCache.Put(const FilePath: string; PageIndex: Integer; 
  Width, Height: Integer; Bitmap: TBitmap);
var
  Key: string;
  Item: TCacheItem;
  ItemSize: Integer;
begin
  if not Assigned(Bitmap) then Exit;
  
  Key := GenerateCacheKey(FilePath, PageIndex, Width, Height);
  ItemSize := GetItemSize(Bitmap);
  
  FLock.Enter;
  try
    // キャッシュサイズが不足している場合は古いアイテムを削除
    if FCurrentSize + ItemSize > FMaxSize then
    begin
      RemoveOldestItems(ItemSize);
    end;
    
    // 新しいアイテムを追加
    Item := TCacheItem.Create;
    Item.Key := Key;
    Item.Bitmap := TBitmap.Create;
    Item.Bitmap.Assign(Bitmap);
    Item.LastAccessTime := Now;
    Item.Size := ItemSize;
    
    FCache.Add(Item);
    FCurrentSize := FCurrentSize + ItemSize;
    
         FLogger.Debug('キャッシュに追加: ' + Key + ' (サイズ: ' + IntToStr(ItemSize) + ' bytes)');
  finally
    FLock.Leave;
  end;
end;

procedure TImageCache.Clear;
begin
  FLock.Enter;
  try
    FCache.Clear;
    FCurrentSize := 0;
    FLogger.Info('画像キャッシュをクリアしました');
  finally
    FLock.Leave;
  end;
end;

procedure TImageCache.SetMaxSize(AMaxSize: Integer);
begin
  FLock.Enter;
  try
    FMaxSize := AMaxSize;
    if FCurrentSize > FMaxSize then
      RemoveOldestItems(0);
         FLogger.Info('キャッシュ最大サイズを ' + IntToStr(AMaxSize) + ' bytes に設定');
  finally
    FLock.Leave;
  end;
end;

initialization
  ImageCache := TImageCache.Create;

finalization
  if Assigned(ImageCache) then
    ImageCache.Free;

end. 
