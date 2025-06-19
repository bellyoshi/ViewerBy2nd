unit frmViewer;

{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, ExtCtrls, Menus,
   ViewerModel, FormSizeCustomizerUnit, IViewUnit, UFormController,
   ViewerBy2ndPlayer;

type

  { TViewerForm }

  TViewerForm = class(TForm, IView)
    Image1: TImage;
    MenuItemOperation: TMenuItem;
    MenuItemTitleVisible: TMenuItem;
    MenuItemTitleInVisible: TMenuItem;
    MenuItemFullScreen: TMenuItem;
    MenuItemWindowMode: TMenuItem;
    MenuItemClose: TMenuItem;
    Panel1: TPanel;
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
  Image1.Visible := True;
  
  if Assigned(player) then
  begin
    player.RegisterViewer(Self, Panel1);
  end;
end;




procedure TViewerForm.LoadBitmap();
var
  Bitmap: TBitmap;
begin



  try
    // panel1のサイズ変更
    Panel1.Width := ClientWidth;
    Panel1.Height := ClientHeight;
    Panel1.Left := 0;
    Panel1.Top := 0;

    // PDFium ページを Delphi ビットマップに描画
    Bitmap := model.GetViewBitmap(ClientWidth, ClientHeight);
    Image1.Width := Bitmap.Width;
    Image1.Height := Bitmap.Height;
    Image1.Left := (ClientWidth - Bitmap.Width) div 2;
    Image1.Top := (ClientHeight - Bitmap.Height) div 2;

    Image1.Picture.Bitmap.Assign(Bitmap);
  finally
    Bitmap.Free;
  end;
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

procedure TViewerForm.UpdateView();
begin
  if not Assigned(model) Then Exit;
  ControlEnabled();
  Image1.Visible := True;
  LoadBitmap();
  Self.Color := model.Background.Color;
end;

end.

