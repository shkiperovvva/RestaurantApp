   M S B A M L   `   `   `  ����  restaurant2    restaurant2.AddItemWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$5  /Добавление позиции в меню��5   	   $	��377��6+   $	��400��68    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5   
   " ��6+   .�5      ��  � ��
 �����6+   �� 5	       � ��
 �����6,   �� 5
       � ��$	 1.5q�60   �� 5       � ��$	 5,2q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 10��5      ._�5      �� $��Center=�6/   $��Center=�5   '   $
��True��5   '   5      5      5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6   �� 5#      $
��Auto �6   �� 5$      $
��Auto �6   �� 5%      $
��Auto �6   �� 5&      $
��Auto �6   	 � ColumnDefinitions	 5)   
   �� 5*      $
��Auto �6   $	��128��6,   �� 5+      .+�5.   
   �� $4��.ДОБАВЛЕНИЕ НОВОЙ ПОЗИЦИИ��6   $��18(�5/      $��Heavy"�50      $
��Left=�51      $��
47,10,0,30q�52      $��0��53      $��0��6!   $��2��61   $	��306��6E   �� 55   
   $!��НАЗВАНИЕ БЛЮДА��6   $��1��6)   $��0��66   $��5,5,5,5q�6F   �� 56   
   -   5        
 ��Name$
 NameTextBox��56      $��1��6'   $��1��64   $��5,5,5,5q�6D   $��Center=�6U   �� 58   
   $��ОПИСАНИЕ��6   $��2��6#   $��0��60   $��5,5,5,5q�6@   �� 59   
   -   5        $
 AboutTextBox��59      $��2��6(   $��1��65   $��5,5,5,5q�6E   $��Center=�6V   �� 5;   
   $��ЦЕНА (РУБ.)��6   $��3��6&   $��0��63   $��5,5,5,5q�6C   �� 5<   
   -   5        $
 PriceTextBox��5<      $��3��6(   $��1��65   $��5,5,5,5q�6E   $��Center=�6V   �� 5>   
   $��ГРАММОВКА��6   $��4��6$   $��0��61   $��5,5,5,5q�6A   �� 5?   
   -   5        $
 GrammeTextBox��5?      $��4��6)   $��1��66   $��5,5,5,5q�6F   $��Center=�6W   �� 5A   
   $��КАТЕГОРИЯ��6   $��5��6$   $��0��61   $��5,5,5,5q�6A   �� 5B   
   -   5        $
 CategoryTextBox��5B      $��5��6+   $��1��68   $��5,5,5,5q�6H   $��Center=�6Y   �� 5D   
   -   5        $��СОХРАНИТЬ��5D      $��7��6%   $��1��62   $��40��6B   $��5,30,16,113q�6N   #��[  6|   �� 5E   
   -   5        $��ОТМЕНА��5E      $��7��6"   $��0��6/   $��40��6?   $��
0,30,5,113q�6K   #��[  6z   $��Right=�6�   $	��107��6�   5F      5G      