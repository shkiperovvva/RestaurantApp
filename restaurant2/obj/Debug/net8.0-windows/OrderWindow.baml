   M S B A M L   `   `   `  ����F  Brestaurant2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:restaurant2restaurant2  5   	       restaurant2.OrderWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:restaurant2     5   	     � Title$!  Список заказов��5   	   $	��450��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius  StatusBorderStyle �� Triggers	 �� Binding
 �� Value��%M  &	        &	 �    �� 5   
   " ��6+   .�5      ��  � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��$	 1.5q�60   �� 5       � ��$	 5,2q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 10��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   $
��True��5   /   5      5      5      5      �� 5    
   " ��6    5!      �� 5"      	 6   �� *status_order+
 
Начат6?   .a�5#      ��  � ��
 �  ��64   5$      �� 5%      	 6   �� *status_order+
 
Готов6?   .a�5&      ��  � ��
 � � �64   5'      �� 5(      	 6   �� *status_order+
 Оформлен6?   .a�5)      ��  � ��
 � ���64   5*      5,      5-      .��5/      �  � RowDefinitions 50   
   �� 51      $
��Auto �6   �� 52      $��* �6   .+�56   
   �� -   5        $��
НАЗАД��56      $
��Left=�57      $��10q�58      $��80��59      $��0��5;      #��[  5<      �� 5?   
   $!��СПИСОК ЗАКАЗОВ��6   $��28(�5@      $��Heavy"�5A      $��Center=�5B      $��10q�5C      $��0��5D      �� 5G   
    �� Orientation$ 
Horizontal=�6   $��Right=�5H      $��Center=�5I      $��0,0,10,0q�5J      $��0��5K      .+�5L      �� -   5         ��Name$ StatusFilterComboBox��5L      $	��150��5M      
�������.@�5P      �� $��Все статусы��6    �� 
IsSelected$
 True��65   �� 5Q      $��Оформлен��6   �� 5R      $��
Начат��6   �� 5S      $��
Готов��6   5T      5U      �� 5W   
   $��1��6   $
��Auto=�6$   $��0,10,0,0q�6G   .��5X      �� -   5         ��Name$ OrdersItemsControl��5X      $��Center=�5Y      $��Disabled=�5Z      ��5[      �� 5\      .R�5]      A�  A� Columns$ 3��6&   $��Center=�5^      $	��Top=�5_      $
��0,-8q�5`      5a      ��5d      �� 5e      .R�5f      �� $	��1.5q�5g      $��8q�5h      $	��240��5i      $	��300��5j      
������� �� Padding$ 0q�5l      ��5f   !   �� *StatusColor+._�5m      � $��8q�6#    5n   "   �� 5o   &   $
��Auto �64   �� 5p   &   $
��Auto �64   �� 5q   &   $��* �64   �� 5r   &   $
��Auto �64   �� 5s   &   $
��Auto �64   .+�5v   "   �� $
��Bold"�5w   $   $��Center=�66   $��16(�5x   $   $��0��62   ��5v   ,   �� *
id_order+ �� StringFormat$ ЗАКАЗ №{0}��5x   2   �� 5z   "   $!��ПОЗИЦИИ ЗАКАЗА��6,   $��12(�5{   $   $��Center=�62   $��0,0,0,10q�5|   $   $��Light"�5}   $   $��1��67   �� 5   "   $��2��6M   $	��0,5q�6Z   ��6/   �� *Items+��5�   &   �� 5�   *   .R�5�   .   � $	��0,2q�63    � ColumnDefinitions 5�   2   �� 5�   6   $��* �6G   �� 5�   6   $
��Auto �6G   �� 5�   6   $
��Auto �6G   .+�5�   2   �� $��0��6W   ��6<   �� *	name_dish+6W   �� 5�   2   $��1��6V   $	��4,0q�6f   ��6<   �� *
quantity+6f   �� 5�   2   $��2��6Y   ��6<   �� *total_price+6Y   5�   /   5�   +   5�   #   �� 5�   "   $��0,10,0,0q�6-   $��3��6?   .+�5�   &   �� $��SemiBold"�5�   (   ��5�   0   �� *status_order+$ СТАТУС: {0}��5�   (   �� 5�   &   $0��*ИЗМЕНИТЬ СТАТУС ЗАКАЗА��6-   $��0,5,0,5q�5�   %   $��35��5�   %   #��[  5�   %   ��5�   %   �� *!DataContext.ChangeStatusCommand+ �� RelativeSource ��  �� AncestorType ItemsControl��5�   %   �� 5�   #   �� 5�   "   $��0,10,0,0q�6-   $��4��6?   $��Bottom=�6L   .+�5�   &   �� $��11(�5�   )   ��5�   0   �� *
date_order+$ {0:dd.MM.yyyy HH:mm:ss}��5�   )   �� 5�   &   $
��Bold"�5�   )   $	��0,5q�6;   $��16(�6H   ��5�   0   �� *TotalOrderPrice+$ СУММА: {0}��5�   H   5�   #   5�      5�      5�      5�      5�      5�      5�      