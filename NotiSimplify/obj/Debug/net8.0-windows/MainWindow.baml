   M S B A M L   `   `   `  ����  NotiSimplify    NotiSimplify.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  NotiSimplify��5   	   $	��600��6   $	��800��6+   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   � $��0��6   $��10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��API Key:��6   $��Center=�6(   $��0,0,10,0q�6C   �� 5      -   5         ��Name$ ApiKeyTextBox��5      $��1��6-   $��Center=�6=   6X   5      �� 5   
   -   5         ��Name$ ChatListView��5      $��1��6)   $��10q�66   ���#F0F0F0��5      �� 5      .R�5      �� $
��Wrap=�61   $��5q�6E   ��6    �� 6E   5      5      � 5   
   $��2��6   $��10q�6    5      �� 5      $��* �6#   �� 5       $
��Auto �6#   �� 5!      $
��Auto �6#   .+�5$      �� -   5        $ MessageTextBox��5$      $��0��6.   $��0,0,10,0q�6>    �� TextWrapping$
 Wrap=�6P    �� AcceptsReturn$
 True��6d   " �� VerticalScrollBarVisibility$
 Auto=�6y   �� 5%      -   5         ��Name$ SimplifyButton��5%      $��1��6-   $��Simplify��6=   ���#6A5ACD
�������$
��10,5q�6�   $��0,0,10,0q�6�   ${�False��6�   �� 5&      -   5        $ NextMessageButton��5&      $��2��60   $��Next Message��6@   ���#6A5ACD
�������$
��10,5q�6�   5'      5(      5)      