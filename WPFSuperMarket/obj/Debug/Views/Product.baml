   M S B A M L   `   `   `  ����I  EWPFSuperMarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPFSuperMarket.ViewsWPFSuperMarket.Views  5      "    WPFSuperMarket.Views.Product   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:WPFSuperMarket.Views     5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      c _DevExpress.Xpf.Ribbon.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5	      Fdxbh;http://schemas.devexpress.com/winfx/2008/xaml/bars/internal  5
      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      d `DevExpress.Xpf.Docking.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxd5http://schemas.devexpress.com/winfx/2008/xaml/docking  5      f bDevExpress.Xpf.Grid.v16.2.Core, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5      -   5          � 	Resources  5      -   'WPFSuperMarket.Views.imageConvertAcount   imageConvertAcount'   !WPFSuperMarket.Views.imageConvert  imageConverter  DetailCoreTemplateProduct-  'DevExpress.Xpf.Core.MeasurePixelSnapper � RowDefinitions � ColumnDefinitions&   DevExpress.Xpf.Editors.ImageEdit   Source �� Path �� 	Converter ��Name  textBlockstyle��%g  &	        &	      &	 &     7  7  7  7    5   
   6A     5   
   66   �� 5   
   .R�5        $	��500��6%   $	��300��64   ._�5      � $
