   M S B A M L   `   `   `  ����  restaurant2'    !restaurant2.PersonalAccountWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$!  Личный кабинет��5   	   $	��350��6    $	��600��6-    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5   
   " ��6+   .�5      ��  � ��
 �����6+   �� 5	       � ��
 �����6,   �� 5
       � ��$	 1.5q�60   �� 5       � ��$	 5,2q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 10��5      ._�5      �� $��Center=�6/   $��Center=�5      $
��True��5      5      5      5      5      5      .��5      � $��	0,0,0,-16q�6   .+�5   
   �� $I��Cpack://application:,,,/restaurant2;component/Images/fon_profile.png��6   $
��Left=�5      $��Bottom=�5      $	��233��5       $	��244��5!       J� Opacity$	 0.2Q�5"      $��-38,0,0,-17q�5#      	 K� ZIndex$	 0��5$      �� 5&   
   $��
30,25,30,0q�6   $	 1��6)   .+�5'      �� $!��ЛИЧНЫЙ КАБИНЕТ��6   $��28(�5(      $��Heavy"�5)      $��0,0,0,30q�5*      $��Center=�5+      � 5,      $	��295��6   $��Right=�6   $��0,0,20,0q�6;   
 � ColumnDefinitions
 5-      �� 5.      $
��Auto �6'   $��86��64   �� 5/       � RowDefinitions 51      �� 52      $
��Auto �6$   $��31.96��62   �� 53      $
��Auto �6$   $��31.96��62   �� 54      $
��Auto �6$   �� 55      $
��Auto �6$   .+�58      �� $��ИМЯ:��6   $��0��6(   $��0��68   $��5,5,5,5q�6E   �� 59      $��1��6   $��0��6)   $��1q�66   
�������$��25��6]   $ 3��6i    �� Padding$	 4,2q�6z   $��5,5,5,5q�6�   ._�5:      �� -   5         ��Name$ NameTextBlock��5:       ��6P   �� *Name+5;      �� 5=      $��ФАМИЛИЯ:��6   $��0��6,   $��1��6<   $��5,5,5,5q�6I   �� 5>      $��1��6   $��1��6)   $��1q�66   
�������$��25��6]   $ 3��6i   $	 4,2q�6z   $��5,5,5,5q�6�   ._�5?      �� -   5        $ LastNameTextBlock��5?       ��6T   �� *
LastName+5@      �� 5B      $��ЭЛ.ПОЧТА:��6   $��0��6-   $��2��6=   $��5,5,5,5q�6J   �� 5C      $��1��6   $��2��6)   $��1q�66   
�������$��25��6]   $ 3��6i   $	 4,2q�6z   $��5,5,5,5q�6�   ._�5D      �� -   5        $ EmailTextBlock��5D       ��6Q   �� *Email+5E      �� 5G      $��	РОЛЬ:��6   $��0��6)   $��3��69   $��5,5,5,5q�6F   �� 5H      $��1��6   $��3��6)   $��1q�66   
�������$��25��6]   $ 3��6i   $	 4,2q�6z   $��5,5,5,5q�6�   ._�5I      �� -   5        $ RoleTextBlock��5I       ��6P   �� *Role+5J      5K      �� 5L       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��0,0,65,0q�6N   $��71��6`   $	��197��6l   .+�5M      �� -   5        $&�� ВЫЙТИ ИЗ АККАУНТА��5M      $	��180��65   $��40��6A   $��10q�6M   #��[  5N      5O      5P      5Q      5R      