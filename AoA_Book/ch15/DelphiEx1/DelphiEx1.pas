unit DelphiEx1;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls;

type
  TDelphiEx1Form = class(TForm)
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  DelphiEx1Form: TDelphiEx1Form;

implementation

{$R *.DFM}
{$L CalledFromDelphi.obj }

procedure CalledFromDelphi; external;

procedure TDelphiEx1Form.Button1Click(Sender: TObject);
begin

    CalledFromDelphi();

end;

end.
