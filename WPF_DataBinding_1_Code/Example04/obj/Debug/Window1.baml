   M S B A M L   `   `   `  ����D  @Example04, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Example04	Example04  5          Example04.Window1   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      6x,http://schemas.microsoft.com/winfx/2006/xaml   5      %localclr-namespace:Example04   5        � Title$  Window1��5      $	��200��6   $	��300��6"   $	��200��6.    � 	Resources 5         Example04.EmployeeList   myEmployeeList   Example04.Employee   EmployeeNumber   	FirstName   LastName   Title   
Department��%a  &	          5   
     5      $ 1��6   $
 John��60   $	 Dow��6A   $ 
Accountant��6P   $ Payroll��6c     5	      $ 2��6   $
 Jane��60   $ Austin��6A   $ Account Executive��6S   $ Customer Management��6m     5
      $ 3��6   $ Ralph��60   $ Emmerson��6B   $ 
QA Manager��6V   $ Product Development��6i     5      $ 4��6   $ Patrick��60   $ 
Fitzgerald��6D   $ 
QA Manager��6Z   $ Product Development��6m     5      $ 5��6   $ Charles��60   $ Dickens��6D   $ 
QA Manager��6W   $ Product Development��6j   5      5      .��5      �  � DataContext# [  6    � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $��* �6   .+�5   
   �� -   5        $��employeeListBox��5      $��0��6C   ��6*   �� 6C   � 5   
   $��1��6    6   �� 	 �� ElementName$	 employeeListBox��
 �� Path$
 SelectedItem� 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $��80 �6#   �� 5      $��* �6#   .+�5       �� $��0��6   $��0��6!   .��61   
First Name6=   �� 5!      $��1��6   $��0��6!   .��61   	Last Name6<   �� 5"      $��2��6   $��0��6!   .��61   Title68   �� 5#      $��3��6   $��0��6!   .��61   
Department6=   �� 5%      $��0��6   $��1��6#   ��63   �� $
 	FirstName��� 5&      $��1��6   $��1��6#   ��63   �� $
 LastName��� 5'      $��2��6   $��1��6#   ��63   �� $
 Title��� 5(      $��3��6   $��1��6#   ��63   �� $
 
Department�5)      5*      5+      