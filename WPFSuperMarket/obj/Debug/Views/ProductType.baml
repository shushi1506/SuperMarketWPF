   M S B A M L   `   `   `  ����I  EWPFSuperMarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPFSuperMarket.ViewsWPFSuperMarket.Views  5      &     WPFSuperMarket.Views.ProductType   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:WPFSuperMarket.Views     5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      c _DevExpress.Xpf.Ribbon.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5	      Fdxbh;http://schemas.devexpress.com/winfx/2008/xaml/bars/internal  5
      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      d `DevExpress.Xpf.Docking.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxd5http://schemas.devexpress.com/winfx/2008/xaml/docking  5      f bDevExpress.Xpf.Grid.v16.2.Core, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5      -   5        .��5      (  "DevExpress.Xpf.Docking.LayoutGroup      Orientation$  Vertical=�6      Items. 5   
     $  Vertical=�6   +  %DevExpress.Xpf.Docking.BaseLayoutItem   
ItemHeight$ 4* �61   . 5      (  "DevExpress.Xpf.Docking.LayoutPanel     
AllowClose .     Caption$# Danh sách Loại Mặt hàng��61   (  "DevExpress.Xpf.Docking.ContentItem   Content. 5      % 	 DevExpress.Xpf.Grid.GridControl  -   5          Name$ gridControl1��5   "   )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$ AddNew=�68      
ShowBorder .  	   SelectionMode$		 Row=�6h   
   View
 5      # 	 DevExpress.Xpf.Grid.TableView  5      & 	  DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  6(   5      5      5        5   
    .  $ 
Chi tiết��6-   ��. $ 2* �6e   . 5      �� $
��Auto=�6   $
��Auto=�6M   .��5      � .+�5      �� -   5         ��Name$ label��5      $��	Mã số:��6+   $
��Left=�6<   $	��Top=�6W   $��	10,39,0,0q�6o      
styleLabel#���   6�   �� 5      -   5         ��Name$ txtProductTypeId��5      $
��Left=�68   $��23��6S    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��108��6�   $��	10,61,0,0q�6�    �� 
IsReadOnly .  J� RenderTransformOrigin$ 0.478,0.522&�6�   {�.    styleTextBox#���  6�   �� 5      -   5        $ 
label_Copy��5      $��Tên Loại Mặt hàng:��60   $
��Left=�6M   $	��Top=�6h   $��	10,92,0,0q�6�   #���   6�   �� 5       -   5        $ label_Copy1��5       $��Loại Mặt hàng cha:��61   $
��Left=�6N   $	��Top=�6i   $��
290,92,0,0q�6�   #���   6�   %	  DevExpress.Xpf.Editors.TextEdit	  5!      -   5         	 Name$ txtProductTypeName��5!   #   $
��Left=�6?   $	��Top=�6Z   $	��246��6r   $��
10,119,0,0q�6~     styleTextEdit#���  6�   �� 5"      -   5        $ label_Copy2��5"      $��Thời gian tạo:��61   $
��Left=�6J   $	��Top=�6e   $��
148,39,0,0q�6}   #���   6�   �� 5#      -	   5        $ txtProductTypeCreateTime��5#      $
��Left=�6@   $��23��6[   $
 Wrap=�6g   $	��Top=�6{   $	��108��6�   $��
148,61,0,0q�6�    . {�.  #���  6�   �� 5$      -
   5        $ label_Copy3��5$      $��Tài khoản tạo:��61   $
��Left=�6J   $	��Top=�6e   $��
291,41,0,0q�6}   $ 0.863,-6.364&�6�   #���   6�   �� 5%      -   5        $ txtProductTypeCreatedBy��5%      $
��Left=�6?   $��23��6Z   $
 Wrap=�6f   $	��Top=�6z   $	��108��6�   $��
291,61,0,0q�6�    . {�.  #���  6�   �� 5&      -   5         ��Name$ cbProductTypeParentName��5&      $
��Left=�6@   $	��Top=�6[   $	��245��6s   $��291,119,0,0q�6   �� 5'      -   5        $ label_Copy7��5'      $��
Chi tiết��61   $
��Left=�6D   $	��Top=�6_   $��
581,41,0,0q�6w   #���   6�   �� 5(      -   5         ��Name$ btnAddProductType��5(      $��Tạo mới��68   $
��Left=�6J   $��	10,10,0,0q�6e   $	��Top=�6x   $��85��6�   $��22��6�   $��5,0,5,0q�6�   &
   DevExpress.Xpf.Core.ThemeManager 
  	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$
 None 6�   ���	#FF00A65A
�������6  �� 5)      -   5        $ btnSaveChangeProductType��5)      $��Lưu thay đổi��6?   $
��Left=�6V   $��
157,10,0,0q�6q   $	��Top=�6�   $��99��6�   ���	#FF3C8DBC$
 None 6�   $��22��6  
�������6  �� 5*      -   5        $$ btnSaveChangeProductTypeCancel��5*      $��Hủy thay đổi��6E   $
��Left=�6\   $	��Top=�6w   $��99��6�   $��
261,10,0,0q�6�   6�   �� 5+      -   5        $ btnAddProductType_Cancel��5+      $��Hủy��6?   $
��Left=�6M   $	��Top=�6h   $��52��6�   $ 0.707,0.682&�6�   $��
100,10,0,0q�6�   {�.  6�   	  5,      -   5        $ txtProductTypeDetail��5,   #   $	��Top=�6A   $
��Left=�6a   $	��Top=�6|   $	��305��6�   $��
581,61,0,0q�6�   $��80��6�   )  #DevExpress.Xpf.Editors.TextEditBase   AcceptsReturn .    
AcceptsTab .    TextWrapping$
 Wrap=�6�   #���  6�   �� 5-      -   5        $ btnDeleteProductType��5-      $��Xóa Loại Mặt hàng��6;   $
��Left=�6W   $��
365,10,0,0q�6r   $	��Top=�6�   $	��126��6�   $ 0.893,16.591&�6�   $
 None 6�   ���	#FFDD4B39
�������$��22��6=  	  5.      -   5        $ 	txtSearch��5.   #   $
��Left=�66   $	��Top=�6Q   $	��200��6i   $��
686,10,0,0q�6u   #���  6�   �� 5/      -   5        $ 	btnSearch��5/      $��Tìm kiếm��60   $
��Left=�6C   $��
902,10,0,0q�6^   $	��Top=�6r   $��80��6�   ���#00a65a$
 None 6�   $��22��6�   
�������$ 2.125,0.773&�6  �� 50      -   5        $ 
btnRefresh��50      $��
Làm mới��61   $
��Left=�6C   $	��Top=�6^   $��95��6v   $��
987,10,0,0q�6�   6�   51      53      54      55      56      