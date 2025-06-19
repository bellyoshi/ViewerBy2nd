// File: FilesParam.pas
unit FilesParam;

{$mode ObjFPC}{$H+}

interface

uses
  Graphics, SysUtils, PdfImageCreator, RotateImageCreatorUnit, ZoomUnit, 
  ImageCreatorUnit, TImageCreatorUnit, ViewerBy2ndFileTypes, TMovieImageCreatorUnit;

type
  TFilesParam = class
    Filename: string;
    Selected: Boolean;
    ImageCreator: IDocmentImageCreator;
    RotateImageCreator: TRotateImageCreator;
    Zoom: TZoom;
  public
    constructor Create(AFileName: string; ASelected: Boolean);
  end;

implementation

{TFilesParam}

constructor TFilesParam.Create(AFileName : string; ASelected : Boolean);
begin
  inherited Create;
  if IsMovie(AFileName) then
  begin
    ImageCreator := TMovieImageCreator.Create(AFileName);
  end else if IsImageFile(AFileName) then
  begin
    ImageCreator := TImageCreator.Create(AFileName);
  end else if IsPDFFile(AFileName) then
  begin
    ImageCreator := TPdfImageCreator.Create(AFileName);
  end
  else
  begin
    // ファイルタイプが認識されない場合は例外を発生させる
    raise Exception.CreateFmt('Unsupported file type: %s', [AFileName]);
  end;
  
  // ImageCreatorが正常に作成された場合のみ、RotateImageCreatorとZoomを作成
  if Assigned(ImageCreator) then
  begin
    RotateImageCreator := TRotateImageCreator.Create(ImageCreator);
    Zoom := TZoom.Create(RotateImageCreator);
  end
  else
  begin
    // 万が一ImageCreatorがnilの場合は例外を発生させる
    raise Exception.CreateFmt('Failed to create image creator for: %s', [AFileName]);
  end;
  
  Filename := AFileName;
  Selected := ASelected;
end;

end.
