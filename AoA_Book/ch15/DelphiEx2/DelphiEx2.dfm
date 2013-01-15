object DelphiEx2Form: TDelphiEx2Form
  Left = 205
  Top = 234
  Width = 309
  Height = 311
  Caption = 'Delphi Example #2: Function Results'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object BooleanLabel: TLabel
    Left = 128
    Top = 48
    Width = 103
    Height = 13
    Caption = 'Boolean result = ????'
  end
  object WordLabel: TLabel
    Left = 128
    Top = 88
    Width = 95
    Height = 13
    Caption = 'Word Result = ????'
  end
  object DWordLabel: TLabel
    Left = 128
    Top = 128
    Width = 132
    Height = 13
    Caption = 'Double Word Result = ????'
  end
  object PCharLabel: TLabel
    Left = 128
    Top = 168
    Width = 98
    Height = 13
    Caption = 'PChar Result = ????'
  end
  object RealLabel: TLabel
    Left = 128
    Top = 208
    Width = 91
    Height = 13
    Caption = 'Real Result = ????'
  end
  object BoolBtn: TButton
    Left = 32
    Top = 40
    Width = 75
    Height = 25
    Caption = 'Boolean'
    TabOrder = 0
    OnClick = BoolBtnClick
  end
  object WordBtn: TButton
    Left = 32
    Top = 80
    Width = 75
    Height = 25
    Caption = 'Word'
    TabOrder = 1
    OnClick = WordBtnClick
  end
  object DWordBtn: TButton
    Left = 32
    Top = 120
    Width = 75
    Height = 25
    Caption = 'DWord'
    TabOrder = 2
    OnClick = DWordBtnClick
  end
  object PtrBtn: TButton
    Left = 32
    Top = 160
    Width = 75
    Height = 25
    Caption = 'Pointer'
    TabOrder = 3
    OnClick = PtrBtnClick
  end
  object FltBtn: TButton
    Left = 32
    Top = 200
    Width = 75
    Height = 25
    Caption = 'Real'
    TabOrder = 4
    OnClick = FltBtnClick
  end
end
