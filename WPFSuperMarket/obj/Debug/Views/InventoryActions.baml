   M S B A M L   `   `   `  ����I  EWPFSuperMarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPFSuperMarket.ViewsWPFSuperMarket.Views  5   	   +    %WPFSuperMarket.Views.InventoryActions   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WPFSuperMarket.Views     5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5        � Title$  Cập nhật Tồn kho��5
   	   $	��337��6"   $	��464��6/   .��5      � .+�5   
   �� -   5         ��Name$ label��5      $	��Top=�6   $��	10,48,0,0q�67   $
��Left=�6J   $��	Mã số:��6e   �� 5   
   -   5         ��Name$ txtProductId��5      $	��108��6(   $	��Top=�64    �� TextWrapping$
 Wrap=�6L    J� RenderTransformOrigin$ 0.478,0.522&�6`   $��	10,70,0,0q�6�   {�.   �� 
IsReadOnly . $��23��6�   $
��Left=�6�      styleTextBox#���   6�   �� 5   
   -   5        $ 
label_Copy��5      $	��Top=�6$   $��
230,99,0,0q�6<   $
��Left=�6P   $��Tên Mặt hàng:��6k   {�.  6�   %  DevExpress.Xpf.Editors.TextEdit  5   
   -   5          Name$ txtProductName��5      $
��Left=�6/   $	��Top=�6J   $	��200��6b   $��230,126,0,0q�6n   {�.  %  DevExpress.Xpf.Editors.BaseEdit   
IsReadOnly .   styleTextEdit#���  6�   �� 5   
   -   5        $ label_Copy2��5      $��Thời gian tạo:��6%   $
��Left=�6>   $	��Top=�6Y   $��
148,48,0,0q�6q   �� 5   
   -   5        $ txtProductCreateTime��5      $
��Left=�60   $��23��6K   $
 Wrap=�6W   $	��Top=�6k   $	��108��6�   $��
148,70,0,0q�6�    . {�.  #���   6�   �� 5   
   -   5        $ label_Copy3��5      $��Tài khoản tạo:��6%   $
��Left=�6>   $	��Top=�6Y   $��
291,48,0,0q�6q   $ 0.863,-6.364&�6�   �� 5   
   -   5        $ txtProductCreatedBy��5      $
��Left=�6/   $��23��6J   $
 Wrap=�6V   $	��Top=�6j   $	��108��6�   $��
291,70,0,0q�6�    . {�.  #���   6�   �� 5   
   -	   5        $ label_Copy7��5      $��Chi tiết:��6%   $
��Left=�69   $	��Top=�6T   $��
10,153,0,0q�6l     5   
   -
   5        $ txtProductDetail��5      $	��Top=�61   $
��Left=�6Q   $	��Top=�6l   $	��426��6�   $��
10,180,0,0q�6�   $��75��6�   )  #DevExpress.Xpf.Editors.TextEditBase   AcceptsReturn . 	   
AcceptsTab	 . 
   TextWrapping$

 Wrap=�6�   #���  6�   �� 5   
   -   5        $ label_Copy4��5      $��Mã vạch:��6%   $
��Left=�68   $	��Top=�6S   $��	10,99,0,0q�6k   {�.  6~     5   
   -   5        $ txtProductBarCode��5      $
��Left=�62   $	��Top=�6M   $	��200��6e   $��
10,126,0,0q�6q   {�.   . #���  6�   �� 5   
   $��Số lượng:��6   $
��Left=�6$   $	��Top=�6?   $��	10,10,0,0q�6W     5   
   -   5        $ txtProductQuantity��5      $
��Left=�63   $	��Top=�6N   $	��115��6f   $��	75,10,0,0q�6r   #���  6�   �� 5   
   $��Ngày Hết hạn:��6   $
��Left=�6(   $	��Top=�6C   $��
240,10,0,0q�6[   $ 1.053,0.455&�6o   %  DevExpress.Xpf.Editors.DateEdit  5   
   -   5          Name$ dateExpiredTime��5      $
��Left=�60   $��
321,10,0,0q�6K   $	��Top=�6_   $	��115��6w      DateTime$ 12/24/2016 00:00:00��6�      MaskCulture$ en-US��6�      Mask$ 
dd/MM/yyyy��6�   {�.  6�   �� 5   
   -   5         ��Name$ 	btnUpdate��5      $��CẬP NHẬT��6$   $
��Left=�67   $��
10,260,0,0q�6R   $	��Top=�6f   $	��100��6~   &   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$
 None 5      ���	#FF00A65A
�������$��26��6\   6h   �� 5   
   -   5        $ btnIn��5      $��
NHẬP KHO��6    $
��Left=�63   $��120,260,0,0q�6N   $	��Top=�6c   $	��100��6{   $
 None 5       ���#3c8dbc
�������$��26��6V   6b   �� 5!   
   -   5        $ btnOut��5!      $��
XUẤT KHO��6!   $
��Left=�64   $��230,260,0,0q�6O   $	��Top=�6d   $	��100��6|   $
 None 5"      ���#f39c12
�������$��26��6V   6b   �� 5#   
   -   5        $ 	btnCancel��5#      $��Hủy��6$   $
��Left=�62   $��350,260,0,0q�6M   $	��Top=�6b   $��86��6z   $��26��6�   6�   5%      5&      