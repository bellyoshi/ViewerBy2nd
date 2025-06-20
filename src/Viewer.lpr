program Viewer;

{$mode ObjFPC}{$H+}

uses
  {$IFDEF UNIX}
  cthreads,
  {$ENDIF}
  {$IFDEF HASAMIGA}
  athreads,
  {$ENDIF}
  Interfaces, // this includes the LCL widgetset
  Forms,
  frmViewer, frmOperation,
  RepogitoryUnit,
  FormSizeCustomizerUnit,
  PageFormUnit,
  SettingFormUnit,
  IViewUnit,
  ZoomUnit,
  AboutUnit,
  ZoomRateFormUnit,
  SettingLoaderUnit,
  ViewerBy2ndFileTypes,
  ViewerBy2ndPlayer,
  TMovieImageCreatorUnit,
  UFormController,
  FormDispatcherUnit, ViewerModel,
  libloaderunit, MessageFormUnit
  { you can add units after this };

{$R *.res}

//TODO: 設定ファイルの読み込み
//TODO: 設定の初期化
//TODO: 設定からファイルリストの読み込み
//TODO: 設定からファイルリストの書き込み
var
  message : String;
begin
  RequireDerivedFormResource:=True;
  Application.Scaled:=True;
  Application.Initialize;

  message := '';
  // pdfium.dllの存在をチェック
  if not LibLoader.IsPdfiumDllAvailable then
  begin
    message := ('pdfium.dllが見つかりませんでした。' + #13#10 +
                'PDFファイルの表示機能が利用できません。' + #13#10 +
                'アプリケーションは続行しますが、PDFファイルは開けません。');
  end;

  SettingLoader := TSettingLoader.Create;
  SettingLoader.Load;

  player := TViewerBy2ndPlayer.Create;

  Application.CreateForm(TOperationForm, OperationForm);
  Application.CreateForm(TViewerForm, ViewerForm);
  Application.CreateForm(TPageForm, PageForm);
  Application.CreateForm(TSettingForm, SettingForm);
  Application.CreateForm(TAboutForm, AboutForm);
  Application.CreateForm(TZoomRateForm, ZoomRateForm);
  Application.CreateForm(TMessageForm, MessageForm);

  formManager := TFormManager.Create;
  formManager.RegisterView(ViewerForm);
  formManager.RegisterView(OperationForm);

  FormController.RegisterForm(OperationForm);
  ViewerForm.Show();
  OperationForm.Show();
  if message <> '' Then
  begin
    MessageForm.SetMessage(message);
    MessageForm.ShowModal();
  end;

  SettingLoader.ApplySettings;
  Application.Run;
end. 
