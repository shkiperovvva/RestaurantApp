   M S B A M L   `   `   `  ����  restaurant2    restaurant2.CartWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Корзина��5   	   $	��450��6   $	��800��6&    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius  DeleteButtonStyle �� BasedOn��%`  &	        &	 �    7   �� 5   
   " ��6+   .�5      ��  � ��
 �����6+   �� 5	       � ��
 �����6,   �� 5
       � ��$	 1.5q�60   �� 5       � ��$	 5,2q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 10��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   $
��True��5   /   5      5      5      5      �� 5   
   " ��6*   8   .�5      ��  � �� �#FFCCCC6+   �� 5       � ��
 �����6+   �� 5       � ��$ 5q�6(   5      5       .��5!      � 	 � RowDefinitions	 5"   
   �� 5#      $
��Auto �6   �� 5$      �� 5%      $
��Auto �6   .+�5)   
   �� -   5        $��
НАЗАД��5)      $
��Left=�5*      $��10q�5+      $��80��5,      #��[  5.      �� 51   
   $��КОРЗИНА��6   $��28(�52      $��Heavy"�53      $��10q�54      $��Center=�55      &   System.Windows.Controls.DataGrid  58   
   -   5        
  Name$
 CartDataGrid��58      $��1��59         AutoGenerateColumns$ False��5:         
IsReadOnly$
 True��5;      $��10q�5<         SelectionMode$ Single=�5>      ��5=      �� *Items+   Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Dish.name_dish+6Z     5A      $ Количество��6%   $
 Auto 6V    69   �� *
Quantity+6V   4  .System.Windows.Controls.DataGridTemplateColumn  5B      $  ��6)   $
 Auto 63      CellTemplate 5C      �� 5D      .R�5E      ��  �� Orientation$ 
Horizontal=�6)   .+�5F   "   �� -   5        $��-��5F   )   $��25��5G   )   
 � Tag 5I   )   �� �� 5J   "   -   5        $��+��5J   )   $��25��5K   )   $	��5,0q�5L   )    5N   )   �� 5O      5P      5R        5S      $ Цена��6%   $
 Auto 6R    63   �� *
Dish.price+6R     5T      $# Общая стоимость��6%   $
 Auto 6\    6>   �� *	TotalCost+6\   5V      �� 5Y   
   -   5        $��2��5Y      $!��ОФОРМИТЬ ЗАКАЗ��5Z      $	��200��5[      $��40��5\      $��10q�5]      $��Right=�5^      #��[  5_      5`      �� 5a   
   -   5        $%��ОЧИСТИТЬ КОРЗИНУ��5a      $	��150��5b      $��40��5c      $��10q�5d      $��Right=�5e      #��[  5f      5g      5h      5i      