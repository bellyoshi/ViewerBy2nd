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
  libloaderunit, LoggerUnit, MessageFormUnit
  { you can add units after this };

{$R *.res}

//TODO: マウスホイールでPDFは次のページに行く。
//TODO: パーセンテージ表示 小数点以下1桁

var
  message : String;
begin
  RequireDerivedFormResource:=True;
  Application.Scaled:=True;
  Application.Initialize;

  // Loggerの初期化
  Logger := TLogger.Create;
  Logger.SetLogFile('debug.log');
  Logger.SetLogLevel(llDebug);
  Logger.Info('アプリケーション開始');

  message := '';
  // pdfium.dllの存在をチェック
  if not LibLoader.IsPdfiumDllAvailable then
  begin
    message := ('pdfium.dllが見つかりませんでした。' + #13#10 +
                'PDFファイルの表示機能が利用できません。' + #13#10 +
                'アプリケーションは続行しますが、PDFファイルは開けません。');
    Logger.Warning('pdfium.dllが見つかりません');
  end
  else
  begin
    Logger.Info('pdfium.dll確認完了');
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
  Logger.Info('アプリケーション実行開始');
  Application.Run;
  Logger.Info('アプリケーション終了');
  Logger.Free;
end. 
