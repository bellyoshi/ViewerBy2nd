# LibLoader Unit

このユニットは、DLLファイル（特にpdfium.dll）の存在をチェックするためのユーティリティクラスを提供します。

## 機能

- pdfium.dllの存在チェック
- 任意のDLLファイルの存在チェック
- 複数の検索パスでのDLL検索
- アーキテクチャ別フォルダ（x86/x64）での検索
- シングルトンパターンによるインスタンス管理

## 使用方法

### 基本的な使用方法

```pascal
uses libloaderunit;

var
  LibLoader: TLibLoader;
begin
  LibLoader := TLibLoader.Instance;
  
  if LibLoader.IsPdfiumDllAvailable then
    ShowMessage('pdfium.dllが見つかりました！')
  else
    ShowMessage('pdfium.dllが見つかりませんでした。');
end;
```

### 詳細な検索

```pascal
var
  LibLoader: TLibLoader;
  DllPath: string;
begin
  LibLoader := TLibLoader.Instance;
  
  // アプリケーションディレクトリのアーキテクチャ別フォルダで検索
  DllPath := LibLoader.FindDllInAppArchitectureFolder('pdfium.dll');
  if DllPath <> '' then
    ShowMessage('アプリケーションディレクトリのアーキテクチャ別フォルダで発見: ' + DllPath);
    
  // アプリケーションディレクトリで検索
  DllPath := LibLoader.FindDllInAppDir('pdfium.dll');
  if DllPath <> '' then
    ShowMessage('アプリケーションディレクトリで発見: ' + DllPath);
    
  // 現在のディレクトリのアーキテクチャ別フォルダで検索
  DllPath := LibLoader.FindDllInArchitectureFolder('pdfium.dll');
  if DllPath <> '' then
    ShowMessage('現在のディレクトリのアーキテクチャ別フォルダで発見: ' + DllPath);
    
  // 現在のディレクトリで検索
  DllPath := LibLoader.FindDllInCurrentDir('pdfium.dll');
  if DllPath <> '' then
    ShowMessage('現在のディレクトリで発見: ' + DllPath);
    
  // システムパスで検索
  DllPath := LibLoader.FindDllInSystemPath('pdfium.dll');
  if DllPath <> '' then
    ShowMessage('システムパスで発見: ' + DllPath);
end;
```

### 任意のDLLをチェック

```pascal
var
  LibLoader: TLibLoader;
begin
  LibLoader := TLibLoader.Instance;
  
  if LibLoader.IsDllAvailable('mycustom.dll') then
    ShowMessage('mycustom.dllが見つかりました！')
  else
    ShowMessage('mycustom.dllが見つかりませんでした。');
end;
```

## 検索順序

`IsDllAvailable`メソッドは以下の順序でDLLを検索します：

1. アプリケーションの実行ファイルと同じディレクトリのアーキテクチャ別フォルダ（x86/x64）
2. アプリケーションの実行ファイルと同じディレクトリ
3. 現在の作業ディレクトリのアーキテクチャ別フォルダ（x86/x64）
4. 現在の作業ディレクトリ
5. システムのPATH環境変数に含まれるディレクトリ

## アーキテクチャ別フォルダ

- **64ビットアプリケーション**: `x64`フォルダを検索
- **32ビットアプリケーション**: `x86`フォルダを検索

例：
- `C:\MyApp\x64\pdfium.dll` (64ビットアプリケーション用)
- `C:\MyApp\x86\pdfium.dll` (32ビットアプリケーション用)

## メソッド一覧

### 主要メソッド

- `IsPdfiumDllAvailable: Boolean` - pdfium.dllの存在をチェック
- `IsDllAvailable(const DllName: string): Boolean` - 指定されたDLLの存在をチェック
- `IsDllAvailableInPath(const DllName, Path: string): Boolean` - 指定されたパスでDLLの存在をチェック

### 検索メソッド

- `FindDllInAppArchitectureFolder(const DllName: string): string` - アプリケーションディレクトリのアーキテクチャ別フォルダからDLLを検索
- `FindDllInAppDir(const DllName: string): string` - アプリケーションディレクトリからDLLを検索
- `FindDllInArchitectureFolder(const DllName: string): string` - 現在のディレクトリのアーキテクチャ別フォルダからDLLを検索
- `FindDllInCurrentDir(const DllName: string): string` - 現在のディレクトリからDLLを検索
- `FindDllInSystemPath(const DllName: string): string` - システムパスからDLLを検索

## 注意事項

- このユニットはWindows専用です（Windowsユニットを使用）
- シングルトンパターンを使用しているため、複数のインスタンスは作成されません
- ファイルの存在チェックのみを行い、実際のDLLロードは行いません
- アーキテクチャ別フォルダは、コンパイル時のターゲットアーキテクチャに基づいて自動的に選択されます

## 使用例

詳細な使用例については、`libloader_example.pas`を参照してください。 