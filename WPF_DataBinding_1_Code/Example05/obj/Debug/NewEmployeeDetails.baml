   M S B A M L   `   `   `  ����D  @Example05, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Example05	Example05  5      "    Example05.NewEmployeeDetails   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      6x,http://schemas.microsoft.com/winfx/2006/xaml   5      %localclr-namespace:Example05   5      -   5          � Title$  NewEmployeeDetails��5      $	��182��6    $	��304��6-   $	��220��69   $	��220��6I    � 	Resources 5         Example05.Employee   NewEmployee��%   &	          5   
   6   5	      .��5      �  � DataContext# [  6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $	��120 �6   6-   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   .��6-   Employee Number6>   �� 5   
   $��1��6   $��0��6   .��6-   
First Name69   �� 5   
   $��2��6   $��0��6   .��6-   	Last Name68   �� 5   
   $��3��6   $��0��6   .��6-   Title64   �� 5   
   $��4��6   $��0��6   .��6-   
Department69   �� 5   
   -   5        $��txtEmployeeNumber��5   /   $��0��6   $��1��6   ��6H   ��  �� Path$ EmployeeNumber��� 5    
   -   5        $��txtFirstName��5    /   $��1��6   $��1��6   ��6C   �� *	FirstName+�� 5!   
   -   5        $��txtLastName��5!   /   $��2��6   $��1��6   ��6B   �� *
LastName+�� 5"   
   -   5        $��txtTitle��5"   /   $��3��6   $��1��6   ��6?   �� *Title+�� 5#   
   -   5        $��txtDepartment��5#   /   $��4��6   $��1��6   ��6D   �� *
Department+�� 5$   
   -   5        $��5��5$      $��0��6   $��2��6.   .��6W   Save6]   5%      5&      