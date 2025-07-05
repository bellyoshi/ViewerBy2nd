// File: Background.pas
unit Background;

{$mode ObjFPC}{$H+}

interface

uses
  Graphics, Classes, SysUtils, ExtCtrls;

type
  TBackground = class
  private
    FColor: TColor;
    FImagePath: string;
    FUseImage: Boolean;
    function GetIsSimpleColor: Boolean;
    procedure SetIsSimpleColor(Value: Boolean);
  public
    constructor Create(AColor: TColor = clBlack);
    function GetBitmap(Width, Height: Integer): TBitmap;
    property Color: TColor read FColor write FColor;
    property ImagePath: string read FImagePath write FImagePath;
    property UseImage: Boolean read FUseImage write FUseImage;
    property IsImage: Boolean read FUseImage write FUseImage;
    property IsSimpleColor: Boolean read GetIsSimpleColor write SetIsSimpleColor;


  end;

implementation

{TBackground}
constructor TBackground.Create(AColor: TColor = clBlack);
begin
  inherited Create;
  FColor := AColor;
  FImagePath := '';
  FUseImage := False;
end;

function TBackground.GetBitmap(Width, Height: Integer): TBitmap;
var
  BackgroundImage: TImage;
begin
  Result := TBitmap.Create;
  try
    Result.Width := Width;
    Result.Height := Height;
    
    if FUseImage and (FImagePath <> '') and FileExists(FImagePath) then
    begin
      // 背景画像を使用
      BackgroundImage := TImage.Create(nil);
      try
        BackgroundImage.Picture.LoadFromFile(FImagePath);
        Result.Canvas.StretchDraw(Rect(0, 0, Width, Height), BackgroundImage.Picture.Graphic);
      finally
        BackgroundImage.Free;
      end;
    end
    else
    begin
      // 背景色を使用
      Result.Canvas.Brush.Color := FColor;
      Result.Canvas.FillRect(Rect(0, 0, Width, Height));
    end;
  except
    Result.Free;
    raise;
  end;
end;

function TBackground.GetIsSimpleColor: Boolean;
begin
  Result := not FUseImage;
end;

procedure TBackground.SetIsSimpleColor(Value: Boolean);
begin
  FUseImage := not Value;
end;

end.
