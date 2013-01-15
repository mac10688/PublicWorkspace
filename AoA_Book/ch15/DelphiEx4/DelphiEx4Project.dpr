program DelphiEx4Project;

uses
  Forms,
  DelphiEx4 in 'DelphiEx4.pas' {Form1};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