��Left=�6   $	��100��62   $	��Top=�6@   $	��637��6X    5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(    5      �� 5      $
��100* �6+   �� 5      $
��102* �6+   �� 5      $
��235* �6+   .+�5!        $
��Left=�6t   $	��Top=�6�   $	��100��6�   $	��100��6�   $��3��6�    6$   �� $ Row.Picture�8   5"      �� 5#      $ label��6   $��Tên Mặt Hàng:��6+   $��1��6C   $��Stretch=�6S   $��0��6q   $��Stretch=�6~   �� 5$      $ label1��6   $��Giá Thành:��6,   $��1��6A   $��Stretch=�6Q   $��1��6p   $��Stretch=�6}   �� 5%      $ label2��6   $��Số Lượng:��6,   $��1��6@   $��Stretch=�6P   $��2��6o   $��Stretch=�6|   �� 5&      8�� $��2��6H   $��16(�6Y   $��Stretch=�6g   $
��Wrap=�6�   $��Center=�6�   ��6�   �� *
Row.Name+6�   �� 5'      8�� $��2��6I   $��16(�6Y   $��Stretch=�6g   $��1��6�   $
��Wrap=�6�   $��Center=�6�   ��6�   �� *	Row.Price+6�   �� 5(      8�� $��2��6I   $��16(�6Y   $��Stretch=�6g   $��2��6�   $
��Wrap=�6�   $��Center=�6�   ��6�   �� *Row.Quantity+6�   5)      5*      5+      5,      .��5-      (  "DevExpress.Xpf.Docking.LayoutGroup     Orientation$ Vertical=�6      Items. 5.   
     $ 
Horizontal=�6   +  %DevExpress.Xpf.Docking.BaseLayoutItem	   
ItemHeight$	 4* �63   . 5/      (  "DevExpress.Xpf.Docking.LayoutPanel  
   
AllowClose
 .     Caption$ Danh sách Mặt hàng��61      	ItemWidth$ 2* �6N   (  "DevExpress.Xpf.Docking.ContentItem   Content. 50      %	 	 DevExpress.Xpf.Grid.GridControl	  -   5         	 Name$ gridControl1��50   "   )
  #DevExpress.Xpf.Grid.DataControlBase 
  AutoGenerateColumns$ AddNew=�68    
  
ShowBorder .   
  SelectionMode$	 Row=�6�    
  ItemsSource 6U   �� *DataProduct+ 	  View 51      # 	 DevExpress.Xpf.Grid.TableView  52      & 	  DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     RowStyle 53      �� 54   "    �� 
TargetType$ 	 DevExpress.Xpf.Grid.RowControl"  6(   .�55   &   ��  �� Property �@^�ToolTip �� Value 56   *   �� 57   .   #���  6Q   ��6=   �� 6Q   59   '   5:   #   5<      5>      5?        5@      
 .  $ Lịch sử Tồn kho��61   $ 1* �6K   . 5A      	  -   5        $ gridControlInventory��5A   "   $ AddNew=�6@    .  $	 Row=�6p    5B        5C       .  &   DevExpress.Xpf.Grid.DataViewBase    RowCellMenuCustomizations 5D      '  !DevExpress.Xpf.Bars.BarButtonItem  5E   "   -   5          Name$ printInventoryContextMenu��5E   4   !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ In Thông tin 6W      Glyph 5F   Y   *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Print_16x16.png 5H      5J      5K      5L        5M   
   -   5          Name$ 	lpProduct��5M      
 .  $ 
Chi tiết��6@   ��. $	 4* �6x   . 5N      �� $
��Auto=�6   $
��Auto=�6M   .��5O      � .+�5P      �� -   5        $ label��5P   @     
styleLabel#��[ 6   $��	Mã số:��6O   $
��Left=�6`   $	��Top=�6{   $��	10,39,0,0q�6�   �� 5Q      -   5         ��Name$ txtProductId��5Q      $
��Left=�65   $��23��6P     �� TextWrapping$
  Wrap=�6\   $	��Top=�6p   $	��108��6�   $��	10,61,0,0q�6�   ! �� 
IsReadOnly! . " J� RenderTransformOrigin$" 0.478,0.522&�6�   {�.    styleTextBox#���  6�   �� 5R      -   5        $ 
label_Copy��5R      $��Tên Mặt hàng:��60   $
��Left=�6H   $	��Top=�6c   $��
230,90,0,0q�6{   #��[ 6�   �� 5S      -	   5        $ label_Copy1��5S      $��Loại Mặt hàng:��61   $
��Left=�6J   $	��Top=�6e   $��
455,90,0,0q�6}   #��[ 6�   %  DevExpress.Xpf.Editors.TextEdit  5T      -
   5        #  Name$# txtProductName��5T   #   $
��Left=�6;   $	��Top=�6V   $	��200��6n   $��230,117,0,0q�6z     styleTextEdit#���  6�   �� 5U      -   5        $ label_Copy2��5U      $��Thời gian tạo:��61   $
��Left=�6J   $	��Top=�6e   $��
148,39,0,0q�6}   #��[ 6�   �� 5V      -   5        $ txtProductCreateTime��5V      $
��Left=�6<   $��23��6W   $
  Wrap=�6c   $	��Top=�6w   $	��108��6�   $��
148,61,0,0q�6�   ! . {�.  #���  6�   �� 5W      -   5        $ label_Copy3��5W      $��Tài khoản tạo:��61   $
��Left=�6J   $	��Top=�6e   $��
291,39,0,0q�6}   $" 0.863,-6.364&�6�   #��[ 6�   �� 5X      -   5        $ txtProductCreatedBy��5X      $
��Left=�6;   $��23��6V   $
  Wrap=�6b   $	��Top=�6v   $	��108��6�   $��
291,61,0,0q�6�   ! . {�.  #���  6�   �� 5Y      -   5        $ ��Name$$ cbProductType��5Y      $
��Left=�66   $	��Top=�6Q   $	��200��6i   $��456,117,0,0q�6u   �� 5Z      -   5        $ label_Copy7��5Z      $��Chi tiết:��61   $
��Left=�6E   $	��Top=�6`   $��
10,144,0,0q�6x   #��[ 6�   �� 5[      -   5        % ��Name$% btnAddProduct��5[      $��Tạo mới��64   $
��Left=�6F   $��	10,10,0,0q�6a   $	��Top=�6t   $��85��6�   $��22��6�   $��5,0,5,0q�6�   &   DevExpress.Xpf.Core.ThemeManager&   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$
& None 6�   ���	#FF00A65A
�������6	  �� 5\      -   5        $% btnSaveChangeProduct��5\      $��Lưu thay đổi��6;   $
��Left=�6R   $��
157,10,0,0q�6m   $	��Top=�6�   $��99��6�   ���	#FF3C8DBC$
& None 6�   $��22��6   
�������6  �� 5]      -   5        $ % btnSaveChangeProductCancel��5]      $��Hủy thay đổi��6A   $
��Left=�6X   $	��Top=�6s   $��99��6�   $��
261,10,0,0q�6�   6�   �� 5^      -   5        $% btnAddProduct_Cancel��5^      $��Hủy��6;   $
��Left=�6I   $	��Top=�6d   $��52��6|   $" 0.707,0.682&�6�   $��
100,10,0,0q�6�   {�.  6�     5_      -   5        $# txtProductDetail��5_   #   $	��Top=�6=   $
��Left=�6]   $	��Top=�6x   $	��426��6�   $��
10,171,0,0q�6�   $��60��6�   )  #DevExpress.Xpf.Editors.TextEditBase'   AcceptsReturn' . (   
AcceptsTab( . )   TextWrapping$
) Wrap=�6�   #���  6�   �� 5`      -   5        $% btnDeleteProduct��5`      $��Xóa Mặt hàng��67   $
��Left=�6N   $��
456,10,0,0q�6i   $	��Top=�6}   $	��100��6�   $" 0.893,16.591&�6�   $
& None 6�   ���	#FFDD4B39
�������$��22��60  �� 5a      -   5        $ label_Copy4��5a      $��Mã vạch:��61   $
��Left=�6D   $	��Top=�6_   $��	10,90,0,0q�6w   #��[ 6�     5b      -   5        $# txtProductBarCode��5b   #   $
��Left=�6>   $	��Top=�6Y   $	��200��6q   $��
10,117,0,0q�6}   #���  6�   �� 5c      -   5        $ label_Copy5��5c      $��Giá tiền:��61   $
��Left=�6E   $	��Top=�6`   $��
456,39,0,0q�6x   #��[ 6�     5d      -   5        $# txtProductPrice��5d   #   $
��Left=�6<   $	��Top=�6W   $	��200��6o   $��
456,61,0,0q�6{   #���  6�     5e      -   5        *  Name$* imageProductPicture��5e   $   $
��Left=�6A   $��
902,90,0,0q�6\   $	��Top=�6p   $	��180��6�   $L Fpack://application:,,,/WPFSuperMarket;component/Images/Product-256.png��6�   $	��180��6�   6�   �� 5f      -   5        $%% btnSaveChangeProductCancel_Copy��5f      $��
Làm mới��6F   $
��Left=�6X   $	��Top=�6s   $��99��6�   $��
557,90,0,0q�6�   6�   �� 5g      $��
Tồn kho:��6   $
��Left=�6/   $	��Top=�6J   $��
683,39,0,0q�6b   #��[ 6v     5h      -   5        $# txtProductQuantity��5h   #   $
��Left=�6?   $	��Top=�6Z   $	��115��6r   $��
683,61,0,0q�6~   %  DevExpress.Xpf.Editors.BaseEdit+   
IsReadOnly+ . {�.  #���  6�   �� 5i      $��Ngày Hết hạn:��6   $
��Left=�64   $	��Top=�6O   $��
683,90,0,0q�6g   #��[ 6{   %  DevExpress.Xpf.Editors.DateEdit  5j      -   5        ,  Name$, dateExpiredTime��5j   #   $
��Left=�6<   $��683,117,0,0q�6W   $	��Top=�6l   $	��200��6�   -   DateTime$- 12/24/2016 00:00:00��6�   .   MaskCulture$. en-US��6�   /   Mask$/ 
dd/MM/yyyy��6�   �� 5l      $��Tình trạng:��6   $
��Left=�62   $	��Top=�6M   $��456,160,0,0q�6e   #��[ 6z     5m      -   5        $# txtProductStatus��5m   #   $
��Left=�6=   $	��Top=�6X   $	��427��6p   $��456,182,0,0q�6|   + . #���  6�   �� 5n      -    5        $% btnUpdateInventory��5n      $��Cập nhật��69   $
��Left=�6L   $��
803,61,0,0q�6g   $	��Top=�6{   $��80��6�   ���#00a65a$
& None 6�   $��22��6�   
�������$" 2.125,0.773&�6    5o      -!   5        $# 	txtSearch��5o   #   $
��Left=�66   $	��Top=�6Q   $	��219��6i   $��
683,10,0,0q�6u   #���  6�   �� 5p      -"   5        $% 	btnSearch��5p      $��Tìm kiếm��60   $
��Left=�6C   $��
902,10,0,0q�6^   $	��Top=�6r   $��80��6�   ���#00a65a$
& None 6�   $��22��6�   
�������$" 2.125,0.773&�6  �� 5q      -#   5        $% 
btnRefresh��5q      $��
Làm mới��61   $
��Left=�6C   $	��Top=�6^   $��95��6v   $��
987,10,0,0q�6�   6�   �� 5r      -$   5        $% btnPause��5r      $��Tạm ngưng��6/   $
��Left=�6C   $��
561,10,0,0q�6^   $	��Top=�6r   $��95��6�   $" 0.893,16.591&�6�   $
& None 6�   ���#f39c12
�������$��22��6  5s      5u      5v      5w      5x      