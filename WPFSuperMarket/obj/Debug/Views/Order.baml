   M S B A M L   `   `   `  ����I  EWPFSuperMarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPFSuperMarket.ViewsWPFSuperMarket.Views  5           WPFSuperMarket.Views.Order   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:WPFSuperMarket.Views     5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      c _DevExpress.Xpf.Ribbon.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5	      Fdxbh;http://schemas.devexpress.com/winfx/2008/xaml/bars/internal  5
      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      d `DevExpress.Xpf.Docking.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxd5http://schemas.devexpress.com/winfx/2008/xaml/docking  5      f bDevExpress.Xpf.Grid.v16.2.Core, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5      j
 fDevExpress.Xpf.LayoutControl.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol 
 5      -   5          � 	Resources  5      -   'WPFSuperMarket.Views.imageConvertAcount   imageConvertAcount'   !WPFSuperMarket.Views.imageConvert  imageConverter  DetailCoreTemplateOrderline-  'DevExpress.Xpf.Core.MeasurePixelSnapper � RowDefinitions � ColumnDefinitions&   DevExpress.Xpf.Editors.ImageEdit   Source �� Path �� 	Converter ��Name  textBlockstyle  DetailCoreTemplateOrder��%�
  &	        &	      &	 &     7  7  7  7  &	 N    7   7  7  7    5   
   6A     5   
   66   �� 5   
   .R�5        $	��500��6%   $	��300��64   ._�5      � $
