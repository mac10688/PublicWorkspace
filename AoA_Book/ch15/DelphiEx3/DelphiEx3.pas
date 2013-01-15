unit DelphiEx3;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls;

type
  TForm1 = class(TForm)
    callUsesPascalBtn: TButton;
    UsesPascalLabel: TLabel;
    procedure callUsesPascalBtnClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}
{$L usespascal.obj}

function UsesPascal
(
    parm1:integer;
    parm2:integer;
    parm3:integer
):integer; pascal; external;

procedure TForm1.callUsesPascalBtnClick(Sender: TObject);
var
    i:      integer;
    strVal: string;
begin

    i := UsesPascal( 5, 6, 7 );
    str( i, strVal );
    UsesPascalLabel.caption := 'Uses Pascal = ' + strVal;

end;

end.
 
