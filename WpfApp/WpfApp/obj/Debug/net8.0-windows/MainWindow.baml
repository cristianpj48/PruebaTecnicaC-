   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	     � Title$  Login��5   	   $	��450��6   $	��300��6$   .��5	      � 
�����_�$��10q�6#    � ColumnDefinitions 5
   
   �� 5      $	��41* �6   �� 5      $	��29* �6   .+�5   
   �� $��Login��6   $��24(�6!   $
��Bold"�6/   $
��Left=�5      $	��Top=�6/   $��
108,20,0,0q�6G   $��2��6[   �� 5   
   $��	User Name��6   $��	20,80,0,0q�6%   $	��Top=�68   $
��Left=�6P   �� 5   
    �� Orientation$ 
Horizontal=�6   $��20,110,20,0q�6.   $	��Top=�6C   $��2��6[   .+�5      �� $<��6C:\Users\cpatinoj\source\repos\PruebaTecnica2\user.png��6   $��20��6T   $��20��6_   $��0,0,10,0q�6k   6   �� 5      -   5         ��Name$ txtUsername��5      $	��180��6+   $��25��67   
�������$��Center=�6V   6z   5      �� 5   
   $��Password��6   $��
20,160,0,0q�6$   $	��Top=�68   $
��Left=�6P   �� 5   
   $ 
Horizontal=�6   $��20,190,20,0q�6.   $	��Top=�6C   $��2��6[   .+�5      �� $<��6C:\Users\cpatinoj\source\repos\PruebaTecnica2\lock.png��6   $��20��6T   $��20��6_   $��0,0,10,0q�6k   6   G� 5      -   5         G�Name$ txtPassword��5      $	��180��6/   $��30��6;   
�������$��Center=�6Z   6~   5      �� 5    
   $��Forgot password?��6   
����  �$��10(�6>   $	��Top=�5!      $��Center=�6,   $��	0,230,0,0q�6I   $��1��6\   �� 5$   
   -   5        $��Login��5$      
���   �
�������$	��150��5%      $��30��6   $
��Left=�6)   $��
65,270,0,0q�6D   $	��Top=�5&      $��2��6C   6Y   �� 5)   
   $
��Left=�6   $��Bottom=�6/   $��	97,0,0,30q�6J   $��2��6]   �� 5*      $�Not a member? ��6   6*   5+      �� 5,   
   $
��Left=�6   $��Bottom=�6/   $��
109,0,0,10q�6J   �� 5-      $�Sign Up?��6   
����  �66   5.      5/      50      