   M S B A M L   `   `   `  ����D  @Example06, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Example06	Example06  5          Example06.Window1   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      6x,http://schemas.microsoft.com/winfx/2006/xaml   5      %localclr-namespace:Example06   5        � Title$  Temperature Converter��5      $	��109��6#   $	��273��60    � 	Resources 5      ,   &Example06.FahrenheitToCelciusConverter   myTemperatureConverter+   %Example06.TemperatureToColorConverter  myFRangeIndicator   HotTemperature   ColdTemperature  myCRangeIndicator��%�   &	        &	      &	 =       5   
   6-     5   
   $ 80Q�6F   $ 65Q�6Z     5	   
   $
 26.6Q�6F   $
 18.8Q�6\   5
      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��35 �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   5      �� 5      $	��150 �6   .+�5   
   �� $��0��6   $��0��6   .��6-   
Fahrenheit69   �� 5   
   $��1��6   $��0��6   .��6-   	Celcius66   �� 5   
   -   5        $��txtFahrenheit��5   /   $��0��6   $��1��6   ��5      ��  �� Path$
 Text� �� ElementName$ txtFahrenheit�� �� 	Converter# [ 5      �� 5   
   -   5        $��
txtCelcius��5   /   $��1��6   $��1��6   ��5      �� 	 �� UpdateSourceTrigger$	 PropertyChanged=�$
 Text�$ txtFahrenheit��# [  ��5      �� $
 Text�$ 
txtCelcius��# [ .��5      5      5      5"      