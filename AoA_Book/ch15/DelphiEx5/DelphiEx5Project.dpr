program DelphiEx5Project;

uses
  Forms,
  DelphiEx5 in 'DelphiEx5.pas' {DataTable};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TDataTable, DataTable);
  Application.Run;
end.
