object DataTable: TDataTable
  Left = 192
  Top = 107
  Width = 264
  Height = 198
  Caption = 'Static Table Data Demo'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object DataLabel: TLabel
    Left = 104
    Top = 40
    Width = 59
    Height = 13
    Caption = 'Data = ????'
  end
  object GetDataBtn: TButton
    Left = 16
    Top = 32
    Width = 75
    Height = 25
    Caption = 'Get Data'
    TabOrder = 0
    OnClick = GetDataBtnClick
  end
end
