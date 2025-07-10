unit ImageCreatorUnit;

{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, Graphics;


type
  IImageCreator = interface

    function GetBitmap(Width, Height: Integer): TBitmap; // ビットマップ取得ー
    function GetRatio(): Double;


  end;

  IDocmentImageCreator = interface(IImageCreator)
        function GetPageIndex: Integer ;
    procedure SetPageIndex(AValue : Integer);
    function GetPageCount : Integer ;
    function GetUseCache: Boolean;
    procedure SetUseCache(AValue: Boolean);
    property UseCache: Boolean read GetUseCache write SetUseCache;
  end;

implementation

end.

