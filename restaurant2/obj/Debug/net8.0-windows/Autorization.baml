   M S B A M L   `   `   `  ����F  Brestaurant2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:restaurant2restaurant2  5   	       restaurant2.Autorization   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:restaurant2     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$7 1Авторизация пользователей��5	   	   $	��450��6+   $	��800��68    � 	Resources 5
         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5   
   " ��6+   .�5      ��  � ��
 �   �6+   �� 5       � ��
 �   �6,   �� 5       � ��$	 1.5q�60   �� 5       � ��$	 5,2q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 10��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   $
��True��5   /   5      5      5      5      5      .��5       � .+�5!   
   �� $
��Left=�6   .+�5"      �� $N��Hpack://application:,,,/restaurant2;component/Images/fon_autorization.jpg��6   $	��450��6f   $	��300��6s   5#      �� 5$   
   $��Center=�6   $
��Left=�60   $��	459,0,0,0q�6K   .+�5%      �� $��АВТОРИЗАЦИЯ��6   $��Center=�6+   $��24(�6H   $��Heavy"�6V   �� 5&      $*��$введите свои данные��6   $��Center=�63   $��0, 0, 0, 25q�6P   $��16(�6e   $��Light"�6s   �� 5'      .+�5(      �� $��ЭЛ.ПОЧТА��6   $
��Left=�6+   $��Center=�6F   �� 5)      -   5        $��UsernameTextBox��5)      $	��200��61   $��0, 0, 0, 10q�6=   $��30��6R   $��Center=�6^   5*      �� 5+      .+�5,      �� $��ПАРОЛЬ��6   $
��Left=�6)   $��Center=�6D   G� 5-      -   5        $��PasswordBox��5-      $	��200��61   $��0, 0, 0, 10q�6=   $��30��6R   $��Center=�6^   5.      �� 50      -   5        $��LoginButton��50      $	��200��51      $��
ВОЙТИ��6!   $��0, 20, 0, 0q�53      $��40��54      #��[  55      
�������56      �� 57      $	��200��6   $��
0, 5, 0, 0q�6$   $��Center=�68   $��12(�6U   $��Light"�6c   $��NoWrap=�6v   " Ещё нет аккаунта? �� 59      -   5         � Cursor$
 Hand��59   <   
�������	 �� TextDecorations$	 	Underline{�6\   .�6x   $"Зарегистрируйтесь5;      5<      5>      5@      5A      