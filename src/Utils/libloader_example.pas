unit libloader_example;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, Forms, Dialogs, libloaderunit;

procedure CheckPdfiumDllExample;

implementation

procedure CheckPdfiumDllExample;
var
  LibLoader: TLibLoader;
  DllPath: string;
  ArchFolder: string;
begin
  LibLoader := TLibLoader.Instance;
  
  // pdfium.dllの存在をチェック
  if LibLoader.IsPdfiumDllAvailable then
  begin
    ShowMessage('pdfium.dllが見つかりました！');
    
    // 見つかった場所を特定（優先順位順）
    DllPath := LibLoader.FindDllInAppArchitectureFolder('pdfium.dll');
    if DllPath <> '' then
      ShowMessage('アプリケーションディレクトリのアーキテクチャ別フォルダで発見: ' + DllPath)
    else
    begin
      DllPath := LibLoader.FindDllInAppDir('pdfium.dll');
      if DllPath <> '' then
        ShowMessage('アプリケーションディレクトリで発見: ' + DllPath)
      else
      begin
        DllPath := LibLoader.FindDllInArchitectureFolder('pdfium.dll');
        if DllPath <> '' then
          ShowMessage('現在のディレクトリのアーキテクチャ別フォルダで発見: ' + DllPath)
        else
        begin
          DllPath := LibLoader.FindDllInCurrentDir('pdfium.dll');
          if DllPath <> '' then
            ShowMessage('現在のディレクトリで発見: ' + DllPath)
          else
          begin
            DllPath := LibLoader.FindDllInSystemPath('pdfium.dll');
            if DllPath <> '' then
              ShowMessage('システムパスで発見: ' + DllPath);
          end;
        end;
      end;
    end;
  end
  else
  begin
    ArchFolder := '';
    {$IFDEF CPU64}
    ArchFolder := 'x64';
    {$ELSE}
    ArchFolder := 'x86';
    {$ENDIF}
    
    ShowMessage('pdfium.dllが見つかりませんでした。' + #13#10 +
                '以下の場所を確認してください:' + #13#10 +
                '1. アプリケーションの実行ファイルと同じディレクトリの' + ArchFolder + 'フォルダ' + #13#10 +
                '2. アプリケーションの実行ファイルと同じディレクトリ' + #13#10 +
                '3. 現在の作業ディレクトリの' + ArchFolder + 'フォルダ' + #13#10 +
                '4. 現在の作業ディレクトリ' + #13#10 +
                '5. システムのPATH環境変数に含まれるディレクトリ');
  end;
  
  // 他のDLLもチェック可能
  if LibLoader.IsDllAvailable('kernel32.dll') then
    ShowMessage('kernel32.dllは利用可能です')
  else
    ShowMessage('kernel32.dllが見つかりません（通常はありえない）');
    
  // アーキテクチャ別フォルダの検索例
  DllPath := LibLoader.FindDllInAppArchitectureFolder('pdfium.dll');
  if DllPath <> '' then
    ShowMessage('アーキテクチャ別フォルダでpdfium.dllを発見: ' + DllPath)
  else
    ShowMessage('アーキテクチャ別フォルダにpdfium.dllはありません');
end;

end. 