��Left=�6   $	��100��62   $	��Top=�6@   $	��637��6X    5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(    5      �� 5      $
��100* �6+   �� 5       $
��102* �6+   �� 5!      $
��235* �6+   .+�5#        $
��Left=�6{   $	��Top=�6�   $	��100��6�   $	��100��6�   $��3��6�    6$   �� $ Row.PictureProduct�8   5$      �� 5%      $ label��6   $��Tên Mặt Hàng:��6+   $��1��6C   $��Stretch=�6S   $��0��6q   $��Stretch=�6~   �� 5&      $ label1��6   $��Số Lượng:��6,   $��1��6@   $��Stretch=�6P   $��1��6o   $��Stretch=�6|   �� 5'      $ label2��6   $��Tổng Tiền:��6,   $��1��6A   $��Stretch=�6Q   $��2��6p   $��Stretch=�6}   �� 5(      8�� $��2��6H   $��16(�6Y   $��Stretch=�6g   $
��Wrap=�6�   $��Center=�6�   ��6�   �� *Row.ProductName+6�   �� 5)      8�� $��2��6I   $��16(�6Y   $��Stretch=�6g   $��1��6�   $
��Wrap=�6�   $��Center=�6�   ��6�   �� *Row.Quantity+6�   �� 5*      8�� $��2��6I   $��16(�6Y   $��Stretch=�6g   $��2��6�   $
��Wrap=�6�   $��Center=�6�   ��6�   �� *Row.TotalPrice+6�   5+      5,      5-      �� 5.   
   .R�5/        $	��500��6%   $	��300��64   ._�50      � $
��Left=�6   $	��100��62   $	��Top=�6@   $	��637��6X    51      �� 52      $
��Auto �6(   �� 53      $
��Auto �6(   �� 54      $
��Auto �6(    56      �� 57      $
��100* �6+   �� 58      $
��102* �6+   �� 59      $
��235* �6+   .+�5;        $
��Left=�6   $	��Top=�6�   $	��100��6�   $	��100��6�   $��3��6�    6$   �� $ Row.PictureAccount�8   5<      �� 5=      $ label��6   $��Tài Khoản Tạo:��6+   $��1��6D   $��Stretch=�6T   $��0��6r   $��Stretch=�6   �� 5>      $ label1��6   $��Thời Gian Tạo:��6,   $��1��6E   $��Stretch=�6U   $��1��6t   $��Stretch=�6�   �� 5?      $ label2��6   $��Thành Tiền:��6,   $��1��6B   $��Stretch=�6R   $��2��6q   $��Stretch=�6~   �� 5@      8�� $��2��6H   $��16(�6Y   $��Stretch=�6g   $
��Wrap=�6�   $��Center=�6�   ��6�   �� *Row.CreatedBy+6�   �� 5A      8�� $��2��6I   $��16(�6Y   $��Stretch=�6g   $��1��6�   $
��Wrap=�6�   $��Center=�6�   ��6�   �� *Row.CreateTime+6�   �� 5B      8�� $��2��6I   $��16(�6Y   $��Stretch=�6g   $��2��6�   $
��Wrap=�6�   $��Center=�6�   ��6�   �� *Row.PaidPrice+6�   5C      5D      5E      5F      .��5G      (  "DevExpress.Xpf.Docking.LayoutGroup     Orientation$ 
Horizontal=�6      Items. 5H   
     +  %DevExpress.Xpf.Docking.BaseLayoutItem	   	ItemWidth$	 2* �6   $ Vertical=�6)   . 5I        
   
ItemHeight$
 2* �6   . 5J      (  "DevExpress.Xpf.Docking.LayoutPanel     
AllowClose .     Caption$ Sao kê��65   (  "DevExpress.Xpf.Docking.ContentItem   Content. 5K      �  5L      �� 5M      $
��163* �6/   �� 5N      $	��25* �6/   �� 5O      $
��174* �6/   .+�5Q      ��   
styleLabel#��[ 6    $��Từ ngày: ��6D   $
��Left=�6X   $��10, 10, 0, 0q�6s   $	��Top=�6�   %	  DevExpress.Xpf.Editors.DateEdit	  5R      -   5         	 Name$ dateFromTime��5R   '   $
��Left=�6=   $��	63,10,0,0q�6X   $	��Top=�6k   $	��110��6�    	  DateTime$ 12/24/2016 00:00:00��6�   %
  DevExpress.Xpf.Editors.TextEdit 
  MaskCulture$ en-US��6�    
  Mask$ 
dd/MM/yyyy��6�   �� 5S      #��[ 6    $��Đến ngày: ��6D   $
��Left=�6Y   $��200, 10, 0, 0q�6t   $	��Top=�6�   	  5T      -   5        $ 
dateToTime��5T   '   $
��Left=�6;   $��
261,10,0,0q�6V   $	��Top=�6j   $	��110��6�   $ 12/24/2016 00:00:00��6�   $ en-US��6�   $ 
dd/MM/yyyy��6�   $��2��6�   �� 5U      -   5         ��Name$ 	btnSearch��5U   !   $��Sao kê��64   $
��Left=�6E   $	��Top=�6`   $	��100��6x   $��	15,41,0,0q�6�   $��26��6�   $��2��6�   �� 5V      -   5        $ btnPrintList��5V   !   $��IN BÁO CÁO��67   $
��Left=�6L   $	��Top=�6g   $	��205��6   $��
120,41,0,0q�6�   $��26��6�   &   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$
 None 5W   !   ���	#FF00A65A
�������$
��Bold"�6l   $��2��6�   �� 5Y      -   5        $ btnAll��5Y   !   $��
Tất cả��61   $
��Left=�6B   $	��Top=�6]   $	��100��6u   $��
225,10,0,0q�6�   $��22��6�   $��2��6�   �� 5[      -   5        $ btnThisMonth��5[   !   $��Trong tháng��67   $
��Left=�6M   $	��Top=�6h   $	��100��6�   $��
120,10,0,0q�6�   $��22��6�   $��2��6�   �� 5\      -   5        $ btnToday��5\   !   $��Trong ngày��63   $
��Left=�6H   $	��Top=�6c   $	��100��6{   $��	15,10,0,0q�6�   $��22��6�   $��2��6�   
  5^      -	   5         
 Name$ txtSearchOrder��5^   '   $
��Left=�6?   $	��Top=�6Z   $	��184��6r   $��	10,41,0,0q�6~   $��26��6�     styleTextEdit#���  6�   5_      �� 5`      -
   5        $ btnSearchOrder��5`   !   $��Tìm kiếm��69   $
��Left=�6L   $	��Top=�6g   $��75��6   $��
194,41,0,0q�6�   $��26��6�   $
 None 6�   ���	#FF00A65A
�������$
��Bold"�6  �� 5a      -   5        $ btnClearSearchOrder��5a   !   $��Tải lại��6>   $
��Left=�6P   $	��Top=�6k   $��76��6�   $��
274,41,0,0q�6�   $��26��6�    J� RenderTransformOrigin$ 1.667,0.696&�6�   $��2��6�   5c      5d      5e        5f      $
 5* �6   . 5g         .  $ Danh mục Hóa đơn��65   . 5h      % 	 DevExpress.Xpf.Grid.GridControl  -   5          Name$ gridControlOrders��5h   &   )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$ AddNew=�6A      
ShowBorder .     SelectionMode$	 Row=�6q      View 5i      # 	 DevExpress.Xpf.Grid.TableView  5j      & 	  DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  &   DevExpress.Xpf.Grid.DataViewBase    RowCellMenuCustomizations 5k   "   '  !DevExpress.Xpf.Bars.BarButtonItem  5l   &   -   5          Name$ printOrderContextMenu��5l   8   !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ In Hóa đơn   6W      Glyph 5m   U   *  $DevExpress.Xpf.Core.DXImageExtension      Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$  Print_16x16.png !   RowStyle! 5o   "   �� 5p   &   " �� 
TargetType$ 	 DevExpress.Xpf.Grid.RowControl""  6,   .�5q   *   �� # �� Property# �@^�ToolTip$ �� Value$ 5r   .   �� 5s   2   #���  6U   ��6A   �� 5u   3   5w   +   5x   '   5z      5|      5}      5~        5      $
 5* �6   . 5�         .  $ Chi tiết Hóa đơn��65   . 5�        -   5        $ gridControlOrderLines��5�   &   $ AddNew=�6E    .  $	 Row=�6u    5�        5�       .  ! 5�   "   �� 5�   &   ""  6,   .�5�   *   �� # �@^�ToolTip$ 5�   .   �� 5�   2   #���  6U   ��6A   �� 6U   5�   +   5�   '   5�      5�      5�      5�      5�        5�   
   $	 1* �6   . 5�         .  $ Thông tin Hóa đơn��61   . 5�      �  5�      �� 5�      $��3* �6(   �� 5�      $��4* �6(   �� 5�      $��5* �6(   .+�5�      + 
 %DevExpress.Xpf.LayoutControl.GroupBox  $��0��6$   4  .DevExpress.Xpf.Core.HeaderedContentControlBase%   Header$% Thông tin Hóa đơn��61   ,  &DevExpress.Xpf.Core.ContentControlBase&   Content.& 5�      � $��0,0,0,0q�6   $
��Left=�60   $	��Top=�6K   .+�5�      �� -   5        $ 
btnRefresh��5�   %   $��
Làm mới��69   $
��Left=�6K   $	��Top=�6f   $	��142��6~   $��177,-5,-109,0q�6�   $��22��5�   %   61   �� 5�      -   5        $ btnPrint��5�   %   $��IN HÓA ĐƠN��67   $
��Left=�6L   $	��Top=�6g   $	��142��6   $��177,22,-109,0q�6�   $
 None 5�   %   ���	#FF00A65A
�������$
��Bold"�6p   $��22��6�   6�   �� 5�      #��[ 6$   $��Mã số��6H   $
��Left=�6X   $	��Top=�6s   
  5�      -   5        $ 
txtOrderId��5�   +   $
��Left=�6?   $	��Top=�6Z   $	��142��6r   $��0,22,0,0q�6~   %  DevExpress.Xpf.Editors.BaseEdit'   
IsReadOnly' . #���  6�   �� 5�      #��[ 6$   $��Thời gian tạo:��6H   $
��Left=�6a   $	��Top=�6|   $��
0,53,0,-31q�6�   
  5�      -   5        $ txtOrderCreateTime��5�   +   $
��Left=�6G   $	��Top=�6b   $	��142��6z   $��
0,75,0,-53q�6�   ' . #���  6�   �� 5�      #��[ 6$   $��Tài khoản tạo:��6H   $
��Left=�6a   $	��Top=�6|   $��177,53,-40,-31q�6�   
  5�      -   5        $ txtOrderCreatedBy��5�   +   $
��Left=�6F   $	��Top=�6a   $	��142��6y   $��177,75,-109,-53q�6�   ' . #���  6�   5�      5�        5�      $��1��6$   $% Thông tin Khách hàng��61   .& 5�      � $��0,0,0,0q�6   $
��Left=�60   $	��Top=�6K   .+�5�      �� -   5        $ label_Copy50��5�   H   #��[ 6$   $��Tên Khách:��6^   $
��Left=�6s   $	��Top=�6�   
  5�      -   5        $ txtOrderGuestName��5�   +   (   	EditValue$( Khách lẻ 6F   $
��Left=�6[   $	��Top=�6v   $	��142��6�   $��0,22,0,0q�6�   ' . #���  6�   �� 5�      -   5        $ label_Copy6��5�   H   #��[ 6$   $��Số điện thoại:��6]   $
��Left=�6v   $	��Top=�6�   $��
0,52,0,-30q�6�   
  5�      -   5        $ txtOrderGuestPhone��5�   +   $
��Left=�6G   $	��Top=�6b   $	��142��6z   $��
0,74,0,-52q�6�   ' . #���  6�   �� 5�      -   5        $ label_Copy8��5�   H   #��[ 6$   $��Thư điện tử:��6]   $
��Left=�6t   $	��Top=�6�   $��177,52,-40,-30q�6�   
  5�      -   5        $ txtOrderGuestEmail��5�   +   $
��Left=�6G   $	��Top=�6b   $	��142��6z   $��177,74,-119,-52q�6�   ' . #���  6�   �� 5�      -   5        $ label_Copy9��5�   H   #��[ 6$   $��Địa chỉ:��6]   $
��Left=�6p   $	��Top=�6�   $��0,107,0,-85q�6�   
  5�      -   5        $ txtOrderGuestAddress��5�   +   $
��Left=�6I   $	��Top=�6d   $	��319��6|   $��0,129,-119,-107q�6�   ' . #���  6�   5�      5�        5�      $��2��6$   $% Thông tin Hóa đơn��61   .& 5�      � $��0,0,0,0q�6   $
��Left=�60   $	��Top=�6K   $	��219��6c   .+�5�      �� #��[ 6$   $��Tổng tiền:��6I   $
��Left=�6^   $	��Top=�6y   
  5�      -   5        $ txtOrderTotalPrice��5�   +   $
��Left=�6G   $	��Top=�6b   $	��150��6z   $��0,22,0,0q�6�   ' . #���  6�   �� 5�      #��[ 6$   $��Thuế VAT:��6H   $
��Left=�6\   $	��Top=�6w   $��169,0,-14,0q�6�   
  5�      -   5        $ txtOrderVATPrice��5�   +   $
��Left=�6E   $	��Top=�6`   $	��150��6x   $��169,22,-112,0q�6�   ' . #���  6�   �� 5�      #��[ 6$   $��Khuyến mại:��6H   $
��Left=�6^   $	��Top=�6y   $��
0,54,0,-32q�6�   
  5�      -   5        $ txtOrderDiscountPrice��5�   +   $
��Left=�6J   $	��Top=�6e   $	��150��6}   $��
0,76,0,-54q�6�   ' . #���  6�   �� 5�      #��[ 6$   $��Thanh toán:��6H   $
��Left=�6^   $	��Top=�6y   $��169,54,-25,-32q�6�   
  5�      -   5        $ txtOrderPaidPrice��5�   +   $
��Left=�6F   $	��Top=�6a   $	��150��6y   $��169,76,-112,-54q�6�   ' . #���  6�   �� 5�      -    5        $ label_Copy10��5�   $   $��	Ghi chú:��6:   $
��Left=�6M   $	��Top=�6h   $��	0,103,0,0q�6�   $	��100��6�   
  5�      -!   5        $ txtOrderDetail��5�   +   $	��Top=�6C   $
��Left=�6c   $	��Top=�6~   $	��319��6�   $��	0,130,0,0q�6�   $��68��6�   )  #DevExpress.Xpf.Editors.TextEditBase)   AcceptsReturn) . *   
AcceptsTab* . +   TextWrapping$
+ Wrap=�6�   ' . #���  6  5�      5�      5�      5�      5�      5�      5�      