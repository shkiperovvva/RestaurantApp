   M S B A M L   `   `   `  ����  restaurant2$    restaurant2.EmployeeListWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$)  #Список сотрудников��5   	   $	��450��6$   $	��800��61    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5   
   " ��6+   .�5      ��  � ��
 �����6+   �� 5	       � ��
 �����6,   �� 5
       � ��$	 1.5q�60   �� 5       � ��$	 5,2q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 10��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   $
��True��5   /   5      5      5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   	 � RowDefinitions	 5!   
   �� 5"      $
��Auto �6   �� 5#      $��* �6   .+�5'   
   �� -   5        $��
Назад��5'      $
��Left=�5(      $��10q�5)      $��80��5*      $��0��5+   *   $��0��67   #��[  5,      �� 5/   
   $)��#СПИСОК СОТРУДНИКОВ��6   $��28(�50      $��Heavy"�51      $
��Left=�52      $��225,10,0,10q�53      $��0��6)   $��0��66   &   System.Windows.Controls.DataGrid  56   
   -   5        
  Name$
 EmployeesDataGrid��56         AutoGenerateColumns$ False��57         
IsReadOnly$
 True��58      $��1��59      $��0��6    $��
10,0,10,10q�5:         	RowHeight$ 30Q�5;         Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id_employee+6Q     5>      $ Имя��6%   $ * 6T    62   �� *name_employee+6T     5?      $ Фамилия��6%   $ * 6\    66   �� *lastname_employee+6\     5@      $ Эл.почта��6%   $ * 6Q    67   �� *email+6Q   5C      �� 5E   
   $��2��6   $��1��6"   $��10q�62   .+�5F      �� -   5        $)��#УДАЛИТЬ СОТРУДНИКА��5F      $	��180��5G      $��40��5H      $��0,0,0,10q�5I      $	��Top=�5K      #��[  5L      �� 5M      -   5        $+��%ДОБАВИТЬ СОТРУДНИКА��5M      $	��180��5N      $��40��5O      $	��Top=�5Q      #��[  5R      5S      5T      5U      