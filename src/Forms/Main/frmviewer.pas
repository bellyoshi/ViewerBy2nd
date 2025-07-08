unit frmViewer;

{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, ExtCtrls, Menus,
   ViewerModel, FormSizeCustomizerUnit, IViewUnit, UFormController,
   ViewerBy2ndPlayer, LoggerUnit, AsyncImageGeneratorUnit, PdfImageCreator, Types;

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
    procedure ViewerImageMouseWheel(Sender: TObject; Shift: TShiftState;
      WheelDelta: Integer; MousePos: TPoint; var Handled: Boolean);

  private
    FIsFullScreen: Boolean;
    FIsLoading: Boolean;
    procedure SetIsFullScreen(Value: Boolean);
    procedure LoadBitmap();
    function LoadBitmapAsync(): Boolean;
    procedure OnAsyncImageComplete(const Result: TAsyncImageResult);
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
  if FIsLoading then Exit; // 既に読み込み中の場合はスキップ
  
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

    // PDFファイルの場合のみ非同期処理を試行
    if Assigned(model) and Assigned(model.CurrentFile) then
    begin
      if model.IsPDF then
      begin
        Logger.Debug('PDFファイルのため非同期処理を試行');
        if LoadBitmapAsync() then
        begin
          Logger.Debug('非同期画像読み込みを開始');
          Exit;
        end;
        Logger.Debug('非同期処理が失敗したため同期処理にフォールバック');
      end
      else
      begin
        Logger.Debug('PDFファイルではないため同期処理を実行');
      end;
    end
    else
    begin
      Logger.Debug('ファイル情報が取得できないため同期処理を実行');
    end;

    // 非同期処理が失敗した場合は同期処理
    Logger.Debug('3. 同期GetViewBitmap呼び出し開始');
    Bitmap := model.GetViewBitmap(ClientWidth, ClientHeight);
    Logger.Debug('4. 同期GetViewBitmap呼び出し完了');

    Logger.Debug('5. 画像表示設定開始');
    ViewerImage.Width := Bitmap.Width;
    ViewerImage.Height := Bitmap.Height;
    ViewerImage.Left := (ClientWidth - Bitmap.Width) div 2;
    ViewerImage.Top := (ClientHeight - Bitmap.Height) div 2;

    ViewerImage.Picture.Bitmap.Assign(Bitmap);
    Logger.Debug('6. 画像表示設定完了');
  finally
    if Assigned(Bitmap) then
      Bitmap.Free;
    Logger.Debug('7. ビットマップ解放完了');
  end;

  Logger.EndTimer('ビューアーフォーム画像読み込み');
  Logger.EndSection('ビューアーフォーム画像読み込み');
end;

function TViewerForm.LoadBitmapAsync(): Boolean;
var
  PdfImageCreator: TPdfImageCreator;
begin
  Logger.BeginSection('LoadBitmapAsync');
  Logger.Info(Format('開始 - 要求サイズ: %dx%d', [ClientWidth, ClientHeight]));
  Logger.StartTimer('LoadBitmapAsync');
  
  Result := False;
  Exit;
  
  // モデルの確認
  if not Assigned(model) then
  begin
    Logger.Warning('モデルが割り当てられていません');
    Logger.EndTimer('LoadBitmapAsync');
    Logger.EndSection('LoadBitmapAsync');
    Exit;
  end;
  
  // 現在のファイルの確認
  if not Assigned(model.CurrentFile) then
  begin
    Logger.Warning('現在のファイルが割り当てられていません');
    Logger.EndTimer('LoadBitmapAsync');
    Logger.EndSection('LoadBitmapAsync');
    Exit;
  end;

  if not Assigned(model.CurrentFile) then
  begin
    Logger.Warning('選択されたファイルがありません');
    Logger.EndTimer('LoadBitmapAsync');
    Logger.EndSection('LoadBitmapAsync');
    Exit;
  end;
  
  Logger.Debug(Format('選択ファイル: %s', [model.CurrentFileName]));
  
  // PDFファイルかどうかを確認
  if not model.IsPDF then
  begin
    Logger.Warning('PDFファイルではないため非同期処理をスキップ: ' + model.CurrentFileName);
    Logger.EndTimer('LoadBitmapAsync');
    Logger.EndSection('LoadBitmapAsync');
    Exit;
  end;
  
  Logger.Debug('PDFファイル確認完了');
  
  // 既に読み込み中の場合はスキップ
  if FIsLoading then
  begin
    Logger.Info('既に読み込み中のためスキップ');
    Logger.EndTimer('LoadBitmapAsync');
    Logger.EndSection('LoadBitmapAsync');
    Exit;
  end;
  
  try
    Logger.Debug('TPdfImageCreator作成開始');
    PdfImageCreator := TPdfImageCreator.Create(model.CurrentFilename, model.CurrentFile.ImageCreator.GetPageIndex);
    Logger.Debug('TPdfImageCreator作成完了');
    
    try
      Logger.Debug('非同期設定開始');
      PdfImageCreator.UseAsync := True;
      PdfImageCreator.UseCache := True;
      Logger.Debug('非同期設定完了');
      
      Logger.Debug('読み込み状態をTrueに設定');
      FIsLoading := True;
      
      Logger.Debug('GetBitmapAsync呼び出し開始');
      Result := PdfImageCreator.GetBitmapAsync(ClientWidth, ClientHeight, @OnAsyncImageComplete);
      Logger.Debug(Format('GetBitmapAsync呼び出し完了 - 結果: %s', [BoolToStr(Result, True)]));
      
      if Result then
      begin
        Logger.Info('非同期画像読み込みを開始しました');
      end
      else
      begin
        Logger.Warning('非同期画像読み込みの開始に失敗しました');
      end;
      
    finally
      Logger.Debug('TPdfImageCreator解放開始');
      PdfImageCreator.Free;
      Logger.Debug('TPdfImageCreator解放完了');
    end;
    
  except
    on E: Exception do
    begin
      Logger.Error('非同期画像読み込みで例外が発生: ' + E.Message);
      Logger.Error('例外クラス: ' + E.ClassName);
      FIsLoading := False;
    end;
  end;
  
  Logger.EndTimer('LoadBitmapAsync');
  Logger.EndSection('LoadBitmapAsync');
end;

procedure TViewerForm.OnAsyncImageComplete(const Result: TAsyncImageResult);
begin
  Logger.BeginSection('OnAsyncImageComplete');
  Logger.Info('非同期画像読み込みコールバック開始');
  Logger.StartTimer('OnAsyncImageComplete');
  
  Logger.Debug('読み込み状態をFalseに設定');
  FIsLoading := False;
  
  Logger.Debug(Format('結果 - Success: %s, Bitmap割り当て: %s', [
    BoolToStr(Result.Success, True),
    BoolToStr(Assigned(Result.Bitmap), True)
  ]));
  
  if Result.Success and Assigned(Result.Bitmap) then
  begin
    Logger.Info('非同期画像読み込み成功');
    Logger.Debug(Format('画像サイズ: %dx%d', [Result.Bitmap.Width, Result.Bitmap.Height]));
    Logger.Debug(Format('フォームサイズ: %dx%d', [ClientWidth, ClientHeight]));
    
    Logger.Debug('画像表示設定開始');
    ViewerImage.Width := Result.Bitmap.Width;
    ViewerImage.Height := Result.Bitmap.Height;
    ViewerImage.Left := (ClientWidth - Result.Bitmap.Width) div 2;
    ViewerImage.Top := (ClientHeight - Result.Bitmap.Height) div 2;
    
    Logger.Debug('ビットマップ割り当て開始');
    ViewerImage.Picture.Bitmap.Assign(Result.Bitmap);
    Logger.Debug('ビットマップ割り当て完了');
    
    Logger.Info('非同期画像表示設定完了');
  end
  else
  begin
    Logger.Error('非同期画像読み込み失敗');
    if not Result.Success then
      Logger.Error('失敗理由: ' + Result.ErrorMessage);
    if not Assigned(Result.Bitmap) then
      Logger.Error('ビットマップが割り当てられていません');
      
    Logger.Info('同期処理にフォールバック');
    // 失敗した場合は同期処理を実行
    LoadBitmap();
  end;
  
  Logger.EndTimer('OnAsyncImageComplete');
  Logger.EndSection('OnAsyncImageComplete');
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

procedure TViewerForm.ViewerImageMouseWheel(Sender: TObject;
  Shift: TShiftState; WheelDelta: Integer; MousePos: TPoint;
  var Handled: Boolean);
begin
  model.MouseWheel(WheelDelta,MousePos.X, MousePos.Y, Shift);
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

