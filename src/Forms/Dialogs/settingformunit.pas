unit SettingFormUnit;

{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, StdCtrls, ExtCtrls,
  ExtDlgs, FormSizeCustomizerUnit, IViewUnit, ViewerModel;

type

  { TSettingForm }

  TSettingForm = class(TForm)
    Button1: TButton;
    ColorDialog1: TColorDialog;
    OpenPictureDialog1: TOpenPictureDialog;
    ViewerBackGroundImage: TImage;
    UseBackgroundImage: TRadioButton;
    OkButton: TButton;
    ComboBox1: TComboBox;
    IsSimpleBackGroundColor: TRadioButton;
    ViewerBackgroundColor: TPanel;
    procedure Button1Click(Sender: TObject);
    procedure ComboBox1Change(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure UseBackgroundImageChange(Sender: TObject);
    procedure OkButtonClick(Sender: TObject);
    procedure ViewerBackgroundColorClick(Sender: TObject);
    procedure ViewerBackGroundImageClick(Sender: TObject);
    procedure IsSimpleBackGroundColorClick(Sender: TObject);
    procedure IsBackgroundImageClick(Sender: TObject);
  private

  public

  end;

var
  SettingForm: TSettingForm;

implementation

{$R *.lfm}

{ TSettingForm }
procedure PopulateScreenList(ComboBox: TComboBox);
var
  i: Integer;
begin
  ComboBox.Items.Clear;
  for i := 0 to Screen.MonitorCount - 1 do
  begin
    ComboBox.Items.Add('Screen ' + IntToStr(i + 1) + ' (' +
      IntToStr(Screen.Monitors[i].Width) + 'x' +
      IntToStr(Screen.Monitors[i].Height) + ')');
  end;
  
  //ComboBoxのインデックスを設定スクリーンが存在する場合
  if FormSizeCustomizer.ScreenIndex < ComboBox.Items.Count then
  begin
    ComboBox.ItemIndex := FormSizeCustomizer.ScreenIndex;
  end
  else
  begin
    ComboBox.ItemIndex := 0;
  end;
end;

procedure TSettingForm.FormCreate(Sender: TObject);
begin


end;

procedure TSettingForm.FormShow(Sender: TObject);
begin
    PopulateScreenList(ComboBox1);
    ViewerBackgroundColor.Color:=model.Background.Color;
    
    // ラジオボタンの状態を背景の設定と同期
    IsSimpleBackGroundColor.Checked := model.Background.IsSimpleColor;
    UseBackgroundImage.Checked := model.Background.UseImage;
    
    // 背景画像が設定されている場合は表示
    if model.Background.UseImage and (model.Background.ImagePath <> '') and FileExists(model.Background.ImagePath) then
    begin
      try
        ViewerBackGroundImage.Picture.LoadFromFile(model.Background.ImagePath);
      except
        // 画像の読み込みに失敗した場合は何もしない
      end;
    end;
end;

procedure TSettingForm.UseBackgroundImageChange(Sender: TObject);
begin
  model.Background.UseImage:=UseBackgroundImage.Checked;
end;

procedure TSettingForm.ComboBox1Change(Sender: TObject);
var
  i : Integer;
begin
  i := ComboBox1.ItemIndex;
  FormSizeCustomizer.ScreenIndex:=i;
  FormSizeCustomizer.IsFullScreen := True;
end;

procedure TSettingForm.Button1Click(Sender: TObject);
begin
    ViewerBackgroundColorClick(sender);
end;

procedure TSettingForm.OkButtonClick(Sender: TObject);
begin
  Close();
end;

procedure TSettingForm.ViewerBackgroundColorClick(Sender: TObject);
begin
  if not ColorDialog1.Execute then
  begin
    exit;
  end;
  model.Background.Color := ColorDialog1.Color;
  ViewerBackgroundColor.Color:=model.Background.Color;
  formManager.Update;
end;

procedure TSettingForm.ViewerBackGroundImageClick(Sender: TObject);
begin
  if not OpenPictureDialog1.Execute then
  begin
    exit;
  end;
  
  // 背景画像モードを有効にする
  UseBackgroundImage.Checked := True;
  
  // 選択された画像ファイルを背景画像として設定
  model.Background.ImagePath := OpenPictureDialog1.FileName;
  
  // 画像を表示用のImageコントロールに読み込み
  try
    ViewerBackGroundImage.Picture.LoadFromFile(OpenPictureDialog1.FileName);
    formManager.Update;
  except
    on E: Exception do
    begin
      ShowMessage('画像ファイルの読み込みに失敗しました: ' + E.Message);
    end;
  end;
end;

procedure TSettingForm.IsSimpleBackGroundColorClick(Sender: TObject);
begin
  model.Background.IsSimpleColor := True;
  formManager.Update;
end;

procedure TSettingForm.IsBackgroundImageClick(Sender: TObject);
begin
  UseBackgroundImage.Checked := True;
  formManager.Update;
end;

end.

