using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Layout.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using System.ComponentModel;
using System.Collections.ObjectModel;
using DevExpress.Xpf.NavBar;
using DevExpress.Xpf.Charts;
using WPFSuperMarket.Views;
using WPFSuperMarket.Models;

namespace WPFSuperMarket
{
    public partial class MainWindow : DXRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DocumentPanel panelNewOrder;
            


            Models.Account account = App.accountController.Account;
            if (account.Admin.HasValue  && account.Admin.Value == 1)
            {
                DocumentPanel panelAccount
                       = new DocumentPanel()
                       {
                           Content = new Uri(@"Views\Account.xaml", UriKind.Relative),
                           Caption = "Quản lý Tài khoản"
                       };
                documentGroup.Items.Add(panelAccount);
                dockLayoutManager.DockController.Activate(panelAccount);
               
            }
            if (account.Admin.HasValue && account.Admin.Value == 2)
            {
                panelNewOrder = new DocumentPanel()
                {
                    Content = new Uri(@"Views\NewOrder.xaml", UriKind.Relative),
                    Caption = "Hóa đơn mới"
                };
                documentGroup.Items.Add(panelNewOrder);
                dockLayoutManager.DockController.Activate(panelNewOrder);
                
            }
            if (account.Admin.HasValue && account.Admin.Value == 3)
            {
                panelNewOrder = new DocumentPanel()
                {
                    Content = new Uri(@"Views\NewOrder.xaml", UriKind.Relative),
                    Caption = "Hóa đơn mới"
                };
                documentGroup.Items.Add(panelNewOrder);
                dockLayoutManager.DockController.Activate(panelNewOrder);

                layoutNavigations.Visibility = Visibility.Collapsed;
                bAccount.IsVisible = false;
                rpgOrder.IsVisible = false;
                rpgProduct.IsVisible = false;
                panelNewOrder.AllowClose = false;
            }
            if (account.Admin.HasValue && account.Admin.Value == 4)
            {
                DocumentPanel panelProduct
                        = new DocumentPanel()
                        {
                            Content = new Uri(@"Views\Product.xaml", UriKind.Relative),
                            Caption = "Danh mục Mặt hàng"
                        };
                documentGroup.Items.Add(panelProduct);
                dockLayoutManager.DockController.Activate(panelProduct);
                navAccount.IsVisible = false;
                navHoadon.IsVisible = false;
                bAccount.IsVisible = false;
                rpgOrder.IsVisible = false;
                rpgProduct.IsVisible = true;
                
            }
        }

        private void navAccount_Click(object sender, EventArgs e)
        {
            try
            {
                DocumentPanel getPanelAccount = documentGroup.Items.SingleOrDefault(m => m.Caption.Equals("Quản lý Tài khoản")) as DocumentPanel;
                if (getPanelAccount == null)
                {
                    DocumentPanel panelAccount
                        = new DocumentPanel()
                        {
                            Content = new Uri(@"Views\Account.xaml", UriKind.Relative),
                            Caption = "Quản lý Tài khoản"
                        };
                    documentGroup.Items.Add(panelAccount);
                    dockLayoutManager.DockController.Activate(panelAccount);
                }
                else
                {
                    dockLayoutManager.DockController.Activate(getPanelAccount);
                }
            }
            catch (Exception)
            {

            }
        }

        private void navProduct_Click(object sender, EventArgs e)
        {
            try
            {
                DocumentPanel getPanelProduct = documentGroup.Items.SingleOrDefault(m => m.Caption.Equals("Danh mục Mặt hàng")) as DocumentPanel;
                if (getPanelProduct == null)
                {
                    DocumentPanel panelProduct
                        = new DocumentPanel()
                        {
                            Content = new Uri(@"Views\Product.xaml", UriKind.Relative),
                            Caption = "Danh mục Mặt hàng"
                        };
                    documentGroup.Items.Add(panelProduct);
                    dockLayoutManager.DockController.Activate(panelProduct);
                }
                else
                {
                    dockLayoutManager.DockController.Activate(getPanelProduct);
                }
            }
            catch (Exception)
            {

            }
        }

        private void navProductType_Click(object sender, EventArgs e)
        {
            try
            {
                DocumentPanel getPanelProductType = documentGroup.Items.SingleOrDefault(m => m.Caption.Equals("Danh mục Loại Mặt hàng")) as DocumentPanel;
                if (getPanelProductType == null)
                {
                    DocumentPanel panelProductType
                        = new DocumentPanel()
                        {
                            Content = new Uri(@"Views\ProductType.xaml", UriKind.Relative),
                            Caption = "Danh mục Loại Mặt hàng"
                        };
                    documentGroup.Items.Add(panelProductType);
                    dockLayoutManager.DockController.Activate(panelProductType);
                }
                else
                {
                    dockLayoutManager.DockController.Activate(getPanelProductType);
                }
            }
            catch (Exception)
            {

            }
        }

        private void navOrder_Click(object sender, EventArgs e)
        {
            try
            {
                DocumentPanel getPanelOrder = documentGroup.Items.SingleOrDefault(m => m.Caption.Equals("Danh mục Hóa đơn")) as DocumentPanel;
                if (getPanelOrder == null)
                {
                    DocumentPanel panelOrder
                        = new DocumentPanel()
                        {
                            Content = new Uri(@"Views\Order.xaml", UriKind.Relative),
                            Caption = "Danh mục Hóa đơn"
                        };
                    documentGroup.Items.Add(panelOrder);
                    dockLayoutManager.DockController.Activate(panelOrder);
                }
                else
                {
                    dockLayoutManager.DockController.Activate(getPanelOrder);
                }
            }
            catch (Exception)
            {

            }
        }

        private void navNewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                DocumentPanel getPanelNewOrder = documentGroup.Items.SingleOrDefault(m => m.Caption.Equals("Hóa đơn mới")) as DocumentPanel;
                if (getPanelNewOrder == null)
                {
                    DocumentPanel panelNewOrder
                        = new DocumentPanel()
                        {
                            Content = new Uri(@"Views\NewOrder.xaml", UriKind.Relative),
                            Caption = "Hóa đơn mới"
                        };
                    documentGroup.Items.Add(panelNewOrder);
                    dockLayoutManager.DockController.Activate(panelNewOrder);
                }
                else
                {
                    dockLayoutManager.DockController.Activate(getPanelNewOrder);
                }
            }
            catch (Exception)
            {

            }
        }

        private void bExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show(
                "Bạn chắc chắn muốn thoát", 
                "Thoát chương trình",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void navInventory_Click(object sender, EventArgs e)
        {

        }
    }

}
