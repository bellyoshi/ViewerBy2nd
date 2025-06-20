unit MessageFormUnit;

{$mode ObjFPC}{$H+}

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, StdCtrls;

type
  TMessageForm = class(TForm)
    Memo1: TMemo;
    Button1: TButton;
    procedure FormCreate(Sender: TObject);
  private
    FMessage: string;
  public
    procedure SetMessage(const AMessage: string);
    property Message: string read FMessage write SetMessage;
  end;

var
  MessageForm: TMessageForm;

implementation

{$R *.lfm}

procedure TMessageForm.FormCreate(Sender: TObject);
begin
  FMessage := '';
end;

procedure TMessageForm.SetMessage(const AMessage: string);
begin
  FMessage := AMessage;
  if Assigned(Memo1) then
    Memo1.Text := FMessage;
end;

end.

