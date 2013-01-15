program DelphEx1Project;

uses
  Forms,
  DelphiEx1 in 'DelphiEx1.pas' {DelphiEx1Form};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TDelphiEx1Form, DelphiEx1Form);
  Application.Run;
end.
