unit frmOperation;

// Todo: Form Ratio Windows size Panel sizeで共通化

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, StdCtrls, ExtCtrls,
  Menus, ComCtrls, ViewerModel,
  FormSizeCustomizerUnit, IViewUnit,
  SettingLoaderUnit,  LCLType, LCLIntf, ViewerBy2ndFileTypes,
  ViewerBy2ndPlayer, FormDispatcherUnit, FilesParam, LoggerUnit;

const
  OPERATIONFORM_DEFAULT_WIDTH = 900;
  OPERATIONFORM_DEFAULT_HEIGHT = 600;
  OPERATIONFORM_SLIM_WIDTH = 350;
  OPERATIONFORM_MINIMUM_HEIGHT = 270;
  OPERATIONFORM_PANEL_HEIGHT = 500;
  DEF_PREVIEW_WIDTH = 350;
  MARGIN_WIDTH = 10;

type

  { TOperationForm }

  TOperationForm = class(TForm, IView)
    DelteButton: TButton;
    DeselectButton: TButton;
    FilesListBox: TListBox;
    FilesListPanel: TPanel;
    OpenButton: TButton;
    PlayButton: TButton;
    PreviewPanel: TPanel;
    SelectAllButton: TButton;
    StatusBar1: TStatusBar;
    StopButton: TButton;
    UpdateTimer: TTimer;
    VideoPositionTrackBar: TTrackBar;
    ZoomRateMenuItem: TMenuItem;
    ZoomOutMenuItem: TMenuItem;
    ZoomInMenuItem: TMenuItem;
    Rotate000Button: TButton;
    Rotate090Button: TButton;
    Rotate180Button: TButton;
    Rotate270Button: TButton;

    BackGroundDisplayButton: TButton;
    AutoUpdateCheckBox: TCheckBox;
    FitWindowButton: TButton;
    ViewAllButton: TButton;
    ZoomRateLabel: TLabel;
    ZoomInButton: TButton;
    ZoomOutButton: TButton;
    LastPageButton: TButton;
    FirstPageButton: TButton;
    FileInfoLabel: TLabel;
    ViewerDisplayButton: TButton;
    ViewerCloseButton: TButton;
    ViewerGroupBox: TGroupBox;
    Label1: TLabel;
    MainMenu: TMainMenu;
    FileMenu: TMenuItem;
    ListMenu: TMenuItem;
    DisplayMenu: TMenuItem;
    BackgroundDisplayMenu: TMenuItem;
    FirstPageMenu: TMenuItem;
    LastPageMenu: TMenuItem;
    HelpMenu: TMenuItem;
    AboutMenu: TMenuItem;
    DisplaySettingMenu: TMenuItem;
    AutoUpdateSettingMenu: TMenuItem;
    DefaultSizeMenu: TMenuItem;
    MinimumSizeMenu: TMenuItem;
    SlimSizeMenu: TMenuItem;
    OperationFormSizeMenu: TMenuItem;
    SettingMenu: TMenuItem;
    PageIndexMenu: TMenuItem;
    PreviousPageMenu: TMenuItem;
    NextPageMenu: TMenuItem;
    Rotate270Menu: TMenuItem;
    Rotate180Menu: TMenuItem;
    Rotate090Menu: TMenuItem;
    Rotate000Menu: TMenuItem;
    ViewerCloseMenu: TMenuItem;
    ViewerDisplayMenu: TMenuItem;
    ViewerMenu: TMenuItem;
    VideoPlayMenu: TMenuItem;
    ZoomMenu: TMenuItem;
    PageNavigationMenu: TMenuItem;
    RotateMenu: TMenuItem;
    OpenMenu: TMenuItem;
    PageCountLabel: TLabel;
    NextButton: TButton;
    PreviousButton: TButton;
    ThumbnailImage: TImage;
    OpenDialog1: TOpenDialog;
    ThumbnailPanel: TPanel;
    procedure AboutMenuClick(Sender: TObject);
    procedure AutoUpdateCheckBoxChange(Sender: TObject);
    procedure AutoUpdateSettingMenuClick(Sender: TObject);
    procedure BackGroundDisplayButtonClick(Sender: TObject);
    procedure BackgroundDisplayMenuClick(Sender: TObject);
    procedure DefaultSizeMenuClick(Sender: TObject);
    procedure FirstPageMenuClick(Sender: TObject);
    procedure FitWindowButtonClick(Sender: TObject);
    procedure FormDropFiles(Sender: TObject; const FileNames: array of string);
    procedure FormResize(Sender: TObject);
    procedure HelpMenuClick(Sender: TObject);
    procedure ThumbnailImageMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure ThumbnailImageMouseMove(Sender: TObject; Shift: TShiftState; X, Y: Integer
      );
    procedure ThumbnailImageMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure ThumbnailImageMouseWheel(Sender: TObject; Shift: TShiftState;
      WheelDelta: Integer; MousePos: TPoint; var Handled: Boolean);
    procedure LastPageMenuClick(Sender: TObject);
    procedure MinimumSizeMenuClick(Sender: TObject);
    procedure NextPageMenuClick(Sender: TObject);
    procedure OpenButtonClick(Sender: TObject);
    procedure DelteButtonClick(Sender: TObject);
    procedure DeselectButtonClick(Sender: TObject);
    procedure DisplaySettingMenuClick(Sender: TObject);
    procedure FilesListBoxSelectionChange(Sender: TObject; User: boolean);
    procedure LastPageButtonClick(Sender: TObject);
    procedure FirstPageButtonClick(Sender: TObject);
    procedure OpenMenuClick(Sender: TObject);
    procedure PageIndexMenuClick(Sender: TObject);
    procedure PlayButtonClick(Sender: TObject);
    procedure PreviewPanelResize(Sender: TObject);
    procedure PreviousPageMenuClick(Sender: TObject);
    procedure Rotate000MenuClick(Sender: TObject);
    procedure Rotate090MenuClick(Sender: TObject);
    procedure Rotate000ButtonClick(Sender: TObject);
    procedure Rotate180ButtonClick(Sender: TObject);
    procedure Rotate180MenuClick(Sender: TObject);
    procedure Rotate270ButtonClick(Sender: TObject);
    procedure Rotate270MenuClick(Sender: TObject);
    procedure Rotate090ButtonClick(Sender: TObject);
    procedure SelectAllButtonClick(Sender: TObject);
    procedure SlimSizeMenuClick(Sender: TObject);
    procedure StopButtonClick(Sender: TObject);
    procedure VideoPositionTrackBarChange(Sender: TObject);
    procedure ViewAllButtonClick(Sender: TObject);
    procedure ViewerCloseButtonClick(Sender: TObject);
    procedure ViewerCloseMenuClick(Sender: TObject);
    procedure ViewerDisplayButtonClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var CloseAction: TCloseAction);
    procedure FormCreate(Sender: TObject);
    procedure NextButtonClick(Sender: TObject);
    procedure PageCountLabelClick(Sender: TObject);
    procedure PreviousButtonClick(Sender: TObject);
    procedure UpdateView;
    procedure UpdateAuto;
    procedure ViewerDisplayMenuClick(Sender: TObject);
    procedure ZoomInButtonClick(Sender: TObject);
    procedure ZoomOutButtonClick(Sender: TObject);
    procedure ListMenuChileClick(Sender: TObject);
    procedure ZoomOutMenuItemClick(Sender: TObject);
    procedure ZoomRateLabelClick(Sender: TObject);
    procedure ZoomRateMenuItemClick(Sender: TObject);
    procedure ZoomInMenuItemClick(Sender: TObject);
    procedure UpdateTimerTimer(Sender: TObject);
    procedure VideoPositionTrackBarMouseDown(Sender: TObject; Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
    function IsSizeDefault: Boolean;
    function IsSizeSlim: Boolean;
    function IsSizeMinimum: Boolean;
    procedure SetSizeModeControlVisible;
  private
    AutoUpdateCheckBoxCheckedChanging : Boolean;
    FFilesListBoxLoaded : Boolean;
    IsMouseDown : Boolean;
    IsProgrammaticUpdate : Boolean;
    procedure LoadBitmap;
    procedure SetCtlEnabled();
    procedure SetPageNavigationControlsEnabled;
    procedure SetZoomControlsEnabled;
    procedure SetRotateControlsEnabled;
    procedure SetMovieControlsEnabled;
    procedure SetMenuControlsEnabled;
    procedure SetPanelSize();
    procedure LoadList();
    procedure PopulateFileMenu();
    procedure LoadListBox(fileList : TStringList);
    procedure ProcessAutoUpdate;
    procedure ProcessVideoPosition;
    procedure UpdateFileInfoLabel;
    procedure InitializeForm;
    procedure LoadSavedSettings;
    procedure LoadSavedFileList;
    procedure ShowMissingFilesWarning;
    procedure SetPanelVisibility;
    procedure SetRotateButtonsPosition;
    procedure SetZoomButtonsPosition;
    procedure SetPageNavigationButtonsPosition;
    procedure SetPreviewPanelWidth;
    function CalculateTrackBarPosition(X: Integer): Integer;
    procedure SetTrackBarPosition(TrackBarPosition: Integer);
  public

  end;

var
  OperationForm: TOperationForm;

implementation

{$R *.lfm}

{ TOperationForm }

procedure TOperationForm.SetCtlEnabled();
begin
  SetPageNavigationControlsEnabled;
  SetZoomControlsEnabled;
  SetRotateControlsEnabled;
  SetMovieControlsEnabled;
  SetMenuControlsEnabled;
  SetSizeModeControlVisible;
end;

procedure TOperationForm.SetPageNavigationControlsEnabled;
begin
  FilesListPanel.Visible := IsSizeDefault;
  NextButton.Enabled := model.CanNext;
  PreviousButton.Enabled := model.CanPrevious;
  LastPageButton.Enabled := model.CanLast;
  FirstPageButton.Enabled := model.CanFirst;
  PageCountLabel.Enabled := model.CanPrevious or model.CanNext;
  if PageCountLabel.Enabled Then
    PageCountLabel.Caption := Format('%d / %d', [model.PageIndex + 1, model.PageCount])
  else
    PageCountLabel.Caption := '';
end;

procedure TOperationForm.SetZoomControlsEnabled;
begin
  ZoomInButton.Enabled := model.CanZoomIn;
  ZoomOutButton.Enabled := model.CanZoomOut;
  ZoomRateLabel.Enabled := (model.CanZoomIn) or (model.CanZoomOut);
  FitWindowButton.Enabled := model.CanZoom;
  ViewAllButton.Enabled := model.CanZoom;
end;

procedure TOperationForm.SetRotateControlsEnabled;
begin
  Rotate000Button.Enabled := model.CanRotate;
  Rotate180Button.Enabled := model.CanRotate;
  Rotate270Button.Enabled := model.CanRotate;
  Rotate090Button.Enabled := model.CanRotate;
end;

procedure TOperationForm.SetMovieControlsEnabled;
begin
  ViewerGroupBox.Visible := IsSizeDefault or IsSizeSlim;
  PreviewPanel.Visible := True; // Minimumでも常に表示
  PlayButton.Visible := model.IsMovieFile;
  StopButton.Visible := model.IsMovieFile;
  VideoPositionTrackBar.Visible := model.IsMovieFile;
  ThumbnailImage.Visible := not model.IsMovieFile;
  PlayButton.Enabled := model.IsMovieFile;
  StopButton.Enabled := model.IsMovieFile;
end;

procedure TOperationForm.SetMenuControlsEnabled;
begin
  ViewerDisplayMenu.Enabled := ViewerDisplayButton.Enabled;
  NextPageMenu.Enabled := NextButton.Enabled;
  PreviousPageMenu.Enabled := PreviousButton.Enabled;
  LastPageMenu.Enabled := LastPageButton.Enabled;
  FirstPageMenu.Enabled := FirstPageButton.Enabled;
  PageIndexMenu.Enabled := PageCountLabel.Enabled;
  ZoomInMenuItem.Enabled := ZoomInButton.Enabled;
  ZoomOutMenuItem.Enabled := ZoomOutButton.Enabled;
  ZoomRateMenuItem.Enabled := ZoomRateLabel.Enabled;
  Rotate000Menu.Enabled := Rotate000Button.Enabled;
  Rotate180Menu.Enabled := Rotate180Button.Enabled;
  Rotate270Menu.Enabled := Rotate270Button.Enabled;
  Rotate090Menu.Enabled := Rotate090Button.Enabled;
end;

procedure TOperationForm.FormCreate(Sender: TObject);
begin
  InitializeForm;
  LoadSavedSettings;
  LoadSavedFileList;
  ShowMissingFilesWarning;
  UpdateView;
end;

procedure TOperationForm.InitializeForm;
begin
  Width := OPERATIONFORM_DEFAULT_WIDTH;
  Height := OPERATIONFORM_DEFAULT_HEIGHT;
  model := TViewerModel.Create;
  player.RegisterThumbnail(Self, ThumbnailPanel);
  UpdateTimer.Enabled := True;
end;

procedure TOperationForm.LoadSavedSettings;
begin
  // 保存された背景設定を読み込む
  model.Background.Color := SettingLoader.GetBackgroundColor;
  model.Background.ImagePath := SettingLoader.GetBackgroundImagePath;
  model.Background.UseImage := SettingLoader.GetBackgroundUseImage;
end;

procedure TOperationForm.LoadSavedFileList;
var
  SavedFileList: TStringList;
  i: Integer;
begin
  // 保存されたファイルリストを読み込む
  SavedFileList := SettingLoader.GetFileList;
  if Assigned(SavedFileList) and (SavedFileList.Count > 0) then
  begin
    for i := 0 to SavedFileList.Count - 1 do
    begin
      model.Open(SavedFileList[i]);
    end;
  end;
end;

procedure TOperationForm.ShowMissingFilesWarning;
var
  MissingFiles: TStringList;
  i: Integer;
  MissingFilesMessage: String;
begin
  // 存在しないファイルについてユーザーに通知
  MissingFiles := SettingLoader.GetMissingFiles;
  if Assigned(MissingFiles) and (MissingFiles.Count > 0) then
  begin
    MissingFilesMessage := '以下のファイルが見つかりませんでした:' + #13#10;
    
    if MissingFiles.Count <= 10 then
    begin
      // 10件以下の場合は全て表示
      for i := 0 to MissingFiles.Count - 1 do
      begin
        MissingFilesMessage := MissingFilesMessage + '・' + ExtractFileName(MissingFiles[i]) + #13#10;
      end;
    end
    else
    begin
      // 10件を超える場合は最初の9件を表示し、残りを「その他」として表示
      for i := 0 to 8 do
      begin
        MissingFilesMessage := MissingFilesMessage + '・' + ExtractFileName(MissingFiles[i]) + #13#10;
      end;
      MissingFilesMessage := MissingFilesMessage + '・その他 ' + IntToStr(MissingFiles.Count - 9) + '件' + #13#10;
    end;
    
    MissingFilesMessage := MissingFilesMessage + #13#10 + 'ファイルが移動または削除された可能性があります。';
    
    ShowMessage(MissingFilesMessage);
  end;
end;

procedure TOperationForm.UpdateAuto();
begin
  UpdateView;
  if AutoUpdateCheckBox.Checked then
  begin
    FormDispatcher.ShowViewerForm;
  end;
end;

procedure TOperationForm.SetPanelSize();
var
  rect : TRect;
  w,h : Integer;
begin

  If not Assigned(FormSizeCustomizer) Then
  begin
    exit;
  end;
  rect := FormSizeCustomizer.CurrentWindowSize;
  w := ThumbnailPanel.Width;
  h := (w * rect.Height) div rect.Width;
  ThumbnailPanel.Height := h;

  StatusBar1.SimpleText := Format('Width: %d, Height: %d',
    [rect.Width, rect.Height]);

end;

procedure TOperationForm.UpdateView();
begin
  SetCtlEnabled();
  LoadList();
  SetPanelSize();
  LoadBitmap();
  ThumbnailPanel.Color:=model.Background.Color;
  if model.HasOperationDocument then
  begin
    ZoomRateLabel.Caption:= IntToStr(Round(model.Zoom.Rate * 100)) + '%';
  end
  else
  begin
    ZoomRateLabel.Caption:= '';
  end;

  // 動画ファイルの場合、新しいファイルを読み込んで再生を開始
  if model.IsMovieFile then
  begin
    player.DispThumbnail(model.GetSelectedFile.Filename);
  end;
  
  UpdateFileInfoLabel;
end;

procedure TOperationForm.UpdateFileInfoLabel;
var
  SelectedFile: TFilesParam;
begin
  if model.HasOperationDocument then
  begin
    SelectedFile := model.GetSelectedFile;
    if Assigned(SelectedFile) then
    begin
      FileInfoLabel.Caption := 'ファイル: ' + SelectedFile.Filename;
    end
    else
    begin
      FileInfoLabel.Caption := 'ファイル: 選択されていません';
    end;
  end
  else
  begin
    FileInfoLabel.Caption := 'ファイル: なし';
  end;
end;

procedure TOperationForm.ViewerDisplayMenuClick(Sender: TObject);
begin
  ViewerDisplayButtonClick(Sender);
end;

procedure TOperationForm.ZoomInButtonClick(Sender: TObject);
begin
  model.ZoomIn;
end;

procedure TOperationForm.ZoomOutButtonClick(Sender: TObject);
begin
  model.ZoomOut;
end;

procedure TOperationForm.LoadList();
var
  fileList: TStringList;
begin
  FFilesListBoxLoaded := True;

  fileList := model.GetFileNames; // Get the filenames from the model
  if Assigned(fileList) then
  begin
    LoadListBox(fileList);
    PopulateFileMenu();
  end;


  FFilesListBoxLoaded := False;
end;

procedure TOperationForm.LoadListBox(fileList : TStringList);
var
  i : Integer;
begin
  FilesListBox.Items.Clear; // Clear any existing items
  try
    FilesListBox.Items.Assign(fileList); // Assign the list to ListBox
  finally
    fileList.Free; // Free the TStringList
  end;

  for i := 0 to FilesListBox.Items.Count - 1 do
  begin
       FilesListBox.Selected[i] := model.GetFileSelected(i);
  end;
end;

procedure TOperationForm.NextButtonClick(Sender: TObject);
begin
  model.Next;
end;

procedure TOperationForm.PageCountLabelClick(Sender: TObject);
begin
  if not model.HasOperationDocument then
  begin
    Exit;
  end;
  FormDispatcher.ShowPageForm;
end;

procedure TOperationForm.PreviousButtonClick(Sender: TObject);
begin
  model.Previous;
end;

procedure TOperationForm.LoadBitmap;
var
  Bitmap : TBitmap;
begin
  Logger.BeginSection('オペレーションフォーム画像読み込み');
  Logger.Info(Format('要求サイズ: %dx%d', [ThumbnailPanel.Width, ThumbnailPanel.Height]));
  Logger.StartTimer('オペレーションフォーム画像読み込み');

  try
    // PDFium ページを Delphi ビットマップに描画
    Logger.Debug('1. GetThumbnailBitmap呼び出し開始 (最も時間がかかる可能性)');
    Bitmap := model.GetThumbnailBitmap(ThumbnailPanel.Width, ThumbnailPanel.Height);
    Logger.Debug('2. GetThumbnailBitmap呼び出し完了');

    if Assigned(Bitmap) then
    begin
      Logger.Debug('3. 画像表示設定開始');
      ThumbnailImage.Width := Bitmap.Width;
      ThumbnailImage.Height := Bitmap.Height;
      ThumbnailImage.Left := (ThumbnailPanel.Width - Bitmap.Width) div 2;
      ThumbnailImage.Top := (ThumbnailPanel.Height - Bitmap.Height) div 2;

      ThumbnailImage.Picture.Assign(Bitmap);
      Logger.Debug('4. 画像表示設定完了');
    end;
  finally
    if Assigned(Bitmap) then
    begin
      Bitmap.Free;
      Logger.Debug('5. ビットマップ解放完了');
    end;
  end;

  Logger.EndTimer('オペレーションフォーム画像読み込み');
  Logger.EndSection('オペレーションフォーム画像読み込み');
end;
procedure TOperationForm.ListMenuChileClick(Sender: TObject);
var
  index: Integer;
begin
  index := StrToInt(TMenuItem(Sender).Hint);
  model.DisselectAll;
  model.SetFileSelected(index, True);
end;

procedure TOperationForm.ZoomOutMenuItemClick(Sender: TObject);
begin
  ZoomOutButtonClick(Sender);
end;

procedure TOperationForm.ZoomRateLabelClick(Sender: TObject);
begin
  if not model.HasOperationDocument then
  begin
    Exit;
  end;
  FormDispatcher.ShowZoomRateForm;
end;

procedure TOperationForm.ZoomRateMenuItemClick(Sender: TObject);
begin
  ZoomRateLabelClick(Sender);
end;

procedure TOperationForm.ZoomInMenuItemClick(Sender: TObject);
begin
  ZoomInButtonClick(Sender);
end;

procedure TOperationForm.PopulateFileMenu();
var
  i: Integer;
  MenuItem: TMenuItem;
begin
  // 子メニューをすべてクリア
  ListMenu.Clear;


  // TStringList の内容をメニュー項目として追加
  for i := 0 to model.GetFileCount() - 1 do
  begin
    MenuItem := TMenuItem.Create(ListMenu);
    MenuItem.Caption := ExtractFileName(model.GetFileName(i)); // 表示名はファイル名
    MenuItem.Hint := IntToStr(i);
    MenuItem.OnClick := @(ListMenuChileClick);
    ListMenu.Add(MenuItem);
  end;
end;

procedure TOperationForm.OpenButtonClick(Sender: TObject);
var
  i : Integer;
begin
  OpenDialog1.Filter := GetFileFilter;
  OpenDialog1.Options:=OpenDialog1.Options+[ofAllowMultiSelect];

  if not OpenDialog1.Execute then Exit;

  for i:=0 to OpenDialog1.Files.Count-1 do
  begin
    if IsMovie(OpenDialog1.Files[i]) then
    begin
      player.PlayFile(OpenDialog1.Files[i]);
    end;
    model.Open(OpenDialog1.Files[i]);
  end;

  SetCtlEnabled();
end;

procedure TOperationForm.DelteButtonClick(Sender: TObject);
begin
  model.DeleteSelectedFiles;
end;

procedure TOperationForm.DeselectButtonClick(Sender: TObject);
begin
  model.DisselectAll;
end;

procedure TOperationForm.BackGroundDisplayButtonClick(Sender: TObject);
begin
  // 操作中に自動表示がONの場合は選択解除する
  if AutoUpdateCheckBox.Checked then
  begin
    model.DisselectAll;
  end else
  begin
    // ビューワー画面のみ背景表示にする
    model.ShowBackGround();
    FormDispatcher.ShowBackgroundViewerForm;
  end;
  

end;

procedure TOperationForm.BackgroundDisplayMenuClick(Sender: TObject);
begin
  BackGroundDisplayButtonClick(Sender);
end;

procedure TOperationForm.DefaultSizeMenuClick(Sender: TObject);
begin
  Width := OPERATIONFORM_DEFAULT_WIDTH;
  Height := OPERATIONFORM_DEFAULT_HEIGHT;
  SetCtlEnabled;
end;


procedure TOperationForm.FirstPageMenuClick(Sender: TObject);
begin
 FirstPageButtonClick(Sender);
end;

procedure TOperationForm.AboutMenuClick(Sender: TObject);
begin
  FormDispatcher.ShowAboutForm;
end;

procedure TOperationForm.AutoUpdateCheckBoxChange(Sender: TObject);
begin
  if AutoUpdateCheckBoxCheckedChanging then Exit;

  AutoUpdateSettingMenu.Checked:=AutoUpdateCheckBox.Checked;
  if AutoUpdateCheckBox.Checked then
  begin
    UpdateAuto;
  end;
end;

procedure TOperationForm.AutoUpdateSettingMenuClick(Sender: TObject);
begin
  AutoUpdateSettingMenu.Checked:=Not AutoUpdateSettingMenu.Checked;
  AutoUpdateCheckBoxCheckedChanging := True;
  AutoUpdateCheckBox.Checked:= AutoUpdateSettingMenu.Checked;
  AutoUpdateCheckBoxCheckedChanging := False;
    if AutoUpdateSettingMenu.Checked then
  begin
    UpdateAuto;
  end;
end;

procedure TOperationForm.FitWindowButtonClick(Sender: TObject);
begin
  model.FitWindow(ThumbnailPanel.Width, ThumbnailPanel.Height);
end;

procedure TOperationForm.FormDropFiles(Sender: TObject;
  const FileNames: array of string);
var 
  FileName: String;
begin
  for FileName in FileNames do
  begin
    if CanOpen(FileName) then
    begin
      model.AddFile(FileName);
    end;
  end;
end;


procedure TOperationForm.FormResize(Sender: TObject);
begin
   SetCtlEnabled();
end;

procedure TOperationForm.HelpMenuClick(Sender: TObject);
begin

end;

procedure TOperationForm.ThumbnailImageMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  if Button = TMouseButton.mbLeft then
  begin
    IsMouseDown := True;
    model.Zoom.MouseDown(X, Y);
  end;
end;

procedure TOperationForm.ThumbnailImageMouseMove(Sender: TObject; Shift: TShiftState;
  X, Y: Integer);
begin
  if IsMouseDown Then
  begin
   model.Zoom.MouseMove(X,Y);
  end;
end;

procedure TOperationForm.ThumbnailImageMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  if IsMouseDown And (Button = TMouseButton.mbLeft) then
  begin
   IsMouseDown := False;
  end;
end;

procedure TOperationForm.ThumbnailImageMouseWheel(Sender: TObject; Shift: TShiftState;
  WheelDelta: Integer; MousePos: TPoint; var Handled: Boolean);
begin
  model.MouseWheel(WheelDelta, MousePos.X, MousePos.Y, Shift);
end;

procedure TOperationForm.LastPageMenuClick(Sender: TObject);
begin
  LastPageButtonClick(Sender);
end;

procedure TOperationForm.MinimumSizeMenuClick(Sender: TObject);
begin
  Width := OPERATIONFORM_SLIM_WIDTH;
  Height := OPERATIONFORM_MINIMUM_HEIGHT;
  SetCtlEnabled;
end;

procedure TOperationForm.NextPageMenuClick(Sender: TObject);
begin
  NextButtonClick(Sender);
end;

procedure TOperationForm.DisplaySettingMenuClick(Sender: TObject);
begin
  FormDispatcher.ShowSettingForm;
end;

procedure TOperationForm.FilesListBoxSelectionChange(Sender: TObject;
  User: boolean);
var
  i : Integer;
begin
  If FFilesListBoxLoaded Then
     Exit;

  for i:= 0 to FilesListBox.Count - 1 do
  begin
       model.SetFileSelected(i, FilesListBox.Selected[i]);
  end;
  
  // 動画ファイルが選択された場合、即座に新しいファイルを読み込む
  if model.IsMovieFile and Assigned(model.GetSelectedFile) then
  begin
    player.PlayFile(model.GetSelectedFile.Filename);
  end;
end;

procedure TOperationForm.LastPageButtonClick(Sender: TObject);
begin
  model.LastPage();
end;

procedure TOperationForm.FirstPageButtonClick(Sender: TObject);
begin
  model.FirstPage();
end;

procedure TOperationForm.OpenMenuClick(Sender: TObject);
begin
  OpenButtonClick(Sender);
end;

procedure TOperationForm.PageIndexMenuClick(Sender: TObject);
begin
  PageCountLabelClick(Sender);
end;

procedure TOperationForm.PlayButtonClick(Sender: TObject);
begin
  if not Assigned(player) then Exit;
  player.Play;
end;

procedure TOperationForm.PreviewPanelResize(Sender: TObject);
begin
  ThumbnailPanel.Left:=0;
  ThumbnailPanel.Width:=PreviewPanel.Width;
end;

procedure TOperationForm.PreviousPageMenuClick(Sender: TObject);
begin
  PreviousButtonClick(Sender);
end;

procedure TOperationForm.Rotate000MenuClick(Sender: TObject);
begin
    Rotate000ButtonClick(Sender);
end;

procedure TOperationForm.Rotate090MenuClick(Sender: TObject);
begin
  Rotate090ButtonClick(Sender);
end;

procedure TOperationForm.Rotate000ButtonClick(Sender: TObject);
begin
  model.Rotate(0);
end;

procedure TOperationForm.Rotate180ButtonClick(Sender: TObject);
begin
  model.Rotate(180);
end;

procedure TOperationForm.Rotate180MenuClick(Sender: TObject);
begin
  Rotate180ButtonClick(Sender);
end;

procedure TOperationForm.Rotate270ButtonClick(Sender: TObject);
begin
  model.Rotate(270);
end;

procedure TOperationForm.Rotate270MenuClick(Sender: TObject);
begin
  Rotate270ButtonClick(Sender);
end;

procedure TOperationForm.Rotate090ButtonClick(Sender: TObject);
begin
  model.Rotate(90);
end;

procedure TOperationForm.SelectAllButtonClick(Sender: TObject);
begin
  model.SelectAllFiles;
end;

procedure TOperationForm.SlimSizeMenuClick(Sender: TObject);
begin
  Width := OPERATIONFORM_SLIM_WIDTH;
  Height := OPERATIONFORM_DEFAULT_HEIGHT;
  SetCtlEnabled;
end;

procedure TOperationForm.StopButtonClick(Sender: TObject);
begin
  if not Assigned(player) then Exit;
  player.Stop;
end;

procedure TOperationForm.VideoPositionTrackBarChange(Sender: TObject);
begin
  if IsProgrammaticUpdate then Exit;
  if not Assigned(player) then Exit;
  if not VideoPositionTrackBar.Enabled then Exit;
  // TrackBarの位置を動画再生位置に反映
  player.VideoPosition := VideoPositionTrackBar.Position;
end;

procedure TOperationForm.ViewAllButtonClick(Sender: TObject);
begin
  model.ViewAll;
end;

procedure TOperationForm.ViewerCloseButtonClick(Sender: TObject);
begin
  FormDispatcher.CloseViewerForm;
end;

procedure TOperationForm.ViewerCloseMenuClick(Sender: TObject);
begin
  ViewerCloseButtonClick(Sender);
end;


procedure TOperationForm.ViewerDisplayButtonClick(Sender: TObject);
begin
  FormDispatcher.ShowViewerForm;
end;

procedure TOperationForm.FormClose(Sender: TObject; var CloseAction: TCloseAction);
var
  CurrentFileList: TStringList;
begin
  // 現在のファイルリストを保存
  CurrentFileList := model.GetFileNames;
  if Assigned(CurrentFileList) then
  begin
    SettingLoader.SetFileList(CurrentFileList);
    CurrentFileList.Free;
  end;
  
  // モデルから設定を収集してから保存
  SettingLoader.CollectSettingsFromModel(model);
  SettingLoader.Save;
  FreeAndNil(player);
  model.Free;
end;

procedure TOperationForm.UpdateTimerTimer(Sender: TObject);
begin
  ProcessAutoUpdate;
  ProcessVideoPosition;
end;

procedure TOperationForm.ProcessAutoUpdate;
begin
  // AutoUpdateをUpdateTimerで実行
  if model.Updated then
  begin
    UpdateAuto;
    model.ClearUpdated;
  end;
end;

procedure TOperationForm.ProcessVideoPosition;
begin
  if model.IsMovieFile then
  begin
    if not Assigned(player) then Exit;
    if player.VideoLength = 0 then Exit;

    // ステータスバーに再生位置を表示
    StatusBar1.SimpleText := Format('Position: %d / %d',
      [player.VideoPosition, player.VideoLength]);

    // VideoPositionTrackBarの同期
    IsProgrammaticUpdate := True;
    VideoPositionTrackBar.Enabled := True;
    VideoPositionTrackBar.Max := player.VideoLength;
    VideoPositionTrackBar.Position := player.VideoPosition;
    IsProgrammaticUpdate := False;
  end;
end;

procedure TOperationForm.VideoPositionTrackBarMouseDown(Sender: TObject; Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
var
  NewPosition: Integer;
begin
  NewPosition := CalculateTrackBarPosition(X);
  SetTrackBarPosition(NewPosition);
end;

function TOperationForm.CalculateTrackBarPosition(X: Integer): Integer;
var
  SliderWidth: Integer;
  CalculatedPosition: Integer;
begin
  SliderWidth := VideoPositionTrackBar.Width - (MARGIN_WIDTH * 2);
  X := X - MARGIN_WIDTH;
  
  // X座標をスライダー範囲内に制限
  if X < 0 then X := 0;
  if X > SliderWidth then X := SliderWidth;

  // 位置を計算
  if SliderWidth > 0 then
    CalculatedPosition := Round(X / SliderWidth * VideoPositionTrackBar.Max)
  else
    CalculatedPosition := 0;

  Result := CalculatedPosition;
end;

procedure TOperationForm.SetTrackBarPosition(TrackBarPosition: Integer);
begin
  // 位置を有効範囲内に制限
  if TrackBarPosition < 0 then TrackBarPosition := 0;
  if TrackBarPosition > VideoPositionTrackBar.Max then TrackBarPosition := VideoPositionTrackBar.Max;

  VideoPositionTrackBar.Position := TrackBarPosition;
end;

function TOperationForm.IsSizeDefault: Boolean;
begin
  Result := (Width >= OPERATIONFORM_DEFAULT_WIDTH) and (Height >= OPERATIONFORM_DEFAULT_HEIGHT);
end;

function TOperationForm.IsSizeSlim: Boolean;
begin
  Result := (Width <= OPERATIONFORM_SLIM_WIDTH) and (Height >= OPERATIONFORM_PANEL_HEIGHT) and (not IsSizeMinimum);
end;

function TOperationForm.IsSizeMinimum: Boolean;
begin
  Result := (Width <= OPERATIONFORM_SLIM_WIDTH) and (Height <= OPERATIONFORM_MINIMUM_HEIGHT);
end;


procedure TOperationForm.SetSizeModeControlVisible;
begin
  SetPanelVisibility;
  SetRotateButtonsPosition;
  SetZoomButtonsPosition;
  SetPageNavigationButtonsPosition;
  SetPreviewPanelWidth;
end;

procedure TOperationForm.SetPanelVisibility;
begin
  FilesListPanel.Visible := IsSizeDefault;

  // FilesListPanel.VisibleがFalseの場合はPreviewPanelを一番右に表示
  if not FilesListPanel.Visible then
  begin
    PreviewPanel.Left := 0;
  end else
  begin
    PreviewPanel.Left := FilesListPanel.Width + MARGIN_WIDTH;
  end;
end;

procedure TOperationForm.SetRotateButtonsPosition;
begin
  Rotate090Button.Left := PreviewPanel.Left + PreviewPanel.Width + MARGIN_WIDTH;
  Rotate000Button.Left := Rotate090Button.Left + 50;
  Rotate180Button.Left := Rotate000Button.Left;
  Rotate270Button.Left := Rotate090Button.Left + Rotate090Button.Width + MARGIN_WIDTH;
end;

procedure TOperationForm.SetZoomButtonsPosition;
begin
  FitWindowButton.Left := Rotate090Button.Left;
  ViewAllButton.Left := FitWindowButton.Left + FitWindowButton.Width + MARGIN_WIDTH;
  ZoomInButton.Left := Rotate090Button.Left + 25;
  ZoomOutButton.Left := ZoomInButton.Left + ZoomInButton.Width + MARGIN_WIDTH;
  ZoomRateLabel.Left := Rotate000Button.Left + 25;
end;

procedure TOperationForm.SetPageNavigationButtonsPosition;
begin
  FirstPageButton.Left := Rotate090Button.Left;
  PreviousButton.Left := FirstPageButton.Left + FirstPageButton.Width + MARGIN_WIDTH;
  NextButton.Left := PreviousButton.Left + PreviousButton.Width + MARGIN_WIDTH;
  LastPageButton.Left := NextButton.Left + NextButton.Width + MARGIN_WIDTH;
end;

procedure TOperationForm.SetPreviewPanelWidth;
begin
  if Width < OPERATIONFORM_SLIM_WIDTH then
  begin
    PreviewPanel.Width := Width;
  end else
  begin
    PreviewPanel.Width := DEF_PREVIEW_WIDTH;
  end;
end;

end.

