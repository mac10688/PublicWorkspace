program DelphiEx3Project;

uses
  Forms,
  DelphiEx3 in 'DelphiEx3.pas' {Form1};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
