unit DelphiEx2;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls;

type
  TDelphiEx2Form = class(TForm)
    BoolBtn: TButton;
    BooleanLabel: TLabel;
    WordBtn: TButton;
    WordLabel: TLabel;
    DWordBtn: TButton;
    DWordLabel: TLabel;
    PtrBtn: TButton;
    PCharLabel: TLabel;
    FltBtn: TButton;
    RealLabel: TLabel;
    procedure BoolBtnClick(Sender: TObject);
    procedure WordBtnClick(Sender: TObject);
    procedure DWordBtnClick(Sender: TObject);
    procedure PtrBtnClick(Sender: TObject);
    procedure FltBtnClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  DelphiEx2Form: TDelphiEx2Form;

implementation

{$R *.DFM}

// Here's the directive that tells Delphi to link in our
// HLA code.

{$L ReturnBoolean.obj }
{$L ReturnWord.obj }
{$L ReturnDWord.obj }
{$L ReturnPtr.obj }
{$L ReturnReal.obj }

// Here are the external function declarations:

function ReturnBoolean:boolean; external;
function ReturnWord:smallint; external;
function ReturnDWord:integer; external;
function ReturnPtr:pchar; external;
function ReturnReal:real; external;


// Demonstration of calling an assembly language
// procedure that returns a byte (boolean) result.

procedure TDelphiEx2Form.BoolBtnClick(Sender: TObject);
var
    b:boolean;

begin

    // Call the assembly code and return its result:

    b := ReturnBoolean;

    // Display "true" or "false" depending on the return result.

    if( b ) then

        booleanLabel.caption := 'Boolean result = true '

    else

        BooleanLabel.caption := 'Boolean result = false';

end;


// Demonstrate calling an assembly language function that
// returns a word result.

procedure TDelphiEx2Form.WordBtnClick(Sender: TObject);
var
    si:smallint;    // Return result here.
    strVal:string;  // Used to display return result.
begin

    si := ReturnWord();     // Get result from assembly code.
    str( si, strVal );      // Convert result to a string.
    WordLabel.caption := 'Word Result = ' + strVal;

end;

// Demonstration of a call to an assembly language routine
// that returns a 32-bit result in EAX:

procedure TDelphiEx2Form.DWordBtnClick(Sender: TObject);
var
    i:integer;          // Return result goes here.
    strVal:string;      // Used to display return result.
begin

    i := ReturnDWord(); // Get result from assembly code.
    str( i, strVal );   // Convert that value to a string.
    DWordLabel.caption := 'Double Word Result = ' + strVal;

end;


// Demonstration of a routine that returns a pointer
// as the function result.  This demo is kind of lame
// because we can't initialize anything inside the
// assembly module, but it does demonstrate the mechanism
// even if this example isn't very practical.

procedure TDelphiEx2Form.PtrBtnClick(Sender: TObject);
var
    p:pchar;    // Put returned pointer here.
begin

    // Get the pointer (to a zero byte) from the assembly code.

    p := ReturnPtr();

    // Display the empty string that ReturnPtr returns.

    PCharLabel.caption := 'PChar Result = "' + p + '"';

end;


// Quick demonstration of a function that returns a
// floating point value as a function result.

procedure TDelphiEx2Form.FltBtnClick(Sender: TObject);
var
    r:real;
    strVal:string;
begin

    // Call the assembly code that returns a real result.

    r := ReturnReal();      // Always returns 1.0

    // Convert and display the result.
    
    str( r:13:10, strVal );
    RealLabel.caption := 'Real Result = ' + strVal;

end;

end.
