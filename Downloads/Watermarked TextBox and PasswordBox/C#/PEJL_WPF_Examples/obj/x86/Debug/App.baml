   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5      L HPEJL_WPF_Examples, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PEJL_WPF_ExamplesPEJL_WPF_Examples 5         PEJL_WPF_Examples.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      oMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     5      1localclr-namespace:PEJL_WPF_Examples     5        �� 	Resources  5          BooleanToVisibilityConverter " WatermarkedPasswordBoxTemplate �� 
TargetType,   &Microsoft.Windows.Themes.ListBoxChrome  Name   BorderBrush   BorderThickness   
Background J� IsMouseOver   RenderMouseOver J� IsKeyboardFocusWithin	   RenderFocused
 J� SnapsToDevicePixels J� Opacity �� Path �� RelativeSource �� 	Converter ��Name �� Triggers P� Property P� Value �� 
TargetName �� Value �� Property  WatermarkedTextBoxTemplate��%�  &	        &	      7   &	 b    7   �� 5   
   6'   �� 5
   
   " G�6A   .R�5        $ Bd��65   # z��6A   # z��6m   # z��6�   # z 6�   #	 z 6�   
 . ._�5      � .+�5      �� $ .5Q�6�   $
��Bold"�6�   ��6    �� $) #(local:PasswordBoxHelper.Watermark)� �� *TemplatedParent+y�6�   �� *)'(local:PasswordBoxHelper.ShowWatermark)+8    �� *TemplatedParent+�� 5      $ PART_ContentHost��6#   #
 z
 6=   5      5       5      P� 5       � {� .  . �5      �� $ Bd��63   # � ��6C    �@ 
Background�� 5      # � ��63    � ��5      5      �� 5   
   " ��6=   .R�5        $ Bd��65   # z��6A   # z��6m   # z��6�   # z 6�   #	 z 6�   
 . ._�5      � .+�5      �� $ .5Q�6�   $
��Bold"�6�   ��6    �� $% (local:TextBoxHelper.Watermark)� �� *TemplatedParent+y�6�   �� *%#(local:TextBoxHelper.ShowWatermark)+8    �� *TemplatedParent+�� 5      $ PART_ContentHost��6#   #
 z
 6=   5      5       5       P� 5!       � {� .  . �5"      �� $ Bd��63   # � ��6C    �@ 
Background�� 5#      # � ��63    � ��5$      5&      5(      5)      