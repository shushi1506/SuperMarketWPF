   M S B A M L   `   `   `  ����I  EWPFSuperMarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPFSuperMarket.ViewsWPFSuperMarket.Views  5      /clr-namespace:WPFSuperMarketWPFSuperMarket  5      "    WPFSuperMarket.Views.Account   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:WPFSuperMarket.Views     5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      c _DevExpress.Xpf.Ribbon.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5	      Fdxbh;http://schemas.devexpress.com/winfx/2008/xaml/bars/internal  5
      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      d `DevExpress.Xpf.Docking.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxd5http://schemas.devexpress.com/winfx/2008/xaml/docking  5      f bDevExpress.Xpf.Grid.v16.2.Core, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5      +Marketclr-namespace:WPFSuperMarket  	 5      -   5          � 	Resources  5      -   'WPFSuperMarket.Views.imageConvertAcount   imageConvertAcount  DetailCoreTemplate-  'DevExpress.Xpf.Core.MeasurePixelSnapper � RowDefinitions � ColumnDefinitions&   DevExpress.Xpf.Editors.ImageEdit  Name   Source �� Path �� 	Converter ��Name  textBlockstyle  rowWithToolTipTemplate ^� 	IsEnabled	 ^� InitialShowDelay
 ^� ToolTip
 � Tag��%�  &	        &	      7   7  7  7  &	 B      5   
   6A   �� 5   
   .R�5        $	��500��6%   $	��300��64   ._�5      � $
