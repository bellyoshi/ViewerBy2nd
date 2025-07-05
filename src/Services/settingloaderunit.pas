unit SettingLoaderUnit;


{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, Forms, FormSizeCustomizerUnit, IniFiles, Graphics, ViewerModel;

{
//Load
設定ファイルを読み込む

設定ファイルの内容
・スクリーン番号
・フルスクリーンかウインドウモードか
・ウインドウモードの場合ウインドウサイズと位置

設定ファイルが有効であるかを確認する。
・スクリーン番号はScreen.MonitorCountに入っているか
→入っていなければセカンドモニターを探す。
→セカンドモニターがなければフルスクリーンではない。スクリーン番号は0、ウインドウモードにする。
・ウインドウサイズがモニターサイズ以内か。

設定を反映する。
FormSizeCustomizer.ScreenIndex = スクリーン番号
FormSizeCustomizer.IsFullScreen = フルスクリーンならTrue
FormSizeCustomizer.SetOriginalSize(Top, Left , Width, Height: Integer);

//Save
設定ファイルをほぞんする。
}


type
  TSettingLoader = class
  private
    FScreenIndex: Integer;
    FIsFullScreen: Boolean;
    FWindowTop: Integer;
    FWindowLeft: Integer;
    FWindowWidth: Integer;
    FWindowHeight: Integer;
    FBackgroundColor: TColor;
    FFileList: TStringList;
    FMissingFiles: TStringList;
    const
      SETTINGS_FILE = 'settings.ini';
    procedure LoadDefaults;
    procedure ValidateSettings;
    procedure CollectSettings;
    procedure LoadFileList;
    procedure SaveFileList;
  public
    constructor Create;
    destructor Destroy; override;
    procedure Load;
    procedure Save;
    procedure ApplySettings;
    function GetFileList: TStringList;
    procedure SetFileList(AFileList: TStringList);
    function GetMissingFiles: TStringList;
    function GetBackgroundColor: TColor;
    procedure SetBackgroundColor(AColor: TColor);
    procedure CollectSettingsFromModel(AModel: TObject);
  end;

var
  SettingLoader: TSettingLoader;

implementation

constructor TSettingLoader.Create;
begin
  FFileList := TStringList.Create;
  FMissingFiles := TStringList.Create;
end;

destructor TSettingLoader.Destroy;
begin
  FFileList.Free;
  FMissingFiles.Free;
  inherited Destroy;
end;

procedure TSettingLoader.LoadDefaults;
begin
  // セカンドモニターの確認
  if Screen.MonitorCount > 1 then
  begin
    FIsFullScreen := True;
    FScreenIndex := 1  // セカンドモニターをデフォルトに設定
  end
  else
  begin
    FIsFullScreen := False; // デフォルトはウィンドウモード
    FScreenIndex := 0; // プライマリモニターをデフォルトに設定
  end;

  FWindowTop := 100;
  FWindowLeft := 100;
  FWindowWidth := 800;
  FWindowHeight := 600;
  FBackgroundColor := clBlack; // デフォルトは黒色
end;

procedure TSettingLoader.ApplySettings;
begin
  FormSizeCustomizer.ScreenIndex := FScreenIndex;
  FormSizeCustomizer.IsFullScreen := FIsFullScreen;
  FormSizeCustomizer.SetOriginalSize(FWindowTop, FWindowLeft, FWindowWidth, FWindowHeight);
end;

procedure TSettingLoader.Load;
var
  SettingsFile: TIniFile;
begin
  if not FileExists(SETTINGS_FILE) then
  begin
    LoadDefaults;  // デフォルト値をロード
    Exit;
  end;

  SettingsFile := TIniFile.Create(SETTINGS_FILE);
  try
    FScreenIndex := SettingsFile.ReadInteger('Display', 'ScreenIndex', 0);
    FIsFullScreen := SettingsFile.ReadBool('Display', 'IsFullScreen', False);
    FWindowTop := SettingsFile.ReadInteger('Window', 'Top', 100);
    FWindowLeft := SettingsFile.ReadInteger('Window', 'Left', 100);
    FWindowWidth := SettingsFile.ReadInteger('Window', 'Width', 800);
    FWindowHeight := SettingsFile.ReadInteger('Window', 'Height', 600);
    FBackgroundColor := SettingsFile.ReadInteger('Display', 'BackgroundColor', clBlack);

    ValidateSettings; // 設定の妥当性を確認
    LoadFileList; // ファイルリストを読み込み
  finally
    SettingsFile.Free;
  end;
end;

procedure TSettingLoader.ValidateSettings;
var
  MonitorCount: Integer;
begin
  MonitorCount := Screen.MonitorCount;
  if (FScreenIndex < 0) or (FScreenIndex >= MonitorCount) then
  begin
    LoadDefaults;
  end;

end;

procedure TSettingLoader.CollectSettings;
begin
  // FormSizeCustomizer から現在の設定を取得
  FScreenIndex := FormSizeCustomizer.ScreenIndex;
  FIsFullScreen := FormSizeCustomizer.IsFullScreen;
  FormSizeCustomizer.BackupOriginal();
  FWindowTop := FormSizeCustomizer.WindowModeSize.Top;
  FWindowLeft := FormSizeCustomizer.WindowModeSize.Left;
  FWindowWidth := FormSizeCustomizer.WindowModeSize.Width;
  FWindowHeight := FormSizeCustomizer.WindowModeSize.Height;
end;

procedure TSettingLoader.CollectSettingsFromModel(AModel: TObject);
begin
  // 基本設定を収集
  CollectSettings;
  
  // モデルから背景色を取得（型キャストが必要）
  if AModel is TViewerModel then
  begin
    FBackgroundColor := TViewerModel(AModel).Background.Color;
  end;
end;

procedure TSettingLoader.Save;
var
  SettingsFile: TIniFile;
begin
  // 最新の設定を回収
  CollectSettings;

  // 設定を保存
  SettingsFile := TIniFile.Create(SETTINGS_FILE);
  try
    SettingsFile.WriteInteger('Display', 'ScreenIndex', FScreenIndex);
    SettingsFile.WriteBool('Display', 'IsFullScreen', FIsFullScreen);
    SettingsFile.WriteInteger('Display', 'BackgroundColor', FBackgroundColor);
    SettingsFile.WriteInteger('Window', 'Top', FWindowTop);
    SettingsFile.WriteInteger('Window', 'Left', FWindowLeft);
    SettingsFile.WriteInteger('Window', 'Width', FWindowWidth);
    SettingsFile.WriteInteger('Window', 'Height', FWindowHeight);

    SaveFileList; // ファイルリストを保存
  finally
    SettingsFile.Free;
  end;
end;


procedure TSettingLoader.LoadFileList;
var
  SettingsFile: TIniFile;
  i, Count: Integer;
  FilePath: String;
begin
  if not FileExists(SETTINGS_FILE) then Exit;
  
  SettingsFile := TIniFile.Create(SETTINGS_FILE);
  try
    Count := SettingsFile.ReadInteger('FileList', 'Count', 0);
    FFileList.Clear;
    FMissingFiles.Clear;
    
    for i := 0 to Count - 1 do
    begin
      FilePath := SettingsFile.ReadString('FileList', 'File' + IntToStr(i), '');
      if FilePath <> '' then
      begin
        if FileExists(FilePath) then
        begin
          FFileList.Add(FilePath);
        end
        else
        begin
          FMissingFiles.Add(FilePath);
        end;
      end;
    end;
  finally
    SettingsFile.Free;
  end;
end;

procedure TSettingLoader.SaveFileList;
var
  SettingsFile: TIniFile;
  i: Integer;
begin
  SettingsFile := TIniFile.Create(SETTINGS_FILE);
  try
    SettingsFile.WriteInteger('FileList', 'Count', FFileList.Count);
    
    for i := 0 to FFileList.Count - 1 do
    begin
      SettingsFile.WriteString('FileList', 'File' + IntToStr(i), FFileList[i]);
    end;
  finally
    SettingsFile.Free;
  end;
end;

function TSettingLoader.GetFileList: TStringList;
begin
  Result := FFileList;
end;

procedure TSettingLoader.SetFileList(AFileList: TStringList);
begin
  FFileList.Clear;
  FFileList.Assign(AFileList);
end;

function TSettingLoader.GetMissingFiles: TStringList;
begin
  Result := FMissingFiles;
end;

function TSettingLoader.GetBackgroundColor: TColor;
begin
  Result := FBackgroundColor;
end;

procedure TSettingLoader.SetBackgroundColor(AColor: TColor);
begin
  FBackgroundColor := AColor;
end;

end.


