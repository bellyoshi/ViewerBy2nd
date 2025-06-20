unit libloaderunit;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, Windows;

type
  TLibLoader = class
  private
   function GetArchitectureFolder: string;
  public
    constructor Create;
    destructor Destroy; override;
    
    // pdfium.dllの存在をチェック
    function IsPdfiumDllAvailable: Boolean;
    
    // 指定されたDLLの存在をチェック
    function IsDllAvailable(const DllName: string): Boolean;
    
    // 指定されたパスでDLLの存在をチェック
    function IsDllAvailableInPath(const DllName, Path: string): Boolean;
    
    // アーキテクチャ別フォルダからDLLを検索
    function FindDllInArchitectureFolder(const DllName: string): string;
    
    // アプリケーションディレクトリのアーキテクチャ別フォルダからDLLを検索
    function FindDllInAppArchitectureFolder(const DllName: string): string;
    

  end;

var
  LibLoader : TLibLoader;

implementation

{ TLibLoader }

constructor TLibLoader.Create;
begin
  inherited Create;
end;

destructor TLibLoader.Destroy;
begin
  inherited Destroy;
end;

function TLibLoader.GetArchitectureFolder: string;
begin
  {$IFDEF CPU64}
  Result := 'x64';
  {$ELSE}
  Result := 'x86';
  {$ENDIF}
end;

function TLibLoader.IsPdfiumDllAvailable: Boolean;
begin
  Result := IsDllAvailable('pdfium.dll');
end;

function TLibLoader.IsDllAvailable(const DllName: string): Boolean;
var
  DllPath: string;
begin
  Result := False;
  
  // アプリケーションの実行ファイルと同じディレクトリのアーキテクチャ別フォルダをチェック
  DllPath := FindDllInAppArchitectureFolder(DllName);
  if DllPath <> '' then
  begin
    Result := True;
    Exit;
  end;

end;

function TLibLoader.IsDllAvailableInPath(const DllName, Path: string): Boolean;
var
  FullPath: string;
begin
  FullPath := IncludeTrailingPathDelimiter(Path) + DllName;
  Result := FileExists(FullPath);
end;



function TLibLoader.FindDllInArchitectureFolder(const DllName: string): string;
var
  ArchFolder: string;
  FullPath: string;
begin
  Result := '';
  ArchFolder := GetArchitectureFolder;
  FullPath := IncludeTrailingPathDelimiter(GetCurrentDir) + 
              IncludeTrailingPathDelimiter(ArchFolder) + DllName;
  if FileExists(FullPath) then
    Result := FullPath;
end;

function TLibLoader.FindDllInAppArchitectureFolder(const DllName: string): string;
var
  ArchFolder: string;
  FullPath: string;
begin
  Result := '';
  ArchFolder := GetArchitectureFolder;
  FullPath := IncludeTrailingPathDelimiter(ExtractFilePath(ParamStr(0))) + 
              IncludeTrailingPathDelimiter(ArchFolder) + DllName;
  if FileExists(FullPath) then
    Result := FullPath;
end;

initialization
  LibLoader := TLibLoader.Create;

finalization
  if Assigned(LibLoader) then
    LibLoader.Free;

end. 
