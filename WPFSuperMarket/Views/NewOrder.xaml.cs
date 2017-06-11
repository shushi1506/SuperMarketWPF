using DevExpress.Spreadsheet;
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
using WPFSuperMarket.Providers;
using System.Globalization;

namespace WPFSuperMarket.Views
{
    /// <summary>
    /// Interaction logic for NewOrder.xaml
    /// </summary>
    public partial class NewOrder : UserControl
    {
        private long Total { get; set; }
        private long VAT { get; set; }
        private long Discount { get; set; }
        private long Paid { get; set; }

        public NewOrder()
        {
            InitializeComponent();

            LoadProductTable();
            LoadOrdersToday();
            CheckPerMission();
        }
        private void CheckPerMission()
        {
            try
            {
                Models.Account account = App.accountController.Account;
                if (account.Admin.HasValue && (account.Admin.Value != 3  && account.Admin.Value!=1))
                {
                    lpInfoProduct.IsEnabled = false;
                    lpNewOrder.IsEnabled = false;
                }
               

            }
            catch { }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PresentationSource presentationSource = PresentationSource.FromVisual((Visual)sender);
            presentationSource.ContentRendered += PresentationSource_ContentRendered;

            ((TableView)gridControlProducts.View).BestFitColumns();
            ((TableView)gridControlOrdersToday.View).BestFitColumns();
            ((TableView)gridControlOrderLinesToday.View).BestFitColumns();
        }

        private void PresentationSource_ContentRendered(object sender, EventArgs e)
        {
            ((TableView)gridControlProducts.View).BestFitColumns();
            ((TableView)gridControlOrdersToday.View).BestFitColumns();
            ((TableView)gridControlOrderLinesToday.View).BestFitColumns();
        }

        /// <summary>
        /// Tải lại Bảng Mặt hàng. Đồng thời xóa chi tiết mặt hàng
        /// </summary>
        public void LoadProductTable()
        {
            gridControlProducts.ItemsSource = App.productController.ListProductsTableModel;
            gridControlProducts.RefreshData();
            gridControlProducts.SelectedItem = null;
            ((TableView)gridControlProducts.View).BestFitColumns();

            ClearProductInformations();

            txtSearch.Clear();
        }

        public void LoadOrdersToday()
        {
            gridControlOrdersToday.ItemsSource
                = App.orderController.GetListTodayByAccountId(App.accountController.Account.Id);
            gridControlOrdersToday.RefreshData();
            ((TableView)gridControlOrdersToday.View).BestFitColumns();
            ((TableView)gridControlOrderLinesToday.View).BestFitColumns();
        }

        /// <summary>
        /// Xóa chi tiết Mặt hàng
        /// </summary>
        private void ClearProductInformations()
        {
            btnAddProduct.Visibility = Visibility.Hidden;
            btnRemoveProduct.Visibility = Visibility.Hidden;
            btnSaveChangeOrderLineProduct.Visibility = Visibility.Hidden;

            txtProductId.Clear();
            txtProductBarCode.Clear();
            txtProductName.Clear();
            txtProductPrice.Clear();
            txtProductQuantity.Clear();
            txtProductTotalPrice.Clear();
            imageProductPicture.Clear();
        }

        /// <summary>
        /// Đổ dữ liệu vào khung Thông tin Mặt hàng khi click chuột vào bảng Dòng Hóa đơn
        /// </summary>
        private void gridControlOrderLines_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OrderLineTableModel item = gridControlOrderLines.SelectedItem as OrderLineTableModel;
                Models.Product product = App.productController.GetById(item.ProductId);

                txtProductId.Text = product.Id.ToString();
                txtProductBarCode.Text = product.BarCode;
                txtProductName.Text = product.Name;
                txtProductPrice.Text = product.Price.ToString();
                txtProductQuantity.Text = item.Quantity.ToString();
                txtProductTotalPrice.Text = item.TotalPrice;

