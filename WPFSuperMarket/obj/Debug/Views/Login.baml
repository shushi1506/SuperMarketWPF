   M S B A M L   `   `   `  ����I  EWPFSuperMarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPFSuperMarket.ViewsWPFSuperMarket.Views  5   	        WPFSuperMarket.Views.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.5.0.37524, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   .local"clr-namespace:WPFSuperMarket.Views  5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   -   5          � Title$  Login��5
   	   $	��236��5   	   $	��474��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � SizeToContent$ WidthAndHeight=�5   	    � Icon$M Gpack://application:,,,/WPFSuperMarket;component/shopping-cart%20(2).ico��5       .��5      � $	��190��6   $	��370��6    � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      �� 5      $��0* �6   .+�5   
   �� $9��3/WPFSuperMarket;component/Images/Background/bi1.png��6   $
��Fill=�6M   $��3��6\   �� 5   
   -   5        $��label4��5       $��Quản Lý Siêu Thị��5      $��28��5      $��Right=�5      $	��Top=�6)   
��� ���$��FontAwesome)�5"      $��15(�5#      $��8,6,22,0q�6   $
��Bold"�6-   $��1��6?   $	��117��6O   "  FontAwesome.WPF.ImageAwesome  5&   
      Icon$
 Lock=�5'      $��Center=�5(      $��Center=�6(   $��10,39,279,40q�5)      $��92��6#   $��70��6/      
Foreground �	#FFAA2656$��1��6Q   �� 5+   
   $��Tên Tài khoản��5,      $��	99,59,0,0q�5-      $��30��5.      $��80��6   $	��Top=�5/      $
��Left=�6%   ���	#FFE4DB26$��1��50   $   $
��Bold"�64   �� 52   
   -   5        $��txtBxuserName��54      $��191,0,0,101q�53      $��30��55      $	��157��6   $��Center=�56      $��Bottom=�57      $
��Left=�6(   $��FontAwesome)�58      ���	#00000000	 J� OpacityMask
	 �����
�������
�������$��1��5=   5   �� 5?   
   $��Mật khẩu��5@      $��	99,95,0,0q�5A      $��29��5B      $��80��6   $	��Top=�5C      $
��Left=�6%   ���	#FFD3CA17$��1��5D   $   $
��Bold"�64   G� 5F   
   -   5        $��passBxPassword��5F   *   $��
191,0,0,66q�6   $��Center=�6@   $
��Left=�6b   $	��157��6}   $��FontAwesome)�6�   
����������	#00000000
 G� PasswordChar$
 *��6�    � OverridesDefaultStyle .   G� SelectionBrush �	#FFFFB14A$��30��6  $��Bottom=�6#  
�������$��1��6�  �� 5H   
   -   5        $��btnLogin��5K      $��Đăng nhập��5I      $��190,140,0,0q�5J      $��29��5L      $��89��6   $	��Top=�5M      $
��Left=�6%    � Cursor$
 Hand��5N      $��FontAwesome)�6   
�������$��1��5P      $
��Bold"�6    �� 	IsDefault . &   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$
 None 5Q      ���	#FF00A65A
�������6E   �� 5R   
   -   5         ��Name$ button��5R      $��2��6!   $��Thoát��65   $
��Left=�6E   $��286,140,0,0q�6`   $	��Top=�6u   $��62��6�   $��29��6�   $��FontAwesome)�6�   �� 5S   
   -   5         ��Name$ 
txtWarning��5S      $!��Mật khẩu không đúng.��5T      $��
16,146,0,0q�5U      $��30��5V      $	��144��6   $	��Top=�5W      $
��Left=�6%   ���	#FF570404$��1��5X   $   $��Italic$�64   5Y      5Z      