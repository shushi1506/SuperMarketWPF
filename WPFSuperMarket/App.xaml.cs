using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using WPFSuperMarket.Controllers;
using WPFSuperMarket.Views;

namespace WPFSuperMarket
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AccountController accountController;
        public static ProductTypeController productTypeController;
        public static ProductController productController;
        public static OrderController orderController;
        public static InventoryController inventoryController;
        public static ConnectionController connectionController;

        public static MainWindow mainWindow;

        public static string BaseDirectory { get; set; }
        public static string BaseImageDirectory { get; set; }
        public static string DefaultAccountImagePath { get; set; }
        public static string DefaultProductImagePath { get; set; }
        public static string DefaultExportOrderPath { get; set; }
        public static string DefaultInventoryPath { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DevExpress.Xpf.Core.ApplicationThemeHelper.ApplicationThemeName = "Office2010Blue";
            DevExpress.Xpf.Core.ApplicationThemeHelper.UpdateApplicationThemeName();

            accountController = new AccountController();
            productTypeController = new ProductTypeController();
            productController = new ProductController();
            orderController = new OrderController();
            inventoryController = new InventoryController();
            connectionController = new ConnectionController();

            BaseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            BaseImageDirectory = BaseDirectory + "Data\\Images\\";
            DefaultAccountImagePath = BaseImageDirectory + "user-1-glyph-icon.png";
            DefaultProductImagePath = BaseImageDirectory + "Product-256.png";
            DefaultExportOrderPath = BaseDirectory + "Data\\GuessInvoice\\";
            DefaultInventoryPath = BaseImageDirectory + "Data\\Inventories\\";

            System.IO.Directory.CreateDirectory(BaseImageDirectory);
            System.IO.Directory.CreateDirectory(DefaultExportOrderPath);
            System.IO.Directory.CreateDirectory(DefaultInventoryPath);
            System.IO.Directory.CreateDirectory(BaseImageDirectory + "Product\\"); 
        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            DevExpress.Xpf.Core.ApplicationThemeHelper.SaveApplicationThemeName();
        }

        private void OnAppStartup_UpdateThemeName(object sender, StartupEventArgs e)
        {
            DevExpress.Xpf.Core.ApplicationThemeHelper.UpdateApplicationThemeName();
        }

        public static void ShowMainWindow(Login login)
        {
            mainWindow = new WPFSuperMarket.MainWindow();
            mainWindow.Show();
            login.Close();
        }
    }
}