                try
                {
                    imageProductPicture.EditValue = System.IO.File.ReadAllBytes(App.BaseImageDirectory + "Product\\" + product.Picture);
                }
                catch (Exception ex)
                {
                    imageProductPicture.EditValue = System.IO.File.ReadAllBytes(App.DefaultProductImagePath);
                }

                btnAddProduct.Visibility = Visibility.Hidden;
                btnRemoveProduct.Visibility = Visibility.Visible;
                btnSaveChangeOrderLineProduct.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Đổ dữ liệu vào khung Thông tin Mặt hàng khi click chuột vào bảng Mặt hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControlProducts_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProductTableModel item = gridControlProducts.SelectedItem as ProductTableModel;
                Models.Product product = App.productController.GetById(item.Id);

                txtProductId.Text = product.Id.ToString();
                txtProductBarCode.Text = product.BarCode;
                txtProductName.Text = product.Name;
                txtProductPrice.Text = product.Price.ToString();
                txtProductQuantity.Text = "0";
                txtProductTotalPrice.Text = "0 VNĐ";

                try
                {
                    imageProductPicture.EditValue = System.IO.File.ReadAllBytes(App.BaseImageDirectory + "Product\\" + product.Picture);
                }
                catch (Exception ex)
                {
                    imageProductPicture.EditValue = System.IO.File.ReadAllBytes(App.DefaultProductImagePath);
                }

                btnAddProduct.Visibility = Visibility.Visible;
                btnRemoveProduct.Visibility = Visibility.Hidden;
                btnSaveChangeOrderLineProduct.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Cập nhật thông tin Chi tiết Hóa đơn
        /// </summary>
        public void ReLoadOrderDetail()
        {
            List<OrderLineTableModel> orderLines = gridControlOrderLines.ItemsSource as List<OrderLineTableModel>;
            
            if (orderLines?.Count > 0)
            {
                Total = 0;
                foreach (var item in orderLines)
                {
                    Total += item.ToOrderLine().TotalPrice;
                }
                txtOrderTotalPrice.Text =  Helpers.MoneyHelper.PriceToVND(Total);

                Discount = 0;
                if (!String.IsNullOrWhiteSpace(txtOrderDiscountPrice.Text))
                {
                    try
                    {
                        Discount = Convert.ToInt64(txtOrderDiscountPrice.Text);

                        if (Discount < 0)
                        {
                            txtOrderDiscountPrice.Text = "0";
                            Discount = 0;
                        }
                    }
                    catch (Exception)
                    {
                        txtOrderDiscountPrice.Text = "0";
                        Discount = 0;
                    }
                }
                VAT = (long)(Total / 10);
                txtOrderVATPrice.Text = Helpers.MoneyHelper.PriceToVND(VAT);

                Paid = (long)(Total - Discount+VAT);
                txtOrderPaidPrice.Text = Helpers.MoneyHelper.PriceToVND(Paid);

                
            }
            else
            {
                txtOrderTotalPrice.Text = "0 VNĐ";
                txtOrderVATPrice.Text = "0 VNĐ";
                txtOrderPaidPrice.Text = "0 VNĐ";
            }
        }

        /// <summary>
        /// Làm lại Hóa đơn
        /// </summary>
        public void ClearOrder()
        {
            gridControlOrderLines.ItemsSource = new List<OrderLineTableModel>();
            gridControlOrderLines.RefreshData();

            txtOrderGuestName.Text = "Khách lẻ";
            txtOrderGuestPhone.Clear();
            txtOrderGuestEmail.Clear();
            txtOrderGuestAddress.Clear();

            txtOrderDetail.Clear();
            txtOrderTotalPrice.Clear();
            txtOrderPaidPrice.Clear();
            txtOrderVATPrice.Clear();
            txtOrderDiscountPrice.Clear();

            LoadProductTable();
        }

        /// <summary>
        /// Thêm Sản phẩm vào Hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtProductQuantity.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập Số lượng",
                    "Thêm Sản phẩm vào Hóa đơn",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                txtProductQuantity.Focus();
                return;
            }

