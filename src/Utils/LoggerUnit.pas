unit LoggerUnit;

{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, DateUtils, TypInfo;

type
  TLogLevel = (llDebug, llInfo, llWarning, llError);

  TLogger = class
  private
    FLogLevel: TLogLevel;
    FLogFile: string;
    FLogToFile: Boolean;
    FLogToConsole: Boolean;
    FIndentLevel: Integer;
    FIndentString: string;
    
    procedure WriteLog(const AMessage: string; ALevel: TLogLevel);
    function GetIndentString: string;
  public
    constructor Create;
    destructor Destroy; override;
    
    // 基本ログ機能
    procedure Debug(const AMessage: string);
    procedure Info(const AMessage: string);
    procedure Warning(const AMessage: string);
    procedure Error(const AMessage: string);
    
    // 時間計測機能
    procedure StartTimer(const ATimerName: string);
    procedure EndTimer(const ATimerName: string);
    procedure LogTimer(const ATimerName: string; AElapsedMs: Integer);
    
    // セクション機能
    procedure BeginSection(const ASectionName: string);
    procedure EndSection(const ASectionName: string);
    
    // 設定
    procedure SetLogLevel(ALevel: TLogLevel);
    procedure SetLogFile(const AFileName: string);
    procedure SetLogToFile(AEnabled: Boolean);
    procedure SetLogToConsole(AEnabled: Boolean);
    
    property LogLevel: TLogLevel read FLogLevel write SetLogLevel;
    property LogFile: string read FLogFile write SetLogFile;
    property LogToFile: Boolean read FLogToFile write SetLogToFile;
    property LogToConsole: Boolean read FLogToConsole write SetLogToConsole;
  end;

var
  Logger: TLogger;

implementation

uses
  Forms;

type
  TTimerInfo = record
    StartTime: TDateTime;
    Name: string;
  end;

var
  FTimers: array of TTimerInfo;

constructor TLogger.Create;
begin
  inherited Create;
  FLogLevel := llInfo;
  FLogToFile := True;
  FLogToConsole := True;
  FIndentLevel := 0;
  FIndentString := '';
  SetLength(FTimers, 0);
end;

destructor TLogger.Destroy;
begin
  inherited Destroy;
end;

procedure TLogger.WriteLog(const AMessage: string; ALevel: TLogLevel);
var
  LogMessage: string;
  LogStream: TFileStream;
begin
  if ALevel < FLogLevel then
    Exit;
    
  LogMessage := Format('[%s] [%s] %s%s', [
    FormatDateTime('yyyy-mm-dd hh:nn:ss.zzz', Now),
    Copy(GetEnumName(TypeInfo(TLogLevel), Ord(ALevel)), 3, MaxInt),
    GetIndentString,
    AMessage
  ]);
    
  // ファイル出力
  if FLogToFile and (FLogFile <> '') then
  begin
    try
      if FileExists(FLogFile) then
        LogStream := TFileStream.Create(FLogFile, fmOpenWrite or fmShareDenyWrite)
      else
        LogStream := TFileStream.Create(FLogFile, fmCreate);
      try
        LogStream.Seek(0, soEnd);
        LogStream.WriteBuffer(PChar(LogMessage + LineEnding)^, Length(LogMessage + LineEnding));
      finally
        LogStream.Free;
      end;
    except
      // ファイル書き込みエラーは無視
    end;
  end;
end;

function TLogger.GetIndentString: string;
begin
  Result := StringOfChar(' ', FIndentLevel * 2);
end;

procedure TLogger.Debug(const AMessage: string);
begin
  WriteLog(AMessage, llDebug);
end;

procedure TLogger.Info(const AMessage: string);
begin
  WriteLog(AMessage, llInfo);
end;

procedure TLogger.Warning(const AMessage: string);
begin
  WriteLog(AMessage, llWarning);
end;

procedure TLogger.Error(const AMessage: string);
begin
  WriteLog(AMessage, llError);
end;

procedure TLogger.StartTimer(const ATimerName: string);
var
  i: Integer;
  TimerInfo: TTimerInfo;
begin
  // 既存のタイマーを検索
  for i := 0 to High(FTimers) do
  begin
    if FTimers[i].Name = ATimerName then
    begin
      FTimers[i].StartTime := Now;
      Debug(Format('タイマー再開: %s', [ATimerName]));
      Exit;
    end;
  end;
  
  // 新しいタイマーを追加
  TimerInfo.Name := ATimerName;
  TimerInfo.StartTime := Now;
  SetLength(FTimers, Length(FTimers) + 1);
  FTimers[High(FTimers)] := TimerInfo;
  Debug(Format('タイマー開始: %s', [ATimerName]));
end;

procedure TLogger.EndTimer(const ATimerName: string);
var
  i: Integer;
  ElapsedMs: Integer;
begin
  for i := 0 to High(FTimers) do
  begin
    if FTimers[i].Name = ATimerName then
    begin
      ElapsedMs := MilliSecondsBetween(Now, FTimers[i].StartTime);
      LogTimer(ATimerName, ElapsedMs);
      
      // タイマーを削除
      if i < High(FTimers) then
        FTimers[i] := FTimers[High(FTimers)];
      SetLength(FTimers, Length(FTimers) - 1);
      Exit;
    end;
  end;
  
  Warning(Format('タイマーが見つかりません: %s', [ATimerName]));
end;

procedure TLogger.LogTimer(const ATimerName: string; AElapsedMs: Integer);
begin
  Info(Format('タイマー完了: %s - %d ミリ秒', [ATimerName, AElapsedMs]));
end;

procedure TLogger.BeginSection(const ASectionName: string);
begin
  Info(Format('=== %s 開始 ===', [ASectionName]));
  Inc(FIndentLevel);
end;

procedure TLogger.EndSection(const ASectionName: string);
begin
  Dec(FIndentLevel);
  Info(Format('=== %s 完了 ===', [ASectionName]));
end;

procedure TLogger.SetLogLevel(ALevel: TLogLevel);
begin
  FLogLevel := ALevel;
end;

procedure TLogger.SetLogFile(const AFileName: string);
begin
  FLogFile := AFileName;
end;

procedure TLogger.SetLogToFile(AEnabled: Boolean);
begin
  FLogToFile := AEnabled;
end;

procedure TLogger.SetLogToConsole(AEnabled: Boolean);
begin
  FLogToConsole := AEnabled;
end;

initialization
  Logger := TLogger.Create;

finalization
  if Assigned(Logger) then
    Logger.Free;

end. 
