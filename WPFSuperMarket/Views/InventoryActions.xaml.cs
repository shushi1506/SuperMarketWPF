using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFSuperMarket.Views
{
    /// <summary>
    /// Interaction logic for InventoryActions.xaml
    /// </summary>
    public partial class InventoryActions : Window
    {
        private Models.Product _product;

        public InventoryActions()
        {
            InitializeComponent();
        }

        public InventoryActions(Models.Product product): this()
        {
            _product = product;

            txtProductQuantity.Text = product.Quantity.HasValue ? product.Quantity.Value.ToString() : "0";
            txtProductBarCode.Text = product.BarCode;
            txtProductName.Text = product.Name;

            txtProductId.Text = product.Id.ToString();
            txtProductCreateTime.Text = product.CreateTime.ToString("dd/MM/yyyy");
            txtProductCreatedBy.Text = product.Account ? .Name ?? "";

            if (product.ExpiredTime.HasValue)
            {
                dateExpiredTime.EditValue = product.ExpiredTime;
            }
            else
            {
                dateExpiredTime.Clear();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int Quantity = 0;
            try
            {
                Quantity = Convert.ToInt32(txtProductQuantity.Text);
                if (Quantity <= 0)
                {
                    MessageBox.Show(
                        "Số lượng không hợp lệ",
                        "Cập nhật Tồn kho",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Số lượng không hợp lệ",
                    "Cập nhật Tồn kho",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show(
                    "Bạn chắc chắn muốn cập nhật tồn kho, số lượng: " + txtProductQuantity.Text,
                    "Cập nhật Tồn kho",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                ) == MessageBoxResult.Yes)
            {
                Models.Inventory inventory = new Models.Inventory();
                inventory.ProductId = _product.Id;
                inventory.AccountId = App.accountController.Account.Id;
                inventory.Detail = txtProductDetail.Text;
                inventory.Type = 0;
                inventory.Quantity = Quantity;

                if (App.inventoryController.Update(inventory))
                {
                    if (MessageBox.Show(
                        "Cập nhật thành công." + '\n'
                        + "Bạn có muốn in sao kê?",
                       "Cập nhật Tồn kho",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        App.inventoryController.Export(inventory.Id);
                    }

                    this.Close();
                }
            }
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            int Quantity = 0;
            try
            {
                Quantity = Convert.ToInt32(txtProductQuantity.Text);
                if (Quantity <= 0)
                {
                    MessageBox.Show(
                        "Số lượng không hợp lệ",
                        "Nhập kho",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Số lượng không hợp lệ",
                    "Nhập kho",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show(
                    "Bạn chắc chắn muốn nhập kho, số lượng: " + txtProductQuantity.Text,
                    "Nhập kho",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                ) == MessageBoxResult.Yes)
            {
                Models.Inventory inventory = new Models.Inventory();
                inventory.ProductId = _product.Id;
                inventory.AccountId = App.accountController.Account.Id;
                inventory.Detail = txtProductDetail.Text;
                inventory.Type = 1;
                inventory.Quantity = Quantity;

                if (App.inventoryController.In(inventory))
                {
                    if (MessageBox.Show(
                        "Nhập kho thành công." + '\n'
                        + "Bạn có muốn in sao kê?",
                        "Nhập kho",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        App.inventoryController.Export(inventory.Id);
                    }

                    this.Close();
                }
            }
        }

        private void btnOut_Click(object sender, RoutedEventArgs e)
        {
            int Quantity = 0;
            try
            {
                Quantity = Convert.ToInt32(txtProductQuantity.Text);
                if (Quantity <= 0 || (_product.Quantity - Quantity < 0))
                {
                    MessageBox.Show(
                        "Số lượng không hợp lệ",
                        "Nhập kho",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Số lượng không hợp lệ",
                    "Xuất kho",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show(
                    "Bạn chắc chắn muốn xuất kho, số lượng: " + txtProductQuantity.Text,
                    "Xuất kho",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                ) == MessageBoxResult.Yes)
            {
                Models.Inventory inventory = new Models.Inventory();
                inventory.ProductId = _product.Id;
                inventory.AccountId = App.accountController.Account.Id;
                inventory.Detail = txtProductDetail.Text;
                inventory.Type = 2;
                inventory.Quantity = Quantity;

                if (App.inventoryController.Out(inventory))
                {
                    if (MessageBox.Show(
                        "Xuất kho thành công." + '\n'
                        + "Bạn có muốn in sao kê?",
                        "Xuất kho",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        App.inventoryController.Export(inventory.Id);
                    }

                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
