   M S B A M L   `   `   `  ����J  FWpfApplication7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfApplication7.ViewWpfApplication7.View  5   	   )    #WpfApplication7.View.AddStudentView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfApplication7.View     5   	     � Title$  AddStudentView��5   	   $	��300��6    $	��300��6-    � DataContext 5	   	   �� *
AddStudent+   Locator �� Source# [  .��5
      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��0��6   $��学号��6-   $��Right=�6:   $��Center=�6V   6s   �� 5   
   $��1��6   $��0��6   $��姓名��6-   $��Right=�6:   $��Center=�6V   6s   �� 5   
   $��2��6   $��0��6   $��班级��6-   $��Right=�6:   $��Center=�6V   6s   �� 5   
   $��3��6   $��0��6   $��年龄��6-   $��Right=�6:   $��Center=�6V   6s   �� 5   
   $��4��6   $��0��6   $��性别��6-   $��Right=�6:   $��Center=�6V   6s   �� 5   
   -   5        $��txtID��5      $��0��6   $��1��6,   ��6<   �� *Stu_id+ �� Mode$ TwoWay=� �� NotifyOnTargetUpdated . 6}   �� 5   
   -   5        $��txtName��5      $��1��6!   $��1��6.   ��6>   �� *
Stu_name+$ TwoWay=� . 6�   �� 5   
   $��2��6   $��1��6     �� DisplayMemberPath$ 	Stu_class��6�    �� SelectedValuePath$ Class_id��6�   ��60   �� *	comboList+$ TwoWay=� . 	 �� Text	 6y   �� *	Stu_class+6�   �� 5   
   -   5        $��txtAge��5      $��3��6    $��1��6-   ��6=   �� *	Stu_age+$ TwoWay=� . 6   �� 5    
   -   5        $��	txtGender��5       $��4��6#   $��1��60   ��6@   �� *
Stu_gender+$ TwoWay=� . 6�   �� 5!   
   $��4��6   $��0��6!   $��2��61   
���   �$��1��6R   $��Bottom=�6]   6z   �� 5"   
   $��保存��6   $��80��6   $��30��6)   $��5��65   $��1��6B   ��6R   �� *SaveCommand+6t   5#      5$      