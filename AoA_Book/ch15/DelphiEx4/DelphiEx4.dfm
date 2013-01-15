object Form1: TForm1
  Left = 192
  Top = 107
  Width = 318
  Height = 131
  Caption = 'Calls UsesPascal'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object UsesRegisterLabel: TLabel
    Left = 128
    Top = 32
    Width = 102
    Height = 13
    Caption = 'Uses Register = ????'
  end
  object callUsesRegisterBtn: TButton
    Left = 16
    Top = 24
    Width = 97
    Height = 25
    Caption = 'Calls UsesRegister'
    TabOrder = 0
    OnClick = callUsesRegisterBtnClick
  end
end
