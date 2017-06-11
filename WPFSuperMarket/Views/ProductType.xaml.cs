using DevExpress.Xpf.Grid;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFSuperMarket.Models;

namespace WPFSuperMarket.Views
{
    /// <summary>
    /// Interaction logic for ProductType.xaml
    /// </summary>
    public partial class ProductType : UserControl
    {
        public ProductType()
        {
            InitializeComponent();

            LoadProductTypeTable();

            btnAddProductType_Cancel.Visibility = Visibility.Hidden;
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
        /// Tải lại bảng Loại Mặt hàng. Đồng thời xóa chi tiết loại mặt hàng
        /// </summary>
        private void LoadProductTypeTable()
        {
            gridControl1.ItemsSource = App.productTypeController.ListProductTypesTableModel;
            gridControl1.RefreshData();
            gridControl1.SelectedItem = null;
            ((TableView)gridControl1.View).BestFitColumns();

            ClearInformations();

            txtSearch.Clear();
        }
        
        /// <summary>
        /// Xóa chi tiết loại mặt hàng
        /// </summary>
        public void ClearInformations()
        {
            btnAddProductType.Content = "Tạo mới";
            btnAddProductType.Visibility = Visibility.Visible;
            btnAddProductType.IsEnabled = true;

            btnAddProductType_Cancel.Visibility = Visibility.Hidden;
            btnAddProductType_Cancel.IsEnabled = false;

            btnSaveChangeProductType.Visibility = Visibility.Visible;
            btnSaveChangeProductType.IsEnabled = false;

            btnSaveChangeProductTypeCancel.Visibility = Visibility.Visible;
            btnSaveChangeProductTypeCancel.IsEnabled = false;

            btnDeleteProductType.Visibility = Visibility.Visible;
            btnDeleteProductType.IsEnabled = false;

            btnSearch.Visibility = Visibility.Visible;
            btnSearch.IsEnabled = true;

            btnRefresh.Visibility = Visibility.Visible;
            btnRefresh.IsEnabled = true;

            txtProductTypeId.Clear();
            txtProductTypeCreateTime.Clear();
            txtProductTypeCreatedBy.Clear();

            txtProductTypeName.Clear();
            txtProductTypeDetail.Clear();

            cbProductTypeParentName.ItemsSource = App.productTypeController.GetAllProductTypes();
            cbProductTypeParentName.DisplayMemberPath = "Name";
            cbProductTypeParentName.SelectedItem = null;
        }
    
        /// <summary>
        /// Đổ dữ liệu vào khung chi tiết khi click chuột vào bảng
        /// </summary>
        private void gridControl1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProductTypeTableModel item = (ProductTypeTableModel)gridControl1.SelectedItem;
                Models.ProductType productType = App.productTypeController.GetProductTypeById(item.Id);

                txtProductTypeId.Text = productType.Id + "";
                txtProductTypeCreateTime.Text = productType.CreateTime.ToString("dd/MM/yyyy");
                txtProductTypeCreatedBy.Text = productType.Account?.Name ?? "";

                txtProductTypeName.Text = productType.Name;
                txtProductTypeDetail.Text = productType.Detail;

                if (productType.ParentProductType != null)
                {
                    try
                    {
                        List<Models.ProductType> cboxList = cbProductTypeParentName.ItemsSource as List<Models.ProductType>;
                        cbProductTypeParentName.SelectedItem = cboxList.Single(m => m.Id == productType.ParentId);
                    }
                    catch (Exception)
                    {
                        cbProductTypeParentName.SelectedItem = null;
                    }
                }
                else
                {
                    cbProductTypeParentName.SelectedItem = null;
                }

                btnAddProductType.IsEnabled = true;
                btnAddProductType_Cancel.Visibility = Visibility.Hidden;
                btnAddProductType_Cancel.IsEnabled = false;

                btnSaveChangeProductType.Visibility = Visibility.Visible;
                btnSaveChangeProductType.IsEnabled = true;

                btnSaveChangeProductTypeCancel.Visibility = Visibility.Visible;
                btnSaveChangeProductTypeCancel.IsEnabled = true;

                btnDeleteProductType.Visibility = Visibility.Visible;
                btnDeleteProductType.IsEnabled = true;

                btnSearch.Visibility = Visibility.Visible;
                btnSearch.IsEnabled = true;

                btnRefresh.Visibility = Visibility.Visible;
                btnRefresh.IsEnabled = true;
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Thêm mới Loại Mặt hàng
        /// </summary>
        private void btnAddProductType_Click(object sender, RoutedEventArgs e)
        {
            /// Sử lý khi lần đầu ấn nút Tạo mới
            if (btnAddProductType.Content.Equals("Tạo mới"))
            {
                ClearInformations();

                btnAddProductType.Content = "Hoàn tất";

                btnAddProductType_Cancel.Visibility = Visibility.Visible;
                btnAddProductType_Cancel.IsEnabled = true;

                btnSaveChangeProductType.IsEnabled = false;
                btnSaveChangeProductTypeCancel.IsEnabled = false;

                btnDeleteProductType.IsEnabled = false;

                txtSearch.IsEnabled = false;
                btnRefresh.IsEnabled = false;

                return;
            }

            if (String.IsNullOrWhiteSpace(txtProductTypeName.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập Tên Loại Mặt hàng", 
                    "Thêm mới Loại Mặt hàng", 
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            /// Sử lý khi ấn nút Hoàn tất - Tạo mới 2
            Models.ProductType productType = new Models.ProductType();

            productType.AccountId = App.accountController.Account.Id;

            productType.Name = txtProductTypeName.Text;

            if (cbProductTypeParentName.SelectedItem != null)
            {
                productType.ParentId = (cbProductTypeParentName.SelectedItem as Models.ProductType).Id;
            }

            productType.Detail = txtProductTypeDetail.Text;

            if (App.productTypeController.Add(productType))
            {
                MessageBox.Show("Thêm mới thành công", "Thêm mới Loại Mặt hàng", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại", "Thêm mới Loại Mặt hàng", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            LoadProductTypeTable();
        }

        /// <summary>
        /// Hủy thêm mới loại Mặt hàng
        /// </summary>
        private void btnAddProductType_Cancel_Click(object sender, RoutedEventArgs e)
        {
            LoadProductTypeTable();
        }


        /// <summary>
        /// Lưu thay đổi loại Mặt hàng
        /// </summary>
        private void btnProductType_SaveChange_Click(object sender, RoutedEventArgs e)
        {
            /// Kiểm tra Id
            try
            {
                Convert.ToInt32(txtProductTypeId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Mã số loại mặt hàng không hợp lệ", "Cập nhật loại mặt hàng", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (String.IsNullOrWhiteSpace(txtProductTypeName.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập Tên Loại Mặt hàng",
                    "Cập nhật Loại Mặt hàng",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            Models.ProductType productType = new Models.ProductType();

            productType.Id = Convert.ToInt32(txtProductTypeId.Text);

            productType.Name = txtProductTypeName.Text;

            if (cbProductTypeParentName.SelectedItem != null)
            {
                productType.ParentId = (cbProductTypeParentName.SelectedItem as Models.ProductType).Id;
            }
            else
            {
                productType.ParentId = null;
            }

            productType.Detail = txtProductTypeDetail.Text;

            if (!App.productTypeController.Update(productType))
            {
                MessageBox.Show(
                    "Cập nhật thất bại",
                    "Cập nhật Loại Mặt hàng",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(
                    "Cập nhật thành công",
                    "Cập nhật Loại Mặt hàng",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            LoadProductTypeTable();
        }

        /// <summary>
        /// Hủy thay đổi loại mặt hàng
        /// </summary>
        private void btnSaveChangeProductType_Cancel_Click(object sender, RoutedEventArgs e)
        {
            LoadProductTypeTable();
        }

        /// <summary>
        /// Xóa loại mặt hàng
        /// </summary>
        private void btnDeleteProductType_Click(object sender, RoutedEventArgs e)
        {
            /// Kiểm tra Id
            try
            {
                Convert.ToInt32(txtProductTypeId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Mã số loại mặt hàng không hợp lệ", 
                    "Xóa Loại Mặt hàng", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return;
            }

            /// Hỏi lại có chắc xóa loại mặt hàng không
            if (MessageBox.Show(
                "Bạn có chắc chắn muốn xóa loại mặt hàng: " + txtProductTypeName.Text,
                "Xóa Loại Mặt hàng", MessageBoxButton.YesNo, MessageBoxImage.Question
                ) == MessageBoxResult.Yes)
            {
                if (App.productTypeController.Delete(Convert.ToInt32(txtProductTypeId.Text)))
                {
                    MessageBox.Show("Xóa loại mặt hàng thành công", "Xóa Loại Mặt hàng", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Xóa loại mặt hàng thất bại", "Xóa Loại Mặt hàng", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                LoadProductTypeTable();
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadProductTypeTable();
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
                    "Tìm kiếm Loại Mặt hàng",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }

            ClearInformations();

            gridControl1.ItemsSource = App.productTypeController.GetListTableModelBySearch(txtSearch.Text);
            gridControl1.RefreshData();
            gridControl1.SelectedItem = null;
        }

        private void gridControl1_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            gridControl1_MouseDown(null, null);
        }
    }
}
