   M S B A M L   `   `   `  ����  restaurant2"    restaurant2.ClientListWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$#  Список клиентов��5   	   $	��450��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5   
   " ��6+   .�5      ��  � ��
 �����6+   �� 5	       � ��
 �����6,   �� 5
       � ��$	 1.5q�60   �� 5       � ��$	 5,2q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 10��5      ._�5      �� $��Center=�6/   $��Center=�5      $
��True��5      5      5      5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5"   
   �� -   5        $��
НАЗАД��5"      $
��Left=�5#      $��10q�5$      $��80��5%      $��0��5&   *   #��[  5'      �� 5)   
   $#��СПИСОК КЛИЕНТОВ��6   $��28(�5*      $��Heavy"�5+      $��Center=�5,      $��10q�5-      $��0��6    &   System.Windows.Controls.DataGrid  5/   
   -   5        	  Name$	 ClientsDataGrid��5/      
   AutoGenerateColumns$
 False��50         
IsReadOnly$
 True��51      $��1��52      $��
10,0,10,10q�53         	RowHeight$ 30Q�54         Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	id_client+6O     57      $ Имя��6%   $ * 6R    62   �� *name_client+6R     58      $ Фамилия��6%   $ * 6Z    66   �� *lastname_client+6Z     59      $ Email��6%   $ * 6N    64   �� *email+6N   5=      5>      5?      