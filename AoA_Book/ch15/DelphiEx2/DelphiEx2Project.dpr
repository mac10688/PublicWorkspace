program DelphiEx2Project;

uses
  Forms,
  DelphiEx2 in 'DelphiEx2.pas' {DelphiEx2Form};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TDelphiEx2Form, DelphiEx2Form);
  Application.Run;
end.
