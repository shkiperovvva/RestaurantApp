   M S B A M L   `   `   `  ����F  Brestaurant2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:restaurant2restaurant2  5   	   !    restaurant2.MainWindowAdmin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:restaurant2     5   	     � Title$I  CГлавное окно администратора системы��5   	   $	��450��65   $	��800��6B    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5   
   " ��6+   .�5      ��  � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��$	 1.5q�60   �� 5       � ��$	 5,2q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 10��5      ._�5      �� $��Center=�6/   $��Center=�5   '   $
��True��5   '   5      5      5      5      5      .��5       �  � ColumnDefinitions 5!   
   �� 5"      �� 5#      $
��Auto �6   $	��200��6,   	 � RowDefinitions	 5%   
   �� 5&      $
��Auto �6   $��59��6*   �� 5'      $
��Auto �6   �� 5(      .+�5+   
   �� $!��МЕНЮ РЕСТОРАНА��6   $��28(�5,      $��Heavy"�5-      $
��Left=�5.      $��
10,10,0,10q�5/      $��0��6    $��0��6-   $	��280��6=   �� 51   
   -   5        $!��ЛИЧНЫЙ КАБИНЕТ��51      $��Center=�52      $��	0,10,0,10q�53      $	��180��54      $��40��55      $��0��57      $��1��6   #��[  58      &   System.Windows.Controls.DataGrid  5:   
   -   5        
  Name$
 MenuDataGrid��5:         AutoGenerateColumns$ False��5;         
IsReadOnly$
 True��5<      $��2��5=      $��0��5>      $��
10,0,10,10q�5?         	RowHeight$ 30Q�5@         Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	id_dish+6M     5C      $ Название��6%   $ * 6U    67   �� *	name_dish+6U     5D      $ Описание��6%   $ * 6V    67   �� *
about_dish+6V     5E      $ Цена��6%   $
 Auto 6M    63   �� *price+6M     5F      $. (Граммовка и категория��6%   $
 Auto 6h    6D   �� *category_gramme+6h   5H      �� 5J   
   $��2��6   $��1��6"   $��10q�62   .+�5K      �� -   5        $%��ДОБАВИТЬ ПОЗИЦИЮ��5K      $	��180��5L      $��40��5M      $��0,0,0,10q�5N      #��[  5P      �� 5Q      -   5        $#��УДАЛИТЬ ПОЗИЦИЮ��5Q      $	��180��5R      $��40��5S      $��0,0,0,10q�5T      #��[  5V      �� 5W      -   5        $#��СПИСОК КЛИЕНТОВ��5W      $	��180��5X      $��40��5Y      $��0,0,0,10q�5Z      #��[  5\      �� 5]      -   5        $)��#СПИСОК СОТРУДНИКОВ��5]      $	��180��5^      $��40��5_      $��0,0,0,10q�5`      #��[  5b      �� 5c      -   5        $-��'СГЕНЕРИРОВАТЬ ОТЧЕТЫ��5c      $	��180��5d      $��40��5e      #��[  5g      5h      5i      5j      