   M S B A M L   `   `   `  ����I  EWPFSuperMarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPFSuperMarketWPFSuperMarket  5      ;"clr-namespace:WPFSuperMarket.ViewsWPFSuperMarket.Views  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5          WPFSuperMarket.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .localclr-namespace:WPFSuperMarket     5      4views"clr-namespace:WPFSuperMarket.Views     5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      c _DevExpress.Xpf.Ribbon.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      Fdxbh;http://schemas.devexpress.com/winfx/2008/xaml/bars/internal  5	      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5
      d `DevExpress.Xpf.Docking.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxd5http://schemas.devexpress.com/winfx/2008/xaml/docking  5      f	 bDevExpress.Xpf.Grid.v16.2.Core, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa
 ]DevExpress.Xpf.Grid.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid 	 
 5      Fcollections2clr-namespace:System.Collections;assembly=mscorlib 	 
 5      c _DevExpress.Xpf.NavBar.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxnb4http://schemas.devexpress.com/winfx/2008/xaml/navbar  5      c _DevExpress.Xpf.Charts.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6B   $	��700��5   )   $
��1300��66     J� SnapsToDevicePixels  .  � UseLayoutRounding .  � Title$ Quản Lý Siêu Thị��5   9    � Icon$M Gpack://application:,,,/WPFSuperMarket;component/shopping-cart%20(2).ico��6R   .��5   
   ]� .+�5      )  #DevExpress.Xpf.Ribbon.RibbonControl  -   5          Name$ ribbonControl1��5          RibbonStyle$ 
Office2007=�68   $	��Top=�6Q      IsMinimized .    AllowMinimizeRibbon .    ToolbarShowMode$
 Hide=�6�   	   ShowApplicationButton	 .  
   
Categories.
 5      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase   	IsVisible .     Pages. 5      &   DevExpress.Xpf.Ribbon.RibbonPage     Caption)  #DevExpress.Xpf.Core.ObjectConverter$ Trang chính 6%      Groups. 5      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup     Caption$ Trang chính��6.      Items. 5      '  !DevExpress.Xpf.Bars.BarButtonItem  -   5          Name$ bExit��5   0   !  DevExpress.Xpf.Bars.BarItem   Content$ Thoát 6?      RibbonStyle$ Large=�6�      Glyph 6O   *	  $DevExpress.Xpf.Core.DXImageExtension	   	  Image1
  +DevExpress.Xpf.Core.Native.DXImageConverter$ Left_16x16.png
    
LargeGlyph 6y   	  $ Left_32x32.png
 6�     5      -   5        $ bAccount��5   0   $ Tài khoản 6B   $ Large=�6�    6V   	  $ BOUser_16x16.png
  6�   	  $ BOUser_32x32.png
 6�   5        5      -   5          Name$ 
rpgProduct��5   A   $ Mặt hàng��6.   . 5        -   5        $ bProduct��5   0   $ Danh mục Mặt hàng 6B   $ Large=�6�    6^   	  $ BOProductGroup_16x16.png
  6�   	  $ BOProductGroup_32x32.png
 6�     5       -   5        $ bProductType��5    0   $ Loại Mặt hàng 6F   $ Large=�6�    6^   	  $ PackageProduct_16x16.png
  6�   	  $ PackageProduct_32x32.png
 6�   5!        5"      -   5        $ rpgOrder��5"   @   $ 
Hóa đơn��6.   . 5#        -   5        $ 	bNewOrder��5#   0   $ Hóa đơn mới 6C   $ Large=�6�    6Y   	  $ BOOrder_16x16.png
  6�   	  $ BOOrder_32x32.png
 6�     5$      -	   5        $ bOrder��5$   0   $ Danh mục Hóa đơn 6@   $ Large=�6�    6[   	  $ BOOrder_16x16.png
  6�   	  $ BOOrder_32x32.png
 6�   5%      5&      5'      5(      .  (DevExpress.Xpf.Docking.DockLayoutManager  5)      -
   5          Name$ dockLayoutManager��5)   $      
LayoutRoot. 5*      (  "DevExpress.Xpf.Docking.LayoutGroup     Orientation$ 
Horizontal=�6"      Items. 5+      (  "DevExpress.Xpf.Docking.LayoutPanel  -   5          Name$ layoutNavigations��5+   &   +  %DevExpress.Xpf.Docking.BaseLayoutItem   
AllowClose .     	ItemWidth$	 200 �6T      Caption$ 
Danh mục��6d       Padding$  1q�6w   (  "DevExpress.Xpf.Docking.ContentItem!   Content.! 5,      )  #DevExpress.Xpf.NavBar.NavBarControl  -   5        "  Name$" navBarControl��5,   -   $��Stretch=�6D   $��Stretch=�6b   #   View# 5-      +  %DevExpress.Xpf.NavBar.ExplorerBarView  5.   "   $   Groups.$ 50      '  !DevExpress.Xpf.NavBar.NavBarGroup  -   5        %  Name$% 
navAccount��50   /   &   Header$& Tài khoản 6C   '   
IsExpanded' .  (   GroupScrollMode$( ButtonsX�6�   )   DisplaySource$) Items=�6�   *   ImageSource* 6V   	  $ BOUser_32x32.png
 +   Items.+ 51   "   &   DevExpress.Xpf.NavBar.NavBarItem  -   5        ,   Content$, Danh mục Tài khoản 51   2   -   ImageSource- 6O   	  $ BOUser_16x16.png
 6�   52        53      -   5        $% 
navMathang��53   /   $& Mặt hàng 6C   * 6U   	  $ BOProductGroup_32x32.png
 .+ 54   "     -   5        .  Name$. navProducts��54   2   $, Danh mục Mặt hàng 6G   - 6c   	  $ BOProductGroup_32x32.png
 6�     55   "   -   5        $. navProductTypes��55   2   $, Loại Mặt hàng 6K   - 6c   	  $ PackageProduct_32x32.png
 6�   56        57      -   5        $% 	navHoadon��57   /   $& 
Hóa đơn 6B   * 6S   	  $ BOOrder_32x32.png
 .+ 58   "     -   5        $. navNewOrder��58   2   $, Hóa đơn mới 6G   - 6]   	  $ BOOrder_16x16.png
 6�     59   "   -   5        $. navOrder��59   2   $, Danh mục Hóa đơn 6D   - 6_   	  $ BOOrder_16x16.png
 6�   5:        5;      $& 	Tồn kho 6/   /   	IsVisible/ .  * 6@   	  $ BOReport_32x32.png
 .+ 5<   "     -   5        $. navInventory��5<   2   $, 	Tồn kho 6H   - 6Z   	  $ BOReport_16x16.png
 6�   5=      5>      5?      *  $DevExpress.Xpf.Docking.DocumentGroup  5@      -   5        0  Name$0 documentGroup��5@   (   1   DestroyOnClosingChildren1 .  2   MDIStyle$2 Tabbed=�6`   3   ClosePageButtonShowMode$3 InAllTabPageHeaders=�6r   5A      5B      5D      5E      5G      