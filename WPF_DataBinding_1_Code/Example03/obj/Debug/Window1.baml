   M S B A M L   `   `   `  ����D  @Example03, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Example03	Example03  5          Example03.Window1   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      6x,http://schemas.microsoft.com/winfx/2006/xaml   5      %localclr-namespace:Example03   5        � Title$  
Example 03��5      $	��150��6   $	��300��6%    � 	Resources 5         Example03.Employee   
MyEmployee   EmployeeNumber   	FirstName   LastName   
Department   Title��%{   &	          5   
   $	 123��6,   $
 John��6A   $	 Doe��6R   $ Product Development��6a   $ 
QA Manager��6�   5      .��5	      �  � DataContext# [  6    � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   	 � ColumnDefinitions	 5   
   �� 5      $��130px �6   �� 5      $
��178* �6   .+�5   
   �� $��0��6   $��0��6   .��6-   Employee Number6>   �� 5   
   $��0��6   $��1��6   ��6/   �� 
 �� Path$
 EmployeeNumber�6V   �� 5   
   $��1��6   $��0��6   .��6-   
First Name69   �� 5   
   $��1��6   $��1��6   ��6/   �� $
 	FirstName�6Q   �� 5   
   $��2��6   $��0��6   .��6-   	Last Name68   �� 5   
   $��2��6   $��1��6   ��6/   �� $
 LastName��� 5   
   $��3��6   $��0��6   .��6-   Title64   �� 5   
   $��3��6   $��1��6   ��6/   �� $
 Title�6M   �� 5!   
   $��4��6   $��0��6   .��6-   
Department69   �� 5"   
   $��4��6   $��1��6   ��6/   �� $
 
Department�5#      5%      