            try
            {
                if (Convert.ToInt32(txtProductQuantity.Text) <= 0)
                {
                    MessageBox.Show(
                        "Vui lòng nhập Số lượng là một số lớn hơn 0",
                        "Thêm Sản phẩm vào Hóa đơn",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    txtProductQuantity.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Vui lòng nhập Số lượng là một số lớn hơn 0",
                    "Thêm Sản phẩm vào Hóa đơn",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                txtProductQuantity.Focus();
                return;
            }

            try
            {
                List<OrderLineTableModel> orderLines = gridControlOrderLines.ItemsSource as List<OrderLineTableModel>;
                if (orderLines == null) orderLines = new List<OrderLineTableModel>();

                Models.Product product = App.productController.GetById(Convert.ToInt32(txtProductId.Text));

                int quantity = Convert.ToInt32(txtProductQuantity.Text);

                OrderLineTableModel orderLine = null;

                try
                {
                    orderLine = orderLines.Single(m => m.ProductId == product.Id);
                }
                catch (Exception)
                {
                    orderLine = null;
                }

                if (product.Status == 1)
                {
                    MessageBox.Show(
                        "Mặt hàng hiện tạm ngưng, không bán.",
                        "Thêm Mặt hàng vào Hóa đơn",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                if (!product.Quantity.HasValue
                    || (orderLine == null && quantity > product.Quantity.Value)
                    || (orderLine != null && (quantity + orderLine.Quantity) > product.Quantity.Value))
                {
                    MessageBox.Show(
                        "Số lượng vượt quá tồn kho",
                        "Thêm Mặt hàng vào Hóa đơn",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    txtProductQuantity.Focus();
                    return;
                }

                if (orderLine == null)
                {
                    orderLines.Add(
                        new OrderLineTableModel(
                            orderLines.Count + 1,
                            product,
                            quantity
                        )
                    );
                }
                else
                {
                    orderLine.Quantity += quantity;
                    orderLine.TotalPrice = Helpers.MoneyHelper.PriceToVND((long)(product.Price * orderLine.Quantity +(product.Price * orderLine.Quantity)/10));
                }

                gridControlOrderLines.ItemsSource = orderLines;
                gridControlOrderLines.RefreshData();
                ((TableView)gridControlOrderLines.View).BestFitColumns();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Thêm Sản phẩm vào Hóa đơn thất bại",
                    "Thêm Sản phẩm vào Hóa đơn",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }

            ReLoadOrderDetail();
        }

        /// <summary>
        /// Tải lại danh sách Mặt hàng
        /// </summary>
        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            LoadProductTable();
        }

        /// <summary>
        /// Cập nhật thành tiền của Mặt hàng khi thay đổi số lượng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProductQuantity_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            try
            {
                Models.Product product = App.productController.GetById(Convert.ToInt32(txtProductId.Text));
                txtProductTotalPrice.Text = Helpers.MoneyHelper.PriceToVND((long)(product.Price * Convert.ToInt32(txtProductQuantity.Text)));
            }
            catch (Exception)
            {

                txtProductTotalPrice.Text = "0 VNĐ";
            }
        }

        /// <summary>
        /// Cập nhật dòng hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveChangeOrderLineProduct_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtProductQuantity.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập Số lượng",
                    "Cập nhật Hóa đơn",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                txtProductQuantity.Focus();
                return;
            }

            try
            {
                if (Convert.ToInt32(txtProductQuantity.Text) <= 0)
                {
                    MessageBox.Show(
                        "Vui lòng nhập Số lượng là một số lớn hơn 0",
                        "Cập nhật Hóa đơn",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    txtProductQuantity.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Vui lòng nhập Số lượng là một số lớn hơn 0",
                    "Cập nhật Hóa đơn",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                txtProductQuantity.Focus();
                return;
            }

            try
            {
                List<OrderLineTableModel> orderLines = gridControlOrderLines.ItemsSource as List<OrderLineTableModel>;

                if (orderLines == null) orderLines = new List<OrderLineTableModel>();

                Models.Product product = App.productController.GetById(Convert.ToInt32(txtProductId.Text));

                int quantity = Convert.ToInt32(txtProductQuantity.Text);

                OrderLineTableModel orderLine = null;

                try
                {
                    orderLine = orderLines.Single(m => m.ProductId == product.Id);
                }
                catch (Exception)
                {
                    orderLine = null;
                }


                if (product.Status == 1)
                {
                    MessageBox.Show(
                        "Mặt hàng hiện tạm ngưng, không bán.",
                        "Thêm Mặt hàng vào Hóa đơn",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                if (!product.Quantity.HasValue 
                    || (orderLine == null && quantity > product.Quantity.Value)
                    || (orderLine != null && quantity > product.Quantity.Value)
                   )
                {
                    MessageBox.Show(
                        "Số lượng vượt quá tồn kho",
                        "Cập nhật dòng Hóa đơn",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning); txtProductQuantity.Focus();
                    return;
                }

                if (orderLine == null)
                {
                    orderLines.Add(
                        new OrderLineTableModel(
                            orderLines.Count + 1,
                            product,
                            quantity
                        )
                    );
                }
                else
                {
                    orderLine.Quantity = quantity;
                    orderLine.TotalPrice = Helpers.MoneyHelper.PriceToVND((long)(product.Price * orderLine.Quantity + ((product.Price * orderLine.Quantity) / 10)));
                }

                gridControlOrderLines.ItemsSource = orderLines;
                gridControlOrderLines.RefreshData();
                ((TableView)gridControlOrderLines.View).BestFitColumns();

                ReLoadOrderDetail();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Cập nhật Hóa đơn thất bại",
                    "Cập nhật Hóa đơn",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
        
        /// <summary>
        /// Xóa Mặt hàng khỏi Hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(txtProductId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Mã số sản phẩm không hợp lệ",
                    "Cập nhật Hóa đơn",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            List<OrderLineTableModel> orderLines = gridControlOrderLines.ItemsSource as List<OrderLineTableModel>;
            if (orderLines == null)
            {
                MessageBox.Show(
                    "Hóa đơn rỗng",
                    "Cập nhật Hóa đơn",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            Models.Product product = App.productController.GetById(Convert.ToInt32(txtProductId.Text));

            OrderLineTableModel orderLine = null;

            try
            {
                orderLine = orderLines.Single(m => m.ProductId == product.Id);
            }
            catch (Exception)
            {
                orderLines = null;
            }

            if (orderLine != null)
            {
                orderLines.Remove(orderLine);
                gridControlOrderLines.ItemsSource = orderLines;
                gridControlOrderLines.RefreshData();

                ClearProductInformations();
            }

            ReLoadOrderDetail();
        }

        /// <summary>
        /// Làm lại Hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearOrder_Click(object sender, RoutedEventArgs e)
        {
            ClearOrder();
        }

        /// <summary>
        /// Lập Hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btNewOrder_Click(object sender, RoutedEventArgs e)
        {
            string warning = "";

            if (String.IsNullOrWhiteSpace(txtOrderGuestName.Text))
            {
                warning += "Vui lòng nhập Tên Khách." + '\n';
            }

            if (Total < 0)
            {
                warning += "Tổng tiền không hợp lệ";
            }
            if (VAT < 0)
            {
                warning += "Thuế VAT không hợp lệ";
            }
            if (Discount < 0)
            {
                warning += "Khuyến mãi không hợp lệ";
            }
            if (Paid < 0)
            {
                warning += "Thanh toán không hợp lệ";
            }


            List<OrderLineTableModel> orderLines = gridControlOrderLines.ItemsSource as List<OrderLineTableModel>;
            if (orderLines == null || orderLines?.Count <= 0)
            {
                warning += "Hóa đơn rỗng." + '\n';
            }

            if (!warning.Equals(""))
            {
                MessageBox.Show(
                    warning,
                    "LẬP HÓA ĐƠN",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
                return;
            }

            if (MessageBox.Show(
                    "Tên Khách: " + txtOrderGuestName.Text + '\n'
                    + "Tổng tiền: " + Helpers.MoneyHelper.PriceToVND(Total) + '\n'
                    + "Thuế VAT: " + Helpers.MoneyHelper.PriceToVND(VAT) + '\n'
                    + "Khuyến mại: " + Helpers.MoneyHelper.PriceToVND(Discount) + '\n'
                    + "Thanh toán: " + Helpers.MoneyHelper.PriceToVND(Paid) + '\n' 
                    + "Bạn có chắc chắn muốn Lập hóa đơn?",
                    "Lập Hóa đơn",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }

            Models.Order order = new Models.Order();

            order.AccountId = App.accountController.Account.Id;
            order.GuessName = txtOrderGuestName.Text;
            order.GuessPhone = txtOrderGuestPhone.Text;
            order.GuessEmail = txtOrderGuestEmail.Text;
            order.GuessAddress = txtOrderGuestAddress.Text;

            order.TotalPrice = Total;
            order.VATPrice = VAT;
            order.Discount = Discount;
            order.PaidPrice = Paid;

            order.OrderLines = new List<OrderLine>();
            foreach (var item in orderLines)
            {
                OrderLine orderLine = item.ToOrderLine();
                orderLine.AccountId = App.accountController.Account.Id;
                order.OrderLines.Add(orderLine);
            }

            if (App.orderController.Add(order, orderLines))
            {
                MessageBox.Show(
                    "Lập Hóa đơn thành công",
                    "LẬP HÓA ĐƠN",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

                if (MessageBox.Show(
                    "Bạn có muốn in hóa đơn?",
                    "LẬP HÓA ĐƠN",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    App.orderController.ExportInvoice(order);
                }

                ClearOrder();
                LoadOrdersToday();
            }
            else
            {
                MessageBox.Show(
                    "Lập Hóa đơn thất bại",
                    "LẬP HÓA ĐƠN",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        /// <summary>
        /// Xử lý khi thay đổi giá trị Khuyến mại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrderDiscountPrice_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            ReLoadOrderDetail();
        }

        /// <summary>
        /// Tìm kiếm sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadProductTable();
            }
            else
            {
                List<ProductTableModel> products = App.productController.GetListTableModelBySearch(txtSearch.Text);
                gridControlProducts.ItemsSource = products;
                gridControlProducts.RefreshData();
            }
        }

        private void gridControlOrderLinesToday_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            gridControlOrderLines_MouseDown(null, null);
        }

        private void gridControlOrdersToday_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OrderTableModel model = gridControlOrdersToday.SelectedItem as OrderTableModel;
                Models.Order order = App.orderController.getById(model.Id);

                List<OrderLineTableModel> orderLines = OrderLineTableModel.ToListByListOrderLine(order.OrderLines.ToList());
                gridControlOrderLinesToday.ItemsSource = orderLines;
                ((TableView)gridControlOrderLinesToday.View).BestFitColumns();
            }
            catch (Exception ex)
            {

            }
        }

        private void printOrderContextMenu_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (MessageBox.Show(
                "Bạn có muốn in hóa đơn?",
                "IN HÓA ĐƠN",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    OrderTableModel model = gridControlOrdersToday.SelectedItem as OrderTableModel;
                    Models.Order order = App.orderController.getById(model.Id);
                    App.orderController.ExportInvoice(order);
                }
                catch (Exception)
                {

                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Return))
                btnSearch_Click(null, null);
        }

        private void gridControlOrdersToday_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            gridControlOrdersToday_MouseDown(null, null);
        }

        private void gridControlOrderLines_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            gridControlOrderLines_MouseDown(null, null);
        }

        private void gridControlProducts_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            gridControlProducts_MouseDown(null, null);
        }
        public string ConvertToImage(string nameImage)
        {
            try
            {
                string k = App.BaseImageDirectory+"Product\\"+nameImage;
                return k;
            }
            catch { string k = App.DefaultProductImagePath;return k; }
        }
        
    }
    public class imageConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string k = value as string;
            if (k == null) return App.DefaultProductImagePath;
            return App.BaseImageDirectory + "Product\\" + k;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
