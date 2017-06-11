using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFSuperMarket.Models;

namespace WPFSuperMarket.Views
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : UserControl
    {
        private string ProductPicturePath { get; set; }

        public Product()
        {
            InitializeComponent();

            LoadProductTable();

            dateExpiredTime.MaskType = DevExpress.Xpf.Editors.MaskType.DateTime;
            dateExpiredTime.MaskCulture = new CultureInfo("en-US");
            dateExpiredTime.MaskUseAsDisplayFormat = true;
            dateExpiredTime.DisplayFormatString = "dd/MM/yyyy";
            CheckPerMission();
        }
        private void CheckPerMission()
        {
            try
            {
                Models.Account account = App.accountController.Account;
                if (account.Admin.HasValue && (account.Admin.Value != 4 && account.Admin.Value !=1))
                {
                    lpProduct.IsEnabled = false;
                }
             

            }
            catch { }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PresentationSource presentationSource = PresentationSource.FromVisual((Visual)sender);
            presentationSource.ContentRendered += PresentationSource_ContentRendered;
            ((TableView)gridControl1.View).BestFitColumns();
        }

        private void PresentationSource_ContentRendered(object sender, EventArgs e)
        {
            ((TableView)gridControl1.View).BestFitColumns();
        }

        /// <summary>
        /// Tải lại bảng Mặt hàng. Đồng thời xóa chi tiết Mặt hàng. 
        /// </summary>
        public void LoadProductTable()
        {
            gridControl1.ItemsSource = App.productController.ListProductsTableModel;
            gridControl1.RefreshData();
            gridControl1.SelectedItem = null;

            ClearProductInformations();
            ((TableView)gridControl1.View).BestFitColumns();

            txtSearch.Text = "";
        }

        /// <summary>
        /// Xóa chi tiết Mặt hàng
        /// </summary>
        private void ClearProductInformations()
        {
            btnAddProduct.Content = "Tạo mới";
            btnAddProduct.Visibility = Visibility.Visible;
            btnAddProduct.IsEnabled = true;

            btnAddProduct_Cancel.Visibility = Visibility.Hidden;
            btnAddProduct_Cancel.IsEnabled = false;

            btnSaveChangeProduct.Visibility = Visibility.Visible;
            btnSaveChangeProduct.IsEnabled = false;

            btnSaveChangeProductCancel.Visibility = Visibility.Visible;
            btnSaveChangeProductCancel.IsEnabled = false;

            btnDeleteProduct.Visibility = Visibility.Visible;
            btnDeleteProduct.IsEnabled = false;

            btnPause.Visibility = Visibility.Visible;
            btnPause.IsEnabled = false;

            btnSearch.Visibility = Visibility.Visible;
            btnSearch.IsEnabled = true;

            btnRefresh.Visibility = Visibility.Visible;
            btnRefresh.IsEnabled = true;

            btnUpdateInventory.Visibility = Visibility.Visible;
            btnUpdateInventory.IsEnabled = false;

            txtProductId.Clear();
            txtProductCreateTime.Clear();
            txtProductCreatedBy.Clear();

            txtProductBarCode.Clear();
            txtProductName.Clear();
            txtProductDetail.Clear();

            txtProductPrice.Clear();
            txtProductStatus.Clear();

            txtProductQuantity.Clear();
            txtProductQuantity.IsReadOnly = true;
            txtProductQuantity.IsEnabled = false;

            dateExpiredTime.Clear();
            imageProductPicture.Clear();

            cbProductType.ItemsSource = App.productTypeController.GetAllProductTypes();
            cbProductType.DisplayMemberPath = "Name";
            cbProductType.SelectedItem = null;
        }

        /// <summary>
        /// Đổ dữ liệu vào khung chi tiết khi click chuột vào bảng
        /// </summary>
        private void gridControl1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProductTableModel item = gridControl1.SelectedItem as ProductTableModel;
                Models.Product product = App.productController.GetById(item.Id);

                txtProductId.Text = product.Id.ToString();
                txtProductCreateTime.Text = product.CreateTime.ToString("dd/MM/yyyy");
                txtProductCreatedBy.Text = product.Account?.Name ?? "";

                txtProductBarCode.Text = product.BarCode;
                txtProductName.Text = product.Name;
                txtProductDetail.Text = product.Detail;

                txtProductPrice.Text = product.Price.ToString();

                /// Loại mặt hàng
                if (product.ProductType != null)
                {
                    try
                    {
                        List<Models.ProductType> cboxList = cbProductType.ItemsSource as List<Models.ProductType>;
                        cbProductType.SelectedItem = cboxList.Single(m => m.Id == product.TypeId);
                    }
                    catch (Exception)
                    {
                        cbProductType.SelectedItem = null;
                    }
                }
                else
                {
                    cbProductType.SelectedItem = null;
                }

                /// Tình trạng
                if (product.Status == 0)
                {
                    txtProductStatus.Text = "Đang bán. ";
                    if (product.Quantity.HasValue && product.Quantity.Value < 10 && product.Quantity.Value > 0)
                    {
                        txtProductStatus.Text += "Sắp hết hàng. ";
                    }
                    if (!product.Quantity.HasValue || (product.Quantity.HasValue && product.Quantity.Value <= 0))
                    {
                        txtProductStatus.Text += "Hết hàng. ";
                    }
                    if (product.ExpiredTime.HasValue && (product.ExpiredTime.Value >= DateTime.Now) && ((product.ExpiredTime.Value - DateTime.Now).Days <= 10))
                    {
                        txtProductStatus.Text += "Sắp hết hạn. ";
                    }
                    if (product.ExpiredTime.HasValue && (product.ExpiredTime.Value < DateTime.Now))
                    {
                        txtProductStatus.Text += "Hết hạn. ";
                    }
                }
                if (product.Status == 1)
                {
                    txtProductStatus.Text = "Tạm ngưng.";
                }

                /// Tồn kho
                txtProductQuantity.Text = product.Quantity?.ToString() ?? "0";

                /// Ngày hết hạn
                if (product.ExpiredTime.HasValue)
                {
                    dateExpiredTime.DateTime = product.ExpiredTime.Value;
                    dateExpiredTime.EditValue = product.ExpiredTime.Value;
                }
                else
                {
                    dateExpiredTime.Clear();
                }

                /// Ảnh đại diện
                try
                {
                    imageProductPicture.EditValue = System.IO.File.ReadAllBytes(App.BaseImageDirectory + "Product\\" + product.Picture);
                }
                catch (Exception ex)
                {
                    imageProductPicture.EditValue = System.IO.File.ReadAllBytes(App.DefaultProductImagePath);
                }

                btnAddProduct.IsEnabled = true;
                btnAddProduct_Cancel.Visibility = Visibility.Hidden;
                btnAddProduct_Cancel.IsEnabled = false;

                btnSaveChangeProduct.Visibility = Visibility.Visible;
                btnSaveChangeProduct.IsEnabled = true;

                btnSaveChangeProductCancel.Visibility = Visibility.Visible;
                btnSaveChangeProductCancel.IsEnabled = true;

                btnDeleteProduct.Visibility = Visibility.Visible;
                btnDeleteProduct.IsEnabled = true;

                btnPause.Visibility = Visibility.Visible;
                btnPause.IsEnabled = true;

                btnSearch.Visibility = Visibility.Visible;
                btnSearch.IsEnabled = true;

                btnRefresh.Visibility = Visibility.Visible;
                btnRefresh.IsEnabled = true;

                btnUpdateInventory.Visibility = Visibility.Visible;
                btnUpdateInventory.IsEnabled = true;

                /// Hiển thị lịch sử Tồn kho
                LoadInventory(product);
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadInventory(Models.Product product)
        {
            List<InventoryTableModel> inventories = InventoryTableModel.ToListTableModelByList(product.Inventories.ToList());
            gridControlInventory.ItemsSource = inventories;
            gridControlInventory.RefreshData();
            ((TableView)gridControlInventory.View).BestFitColumns();
        }

        //public void LoadInventory(int productId)
        //{
        //    Models.Product product = App.productController.GetById(productId);
        //    List<InventoryTableModel> inventories = InventoryTableModel.ToListTableModelByList(product.Inventories.ToList());
        //    gridControlInventory.ItemsSource = inventories;
        //    gridControlInventory.RefreshData();
        //    ((TableView)gridControlInventory.View).BestFitColumns();
        //}

        /// <summary>
        /// Thêm mới Mặt hàng
        /// </summary>
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (btnAddProduct.Content.Equals("Tạo mới"))
            {
                ClearProductInformations();

                btnAddProduct.Content = "Hoàn tất";

                btnAddProduct_Cancel.Visibility = Visibility.Visible;
                btnAddProduct_Cancel.IsEnabled = true;

                btnSaveChangeProduct.IsEnabled = false;
                btnSaveChangeProductCancel.IsEnabled = false;

                btnDeleteProduct.IsEnabled = false;
                btnPause.IsEnabled = false;

                btnUpdateInventory.IsEnabled = false;

                btnSearch.IsEnabled = false;
                btnRefresh.IsEnabled = false;

                txtProductQuantity.IsReadOnly = false;
                txtProductQuantity.IsEnabled = true;
                return;
            }

            string warning = "";

            if (String.IsNullOrWhiteSpace(txtProductBarCode.Text))
            {
                warning += "Vui lòng nhập Mã vạch." + '\n';
            }

            if (String.IsNullOrWhiteSpace(txtProductName.Text))
            {
                warning += "Vui lòng nhập Tên Mặt hàng." + '\n';
            }

            if (String.IsNullOrWhiteSpace(txtProductPrice.Text))
            {
                warning += "Vui lòng nhập Giá tiền." + '\n';
            }
            else
            {
                try
                {
                    Convert.ToInt64(txtProductPrice.Text);
                }
                catch (Exception)
                {
                    warning += "Giá tiền không hợp lệ" + '\n';
                }
            }

            if (!String.IsNullOrWhiteSpace(txtProductQuantity.Text))
            {
                try
                {
                    if (Convert.ToInt32(txtProductQuantity.Text) < 0)
                    {
                        warning += "Tồn kho phải lớn hơn hoặc bằng 0";
                    }
                }
                catch (Exception)
                {
                    warning += "Tồn kho không hợp lệ.";
                }
            }

            if (!warning.Equals(""))
            {
                MessageBox.Show(
                    warning,
                    "Thêm mới Mặt hàng",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            /// Sử lý khi ấn nút Hoàn tất - Tạo mới 2
            Models.Product product = new Models.Product();

            product.AccountId = App.accountController.Account.Id;

            product.BarCode = txtProductBarCode.Text;
            product.Name = txtProductName.Text;
            product.Detail = txtProductDetail.Text;

            product.Price = Convert.ToInt64(txtProductPrice.Text);

            if (cbProductType.SelectedItem != null)
            {
                product.TypeId = (cbProductType.SelectedItem as Models.ProductType).Id;
            }

            try
            {
                product.Quantity = Convert.ToInt32(txtProductQuantity.Text);
            }
            catch (Exception)
            {
            }

            if (!String.IsNullOrWhiteSpace(dateExpiredTime.Text))
            {
                product.ExpiredTime = dateExpiredTime.DateTime;
            }

            product.Picture = ProductPicturePath;

            if (App.productController.Add(product))
            {
                MessageBox.Show(
                    "Thêm mới thành công", 
                    "Thêm mới Mặt hàng", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(
                    "Thêm mới thất bại", 
                    "Thêm mới Mặt hàng", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }

            LoadProductTable();
        }

        /// <summary>
        /// Hủy thêm mới Mặt hàng
        /// </summary>
        private void btnAddProduct_Cancel_Click(object sender, RoutedEventArgs e)
        {
            LoadProductTable();
        }

        /// <summary>
        /// Lưu thay đổi Mặt hàng
        /// </summary>
        private void btnProduct_SaveChange_Click(object sender, RoutedEventArgs e)
        {
            /// Kiểm tra Id
            try
            {
                Convert.ToInt32(txtProductId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Mã số mặt hàng không hợp lệ", 
                    "Cập nhật mặt hàng", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return;
            }

            string warning = "";

            if (String.IsNullOrWhiteSpace(txtProductBarCode.Text))
            {
                warning += "Vui lòng nhập Mã vạch." + '\n';
            }

            if (String.IsNullOrWhiteSpace(txtProductName.Text))
            {
                warning += "Vui lòng nhập Tên Mặt hàng." + '\n';
            }

            if (String.IsNullOrWhiteSpace(txtProductPrice.Text))
            {
                warning += "Vui lòng nhập Giá tiền." + '\n';
            }
            else
            {
                try
                {
                    Convert.ToInt64(txtProductPrice.Text);
                }
                catch (Exception)
                {
                    warning += "Giá tiền không hợp lệ" + '\n';
                }
            }

            if (!warning.Equals(""))
            {
                MessageBox.Show(
                    warning,
                    "Cập nhật Mặt hàng",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            Models.Product product = new Models.Product();

            product.Id = Convert.ToInt32(txtProductId.Text);
            product.BarCode = txtProductBarCode.Text;
            product.Name = txtProductName.Text;
            product.Detail = txtProductDetail.Text;

            product.Price = Convert.ToInt64(txtProductPrice.Text);

            if (cbProductType.SelectedItem != null)
            {
                product.TypeId = (cbProductType.SelectedItem as Models.ProductType).Id;
            }
            else
            {
                product.TypeId = null;
            }

            if (!String.IsNullOrWhiteSpace(dateExpiredTime.Text))
            {
                product.ExpiredTime = dateExpiredTime.EditValue as DateTime?;
            }
            else
            {
                product.ExpiredTime = null;
            }

            product.Picture = ProductPicturePath;

            if (!App.productController.Update(product))
            {
                MessageBox.Show(
                    "Cập nhật thất bại",
                    "Cập nhật Mặt hàng",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(
                    "Cập nhật thành công",
                    "Cập nhật Mặt hàng",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            LoadProductTable();
        }

        /// <summary>
        /// Hủy thay đổi mặt hàng
        /// </summary>
        private void btnSaveChangeProduct_Cancel_Click(object sender, RoutedEventArgs e)
        {
            LoadProductTable();
        }

        /// <summary>
        /// Xóa mặt hàng
        /// </summary>
        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            /// Kiểm tra Id
            try
            {
                Convert.ToInt32(txtProductId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Mã số mặt hàng không hợp lệ", 
                    "Xóa Mặt hàng", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            /// Hỏi lại có chắc xóa mặt hàng không
            if (MessageBox.Show(
                "Bạn có chắc chắn muốn xóa mặt hàng: " + txtProductName.Text,
                "Xóa Mặt hàng", MessageBoxButton.YesNo, MessageBoxImage.Question
                ) == MessageBoxResult.Yes)
            {
                if (App.productController.Delete(Convert.ToInt32(txtProductId.Text)))
                {
                    MessageBox.Show(
                        "Xóa mặt hàng thành công", 
                        "Xóa Mặt hàng", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Xóa mặt hàng thất bại", 
                        "Xóa Mặt hàng", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error);
                }

                LoadProductTable();
            }
        }

        /// <summary>
        /// Lưu hình ảnh vào thư mục chương trình khi đổi ảnh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageProductPicture_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (imageProductPicture.HasImage)
            {
                try
                {
                    ProductPicturePath = txtProductId.Text + ".jpg";

                    System.IO.File.WriteAllBytes(
                        App.BaseImageDirectory + "Product\\" + ProductPicturePath,
                        (byte[])imageProductPicture.EditValue);

                    return;
                }
                catch (Exception ex)
                {
                }
            }

            ProductPicturePath = "";
        }

        /// <summary>
        /// Cập nhật tồn kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateInventory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(txtProductId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Mã số mặt hàng không hợp lệ",
                    "Cập nhật Tồn kho", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Models.Product product = App.productController.GetById(Convert.ToInt32(txtProductId.Text));
            InventoryActions inventoryActions = new InventoryActions(product);
            inventoryActions.ShowDialog();
            LoadProductTable();
        }

        /// <summary>
        ///  Làm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadProductTable();
        }

        /// <summary>
        /// Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập từ khóa",
                    "Tìm kiếm Mặt hàng",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }

            ClearProductInformations();

            gridControl1.ItemsSource = App.productController.GetListTableModelBySearch(txtSearch.Text);
            gridControl1.RefreshData();
            gridControl1.SelectedItem = null;
        }

        /// <summary>
        /// Tạm ngưng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(txtProductId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Mã số Mặt hàng không hợp lệ",
                    "Tạm ngưng Mặt hàng",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }

            if (MessageBox.Show(
                "Bạn có chắc chắn muốn tạm ngưng Mặt hàng",
                "Tạm ngưng Mặt hàng",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (App.productController.Pause(Convert.ToInt32(txtProductId.Text)))
                {
                    MessageBox.Show(
                        "Tạm ngưng thành công",
                        "Tạm ngưng Mặt hàng",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Tạm ngưng thất bại",
                        "Tạm ngưng Mặt hàng",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                LoadProductTable();
            }
        }

        private void printInventoryContextMenu_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                InventoryTableModel model = gridControlInventory.SelectedItem as InventoryTableModel;

                if (MessageBox.Show(
                    "Bạn có muốn in thông tin?",
                   "Thông tin Tồn kho",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        App.inventoryController.Export(model.Id);
                    }
            }
            catch (Exception)
            {

            }

        }

        private void gridControl1_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            gridControl1_MouseDown(null, null);
        }
    }
}
