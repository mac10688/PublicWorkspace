unit DelphiEx5;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls;

type
  TDataTable = class(TForm)
    GetDataBtn: TButton;
    DataLabel: TLabel;
    procedure GetDataBtnClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

 // Here's a static variable that we will export to
 // the HLA source code (in Delphi, structured constants
 // are initialized static variables).

const
    y:integer = 12345;

var
  DataTable: TDataTable;

  // Here's the function we will export to the HLA code:

  function callme:integer;

implementation

{$R *.DFM}
{$L TableData.obj }

function TableData:integer; external;

// This function will simply return 10 as the function
// result (remember, function results come back in EAX).

function callme;
begin

    callme := 10;

end;


procedure TDataTable.GetDataBtnClick(Sender: TObject);
var
    strVal: string;
    yVal:   string;
begin

    // Display the value that TableData returns.
    // Also display the value of y, which TableValue modifies
    
    str( TableData(), strVal );
    str( y, yVal );
    DataLabel.caption := 'Data = ' + strVal + ' y=' + yVal;

end;

end.

