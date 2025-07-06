unit AboutUnit;

{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, StdCtrls;

type

  { TAboutForm }

  TAboutForm = class(TForm)
    Memo1: TMemo;
    procedure FormCreate(Sender: TObject);
  private

  public

  end;

var
  AboutForm: TAboutForm;

implementation

{$R *.lfm}

{ TAboutForm }

procedure TAboutForm.FormCreate(Sender: TObject);
begin
  Memo1.Lines.Clear;
  Memo1.Lines.Add('ViewerBy2nd');
  Memo1.Lines.Add('');
  Memo1.Lines.Add('画像・PDF・動画ファイルを表示するビューアーアプリケーション');
  Memo1.Lines.Add('');
  Memo1.Lines.Add('対応ファイル形式:');
  Memo1.Lines.Add('・画像ファイル (JPG, PNG, BMP, GIF等)');
  Memo1.Lines.Add('・PDFファイル ');
  Memo1.Lines.Add('・動画ファイル (AVI, MP4, MOV等) VLCが必要');
  Memo1.Lines.Add('');
  Memo1.Lines.Add('主な機能:');
  Memo1.Lines.Add('・フルスクリーン表示');
  Memo1.Lines.Add('・複数モニター対応');
  Memo1.Lines.Add('・背景画像・背景色のカスタマイズ');
  Memo1.Lines.Add('・ズーム・回転機能');
  Memo1.Lines.Add('・ファイル一覧管理');
  Memo1.Lines.Add('');
  Memo1.Lines.Add('操作方法:');
  Memo1.Lines.Add('・右クリック: メニュー表示');
  Memo1.Lines.Add('・マウスホイール: ズーム');
  Memo1.Lines.Add('・ドラッグ&ドロップ: ファイル追加');
  Memo1.Lines.Add('');
  Memo1.Lines.Add('設定:');
  Memo1.Lines.Add('・設定メニューからスクリーン選択・背景設定が可能');
  Memo1.Lines.Add('・設定は自動保存されます');
  Memo1.Lines.Add('');
  Memo1.Lines.Add('注意:');
  Memo1.Lines.Add('・PDFファイルを表示するにはpdfium.dllが必要です');
  Memo1.Lines.Add('・pdfium.dllが見つからない場合、PDFファイルは開けません');
  Memo1.Lines.Add('・動画ファイルを再生するにはVLCメディアプレイヤーが必要です');
  Memo1.Lines.Add('・VLCがインストールされていない場合、動画ファイルは再生できません');
  Memo1.ReadOnly := True;
end;

end.

