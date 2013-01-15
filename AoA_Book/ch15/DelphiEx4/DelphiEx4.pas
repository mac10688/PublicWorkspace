unit DelphiEx4;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls;

type
  TForm1 = class(TForm)
    callUsesRegisterBtn: TButton;
    UsesRegisterLabel: TLabel;
    procedure callUsesRegisterBtnClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}
{$L usesregister.obj}

function UsesRegister
(
    parm1:integer;
    parm2:integer;
    parm3:integer;
    parm4:integer
):integer; external;

procedure TForm1.callUsesRegisterBtnClick(Sender: TObject);
var
    i:      integer;
    strVal: string;
begin

    i := UsesRegister( 5, 6, 7, 3 );
    str( i, strVal );
    UsesRegisterLabel.caption := 'Uses Register = ' + strVal;

end;

end.
 