��Left=�6   $	��100��62   $	��Top=�6@   $	��637��6X    5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(    5      �� 5      $
��100* �6+   �� 5      $
��102* �6+   �� 5      $
��235* �6+   .+�5!        $ _tooltipimage��6$   $
��Left=�6�   $	��Top=�6�   $	��100��6�   $	��100��6�   $��3��6�    6;   �� $ Row.Picture�8   5"      �� 5#      $ label��6   $��Tên Tài Khoản:��6+   $��1��6D   $��Stretch=�6T   $��0��6r   $��Stretch=�6   �� 5$      $ label1��6   $��Thư Điện Tử:��6,   $��1��6C   $��Stretch=�6S   $��1��6r   $��Stretch=�6   �� 5%      $ label2��6   $��
Họ Tên:��6,   $��1��6>   $��Stretch=�6N   $��2��6m   $��Stretch=�6z   �� 5&      8�� $��2��6H   $��16(�6Y   $��Stretch=�6g   $
��Wrap=�6�   $��Center=�6�   ��6�   �� *Row.Username+6�   �� 5'      8�� $��2��6I   $��16(�6Y   $��Stretch=�6g   $��1��6�   $
��Wrap=�6�   $��Center=�6�   ��6�   �� *	Row.Email+6�   �� 5(      8�� $��2��6I   $��16(�6Y   $��Stretch=�6g   $��2��6�   $
��Wrap=�6�   $��Center=�6�   ��6�   �� *
Row.Name+6�   5)      5*      5+      �� 5,   
   .R�5-      �� ��6   �� ��63   �� *View.DefaultDataRowTemplate+ 5.      �� 5/      $ DataContext.Tooltip�6   $	 10��51   V   
 52      �� 53      #���  69   $ Transparent��6p   $	��600��6�   ��6%   �� 6�   55      56      57      .��58      (  "DevExpress.Xpf.Docking.LayoutGroup     Orientation$ 
Horizontal=�6      Items. 59   
   (  "DevExpress.Xpf.Docking.LayoutPanel  +  %DevExpress.Xpf.Docking.BaseLayoutItem   
AllowClose .     Caption$ Danh sách Tài khoản��6-      	ItemWidth$ 3* �6K   (  "DevExpress.Xpf.Docking.ContentItem   Content. 5:      % 	 DevExpress.Xpf.Grid.GridControl  -   5          Name$ gridControl1��5:      )	  #DevExpress.Xpf.Grid.DataControlBase 	  AutoGenerateColumns$ AddNew=�64    	  
ShowBorder .   	  SelectionMode$	 Row=�6�    	  ItemsSource 6Q   �� *DataAccount+   View 5;      #
 	 DevExpress.Xpf.Grid.TableView
  5<      & 	  DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .   
  RowStyle 5=      �� 5>       �� 
TargetType$ 	 DevExpress.Xpf.Grid.RowControl"  6    .�5?      ��  �� Property �@^�ToolTip �� Value 5@   "   �� 5A   &   #���  6I   ��65   �� 6I   5C      5D      5F      5H      5I        5J   
    .  $ 
Chi tiết��6-   ��. $ 1* �6e   . 5K      �� $
��Auto=�6   $
��Auto=�6M   .��5L      � .+�5N      ��   
styleLabel#��[ 6   $��	Mã số:��6@   $
��Left=�6Q   $	��Top=�6l   $��	10,48,0,0q�6�   �� 5O      -   5         ��Name$ txtAccountId��5O      $
��Left=�65   $��23��6P    �� TextWrapping$
 Wrap=�6\   $	��Top=�6p   $	��108��6�   $��	10,70,0,0q�6�    �� 
IsReadOnly .   J� RenderTransformOrigin$  0.478,0.522&�6�   {�.  6�   �� 5P      #��[ 6   $��Thời gian tạo:��6@   $
��Left=�6Y   $	��Top=�6t   $��	10,98,0,0q�6�   �� 5Q      -   5        $ txtAccountCreateTime��5Q      $
��Left=�6=   $��23��6X   $
 Wrap=�6d   $	��Top=�6x   $	��108��6�   $��
10,125,0,0q�6�    . {�.  6�   �� 5R      #��[ 6   $��Tài khoản tạo:��6@   $
��Left=�6Y   $	��Top=�6t   $��
10,146,0,0q�6�   $  0.863,-6.364&�6�   �� 5S      -   5        $ txtAccountCreatedBy��5S      $
��Left=�6;   $��23��6V   $
 Wrap=�6b   $	��Top=�6v   $	��108��6�   $��
10,173,0,0q�6�    . {�.  6�     5U      -   5        $ imageAccountPicture��5U   $   $
��Left=�6A   $��
136,76,0,0q�6\   $	��Top=�6p   $	��120��6�   $R Lpack://application:,,,/WPFSuperMarket;component/Images/user-1-glyph-icon.png��6�   $	��120��6�   6�   %  DevExpress.Xpf.Editors.TextEdit  5W      -   5        !  Name$! txtAccountUsername��5Y        styleTextEdit#��[ 5X      $
��Left=�5Z      $	��Top=�64   $	��158��5[      $��
98,210,0,0q�6%   $��0��5\      ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  5^      -   5        "  Name$" txtAccountHashedPassword��5_      $
��Left=�5`      $	��Top=�64   $	��246��5a      $��
10,264,0,0q�6%   {�.  $��1��5b        5d      -	   5        $! txtAccountEmail��5f      #��[ 5e      $
��Left=�5g      $	��Top=�64   $	��158��5h      $��
98,293,0,0q�6%   $��2��5i        5k      -
   5        $! txtAccountName��5l      #��[ 5k   $   $
��Left=�5m      $	��Top=�64   $	��158��5n      $��
98,321,0,0q�6%   $��3��5o        5q      -   5        $! txtAccountIdCard��5r      #��[ 5q   $   $
��Left=�5s      $	��Top=�64   $	��158��5t      $��
98,350,0,0q�6%   $��4��5u        5w      -   5        $! txtAccountPhone��5x      #��[ 5w   $   $
��Left=�5y      $	��Top=�64   $	��158��5z      $��
98,377,0,0q�6%   $��5��5{        5}      -   5        $! txtAccountDetail��5~      #��[ 5}   $   $	��Top=�5      $
��Left=�68   $	��Top=�6S   $	��246��5�      $��
10,466,0,0q�6%   $��80��69   )  #DevExpress.Xpf.Editors.TextEditBase#   AcceptsReturn# . $   
AcceptsTab$ .  %   TextWrapping$
% Wrap=�5�   A   $��6��5�      �� 5�      #��[ 6   $��Tài khoản:��6@   $
��Left=�6U   $	��Top=�6p   $��
10,210,0,0q�6�   �� 5�      #��[ 6   $��Mật khẩu:��6B   $
��Left=�6V   $	��Top=�6q   $��
10,237,0,0q�6�   �� 5�      #��[ 6   $��Thư điện tử:��6@   $
��Left=�6W   $	��Top=�6r   $��
10,293,0,0q�6�   �� 5�      #��[ 6   $��
Họ tên:��6@   $
��Left=�6R   $	��Top=�6m   $��
10,321,0,0q�6�   �� 5�      #��[ 6   $��CMND:��6@   $
��Left=�6P   $	��Top=�6k   $��
10,349,0,0q�6�   �� 5�      #��[ 6   $��Điện thoại:��6@   $
��Left=�6V   $	��Top=�6q   $��
10,377,0,0q�6�   �� 5�      #��[ 6   $��
Chi tiết��6@   $
��Left=�6S   $	��Top=�6n   $��
10,444,0,0q�6�   �� 5�      -   5        & ��Name$& btnAddAccount_Cancel��5�      $��Hủy��5�      $
��Left=�5�      $	��Top=�64   $��52��5�      $��20��6$   $��
100,10,0,0q�60   5�      �� 5�      -   5        $& btnAddAccount��5�      $��Tạo mới��5�      $
��Left=�5�      $	��Top=�64   $��	10,10,0,0q�5�      $��85��6,   $��20��67   $��5,0,5,0q�6C   &   DevExpress.Xpf.Core.ThemeManager'   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$
' None 5�      ���#00a65a
�������5�      �� 5�      -   5        $& btnSaveChangeAccount��5�      $��Lưu thay đổi��5�      $
��Left=�5�      $	��Top=�65   $��
157,10,0,0q�5�      $��99��6-   $��20��68   $
' None 5�      ���#3c8dbc
�������5�      �� 5�      -   5        $!& btnSaveChangeAccount_Cancel��5�      $��Hủy thay đổi��5�      $
��Left=�5�      $	��Top=�64   $��99��5�      $��
157,39,0,0q�6$   5�      �� 5�      -   5        $& btnChangePasswordAccount��5�      $��Đổi mật khẩu��5�      $
��Left=�5�      $	��Top=�64   $��
98,237,0,0q�5�      $��95��6-   $
' None 5�      ���#3c8dbc
�������$��22��5�   ,   �� 5�      -   5        $%& btnChangePasswordAccount_Cancel��5�      $��Hủy��5�      $
��Left=�5�      $	��Top=�64   $��198,237,0,0q�5�      $��58��6.   {�. 5�   H   �� 5�      -   5        $& btnDeleteAccount��5�      $��Xóa tài khoản��5�      $
��Left=�5�      $	��Top=�64   $��153,442,0,0q�5�      $	��103��6.   $
' None 5�      ���#dd4b39
�������5�      �� 5�      -   5        $& btnSetAdmin��5�      $$��Đặt làm Quản trị viên��5�      $
��Left=�5�      $	��Top=�64   $��
10,552,0,0q�5�      $	��123��6-   $
' None 5�      ���#dd4b39
�������5�      �� 5�      -   5        $& btnUnSetAdmin��5�      $!��Bỏ quyền Q. trị viên��5�      $
��Left=�5�      $	��Top=�64   $��138,552,0,0q�5�      $	��118��6.   $
' None 5�      ���#dd4b39
�������$  
1.447,0.55&�5�   ,   �� 5�      #��[ 6   $��Quyền Hạn :��6@   $
��Left=�6V   $	��Top=�6q   $��
10,410,0,0q�6�   )  #DevExpress.Xpf.Editors.ComboBoxEdit  5�      -   5        (  Name$( _comboboxquyenhan��5�   '   $
��Left=�6B   $��
98,410,0,0q�6]   $	��Top=�6q   $	��158��6�   +  %DevExpress.Xpf.Editors.LookUpEditBase)   DisplayMember$)  ��6�   *   ValueMember$*  ��6�   +   AutoComplete+ . ,   Items., 5�      -  'DevExpress.Xpf.Editors.ComboBoxEditItem  $��
Quản Lý��6/     5�      $��Nhân Viên��6/     5�      $��	Thủ Kho��6/   5�      5�      5�      5�      5�      5�      