   M S B A M L   `   `   `  ����F  Brestaurant2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:restaurant2restaurant2  5   	   $    restaurant2.MainWindowEmployee   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:restaurant2     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$G AГлавнвое окно сотрудника расторана��5	   	   $	��450��64   $	��800��6A    � 	Resources 5
         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5   
   " ��6+   .�5      ��  � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��$	 1.5q�60   �� 5       � ��$	 5,2q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 10��5      ._�5      �� $��Center=�6/   $��Center=�5   #   $
��True��5   #   5      5      5      5      5      .��5       �  � ColumnDefinitions 5!   
   �� 5"      �� 5#      $
��Auto �6   $	��200��6,   	 � RowDefinitions	 5%   
   �� 5&      $
��Auto �6   $��59��6*   �� 5'      $
��Auto �6   �� 5(      .+�5+   
   �� $!��МЕНЮ РЕСТОРАНА��6   $��28(�5,      $��Heavy"�5-      $
��Left=�5.      $��
10,10,0,10q�5/      $��0��6(   $��0��65   $	��280��6E   �� 51   
   -   5        $!��ЛИЧНЫЙ КАБИНЕТ��51      $��Center=�52      $��	0,10,0,10q�53      $	��180��54      $��40��55      $��0��57      $��1��6   #��[  58      &   System.Windows.Controls.DataGrid  5:   
   -   5        
  Name$
 MenuDataGrid��5:         AutoGenerateColumns$ False��5;         
IsReadOnly$
 True��5<      $��2��5=      $��0��6    $��
10,0,10,10q�5>         	RowHeight$ 30Q�5?         Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	id_dish+6M     5B      $ Название��6%   $ * 6U    67   �� *	name_dish+6U     5C      $ Описание��6%   $ * 6V    67   �� *
about_dish+6V     5D      $ Цена��6%   $
 Auto 6M    63   �� *price+6M     5E      $. (Граммовка и категория��6%   $
 Auto 6h    6D   �� *category_gramme+6h   5G      �� 5I   
   $��2��6   $��1��6"   $��10q�62   .+�5J      �� -   5        $'��!ПОСМОТРЕТЬ ЗАКАЗЫ��5J      $	��180��5K      $��45��5L      $��0,0,0,10q�5M      #��[  5O      5P      5Q      5R      