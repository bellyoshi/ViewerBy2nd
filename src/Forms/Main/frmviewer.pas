unit frmViewer;

{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, ExtCtrls, Menus,
   ViewerModel, FormSizeCustomizerUnit, IViewUnit, UFormController,
   ViewerBy2ndPlayer, LoggerUnit;

type

  { TViewerForm }

  TViewerForm = class(TForm, IView)
    ViewerImage: TImage;
    MenuItemOperation: TMenuItem;
    MenuItemTitleVisible: TMenuItem;
    MenuItemTitleInVisible: TMenuItem;
    MenuItemFullScreen: TMenuItem;
    MenuItemWindowMode: TMenuItem;
    MenuItemClose: TMenuItem;
    ViewerPanel: TPanel;
    PopupMenu1: TPopupMenu;
    Separator1: TMenuItem;
    Separator2: TMenuItem;

    procedure ControlEnabled();


    procedure FormCreate(Sender: TObject);
    procedure FormResize(Sender: TObject);

    procedure FormContextPopup(Sender: TObject; MousePos: TPoint; var Handled: Boolean);
    procedure MenuItemOperationClick(Sender: TObject);
    procedure MenuItemTitleInVisibleClick(Sender: TObject);

    procedure MenuItemCloseClick(Sender: TObject);
    procedure MenuItemFullScreenClick(Sender: TObject);
    procedure MenuItemTitleVisibleClick(Sender: TObject);
    procedure MenuItemWindowModeClick(Sender: TObject);

  private
    FIsFullScreen: Boolean;
    procedure SetIsFullScreen(Value: Boolean);
    procedure LoadBitmap();
  public
    property IsFullScreen: Boolean read FIsFullScreen write SetIsFullScreen;
    procedure ShowDocument;
    procedure ShowBackgroundOnly;
    procedure UpdateView();
  end;

var
  ViewerForm: TViewerForm;

implementation

{$R *.lfm}

procedure TViewerForm.ControlEnabled();
begin
  MenuItemTitleInVisible.Enabled:=FormSizeCustomizer.CanTitleInVisible;
  MenuItemTitleVisible.Enabled:= FormSizeCustomizer.CanTitleVisible;
  MenuItemFullScreen.Enabled:=Not FormSizeCustomizer.IsFullScreen;
  MenuItemWindowMode.Enabled := FormSizeCustomizer.IsFullScreen;
end;



procedure TViewerForm.FormCreate(Sender: TObject);
begin
  FormSizeCustomizer := TFormSizeCustomizer.Create;
  FormSizeCustomizer.RegistForm(ViewerForm);
  ViewerImage.Visible := True;
  
  if Assigned(player) then
  begin
    player.RegisterViewer(Self, ViewerPanel);
  end;
end;




procedure TViewerForm.LoadBitmap();
var
  Bitmap: TBitmap;
begin
  Logger.BeginSection('ビューアーフォーム画像読み込み');
  Logger.Info(Format('要求サイズ: %dx%d', [ClientWidth, ClientHeight]));
  Logger.StartTimer('ビューアーフォーム画像読み込み');

  try
    // ViewerPanelのサイズ変更
    Logger.Debug('1. パネルサイズ調整開始');
    ViewerPanel.Width := ClientWidth;
    ViewerPanel.Height := ClientHeight;
    ViewerPanel.Left := 0;
    ViewerPanel.Top := 0;
    Logger.Debug('2. パネルサイズ調整完了');

    // PDFium ページを Delphi ビットマップに描画
    Logger.Debug('3. GetViewBitmap呼び出し開始 (最も時間がかかる可能性)');
    Bitmap := model.GetViewBitmap(ClientWidth, ClientHeight);
    Logger.Debug('4. GetViewBitmap呼び出し完了');

    Logger.Debug('5. 画像表示設定開始');
    ViewerImage.Width := Bitmap.Width;
    ViewerImage.Height := Bitmap.Height;
    ViewerImage.Left := (ClientWidth - Bitmap.Width) div 2;
    ViewerImage.Top := (ClientHeight - Bitmap.Height) div 2;

    ViewerImage.Picture.Bitmap.Assign(Bitmap);
    Logger.Debug('6. 画像表示設定完了');
  finally
    Bitmap.Free;
    Logger.Debug('7. ビットマップ解放完了');
  end;

  Logger.EndTimer('ビューアーフォーム画像読み込み');
  Logger.EndSection('ビューアーフォーム画像読み込み');
end;

procedure TViewerForm.FormResize(Sender: TObject);
begin
  //LoadBitmap();
  formManager.Update;
end;

procedure TViewerForm.SetIsFullScreen(Value: Boolean);
begin
  FormSizeCustomizer.IsFullScreen := Value;
end;

procedure TViewerForm.FormContextPopup(Sender: TObject; MousePos: TPoint; var Handled: Boolean);
begin
  PopupMenu1.PopUp(MousePos.X, MousePos.Y);
  Handled := True;  // イベントを処理済みにする
end;

procedure TViewerForm.MenuItemOperationClick(Sender: TObject);
begin
  FormController.ShowForm();
end;

procedure TViewerForm.MenuItemTitleInVisibleClick(Sender: TObject);
begin
  FormSizeCustomizer.TitleVisible := False;
  ControlEnabled();
end;

procedure TViewerForm.MenuItemFullScreenClick(Sender: TObject);
begin
  IsFullScreen := True;  // フルスクリーンに切り替える
    ControlEnabled();
end;

procedure TViewerForm.MenuItemTitleVisibleClick(Sender: TObject);
begin
  FormSizeCustomizer.TitleVisible := True;
    ControlEnabled();
end;

procedure TViewerForm.MenuItemWindowModeClick(Sender: TObject);
begin
  IsFullScreen := False;  // ウインドウモードに切り替える
    ControlEnabled();
end;



procedure TViewerForm.MenuItemCloseClick(Sender: TObject);
begin
  Close;  // フォームを閉じる
end;

procedure TViewerForm.ShowDocument;
begin
  model.View();
  UpdateView();
  if not Visible then
  begin
    Show();
  end;
end;

procedure TViewerForm.ShowBackgroundOnly;
begin
  // 背景表示のみを行う（model.View()は呼び出さない）
  UpdateView();
  if not Visible then
  begin
    Show();
  end;
end;

procedure TViewerForm.UpdateView();
begin
  if not Assigned(model) Then Exit;
  ControlEnabled();
  ViewerImage.Visible := True;
  LoadBitmap();
  Self.Color := model.Background.Color;
end;

end.

