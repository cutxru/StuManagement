   M S B A M L   `   `   `  ����J  FWpfApplication7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication7WpfApplication7  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	        WpfApplication7.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication7     5   	   b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1+mvvm http://www.galasoft.ch/mvvmlight  5   
   XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5   	     � Title$  
MainWindow��5
   	   $	��350��6   $	��525��6)    � DataContext 5   	   �� *Main+   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��30��6;   $��0,0,-56.962,9.849q�6G   .+�5      �� $��
10,10,10,5q�6   班级60   �� 5      -   5        $��comboBox��5   "   $��80��6   $	��0,5q�62    �� DisplayMemberPath$ 	Stu_class��5       �� SelectedValuePath$ Class_id��65   ��5   @   �� *	comboList+ �� Mode$ TwoWay=� �� NotifyOnTargetUpdated . 	 �� SelectedItem	 5   R   �� *
Selected+.  (System.Windows.Interactivity.Interaction
   Triggers
 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ SelectionChanged��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 6.   �� *ComboBox_SelectionChanged+5      5      �� 5      $
��20,0q�64   ��6   �� *
AddStudent+.��6B   添加学生6H   �� 5      $
��20,0q�62   ��6   �� *
AddClass+.��6@   添加班级6F   �� 5      $
��20,0q�60   ��6   �� *Delete+.��6>   删除学生6D   �� 5      $
��20,0q�60   ��6   �� *Update+.��6>   修改信息6D   5!      &   System.Windows.Controls.DataGrid  5"   
   $��1��6      AutoGenerateColumns .  ��6=   �� *list+	 5#      �� *SelectStudentEntity+$ TwoWay=�   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ 学号��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61      
IsReadOnly . 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6;   �� *Stu_id+$ TwoWay=�6v     5&      $ 姓名��6%   $ * 61    6;   �� *
Stu_name+$ TwoWay=�6f     5'      $ 班级��6%   $ * 61    6;   �� *	Stu_class+$ TwoWay=�6g     5(      $ 年龄��6%   $ * 61    6;   �� *	Stu_age+$ TwoWay=�6e     5)      $ 性别��6%   $ * 61    6;   �� *
Stu_gender+$ TwoWay=�6h   5+      5,      5-      