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

namespace WPFSuperMarket.Views
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : UserControl
    {
        public Order()
        {
            InitializeComponent();

            LoadOrderTable();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PresentationSource presentationSource = PresentationSource.FromVisual((Visual)sender);
            presentationSource.ContentRendered += PresentationSource_ContentRendered;
            ((TableView)gridControlOrders.View).BestFitColumns();
        }

        private void PresentationSource_ContentRendered(object sender, EventArgs e)
        {
            ((TableView)gridControlOrders.View).BestFitColumns();
        }

        public void LoadOrderTable()
        {
            gridControlOrders.ItemsSource = App.orderController.ListOrdersTableModel;
            gridControlOrders.RefreshData();
            ((TableView)gridControlOrders.View).BestFitColumns();

            ClearOrderInformations();
        }

        public void ClearOrderInformations()
        {
            txtOrderId.Clear();
            txtOrderCreateTime.Clear();
            txtOrderCreatedBy.Clear();

            btnPrint.Visibility = Visibility.Hidden;
            txtOrderGuestName.Clear();
            txtOrderGuestPhone.Clear();
            txtOrderGuestEmail.Clear();
            txtOrderGuestAddress.Clear();

            txtOrderTotalPrice.Clear();
            txtOrderVATPrice.Clear();
            txtOrderDiscountPrice.Clear();
            txtOrderPaidPrice.Clear();
            txtOrderDetail.Clear();
        }

        /// <summary>
        /// Đổ dữ liệu vào Thông tin Mặt hàng khi click vào bảng Hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControlOrders_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OrderTableModel model = gridControlOrders.SelectedItem as OrderTableModel;
                Models.Order order = App.orderController.getById(model.Id);

                List<OrderLineTableModel> orderLines = OrderLineTableModel.ToListByListOrderLine(order.OrderLines.ToList());
                gridControlOrderLines.ItemsSource = orderLines;

                txtOrderId.Text = order.Id.ToString();
                txtOrderCreateTime.Text = order.CreateTime.ToString("dd/MM/yyyy HH:mm:ss");
                txtOrderCreatedBy.Text = order.Account?.Name ?? "";

                txtOrderDetail.Text = order.Detail;
                txtOrderGuestName.Text = order.GuessName;
                txtOrderGuestEmail.Text = order.GuessEmail;
                txtOrderGuestPhone.Text = order.GuessPhone;
                txtOrderGuestAddress.Text = order.GuessAddress;

                txtOrderTotalPrice.Text = Helpers.MoneyHelper.PriceToVND(order.TotalPrice);
                txtOrderPaidPrice.Text = Helpers.MoneyHelper.PriceToVND(order.PaidPrice);
                txtOrderVATPrice.Text = Helpers.MoneyHelper.PriceToVND(order.VATPrice);
                txtOrderDiscountPrice.Text = Helpers.MoneyHelper.PriceToVND(order.Discount);

                btnPrint.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {

            }
        }

        private void gridControlOrderLines_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            gridControlOrders_MouseDown(null, null);
        }

        /// <summary>
        /// In Hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(txtOrderId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Mã số Hóa đơn không hợp lệ.",
                    "IN HÓA ĐƠN",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            Models.Order order = App.orderController.getById(Convert.ToInt32(txtOrderId.Text));
            App.orderController.ExportInvoice(order);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadOrderTable();
        }

        private void btnToday_Click(object sender, RoutedEventArgs e)
        {
            dateFromTime.EditValue = DateTime.Now;
            dateToTime.EditValue = DateTime.Now;

            gridControlOrders.ItemsSource = App.orderController.GetListByCreateTime(DateTime.Now, DateTime.Now);
            gridControlOrders.RefreshData();
            ((TableView)gridControlOrders.View).BestFitColumns();

            ClearOrderInformations();
        }

        private void btnThisMonth_Click(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime from = new DateTime(now.Year, now.Month, 1);
            DateTime to = from.AddMonths(1).AddDays(-1);
            dateFromTime.EditValue = from;
            dateToTime.EditValue = to;

            gridControlOrders.ItemsSource = App.orderController.GetListByCreateTime(from, to);
            gridControlOrders.RefreshData();
            ((TableView)gridControlOrders.View).BestFitColumns();

            ClearOrderInformations();
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Models.Order> list = new OrderProvider().getAll();

                dateFromTime.EditValue = list.Last().CreateTime;
                dateToTime.EditValue = list.First().CreateTime;
            }
            catch (Exception)
            {

            }

            LoadOrderTable();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gridControlOrders.ItemsSource 
                    = App.orderController.GetListByCreateTime(
                            (dateFromTime.EditValue as DateTime?).Value,
                            (dateToTime.EditValue as DateTime?).Value
                        );
                gridControlOrders.RefreshData();
                ((TableView)gridControlOrders.View).BestFitColumns();

                ClearOrderInformations();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Vui lòng chọn khoảng thời gian cần Sao kê",
                    "Sao kê Hóa đơn",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }

        }

        private void btnPrintList_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(
                    "Bạn chắc chắn muốn In Báo cáo",
                    "IN BÁO CÁO",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.orderController.ExportStatistic(
                        gridControlOrders.ItemsSource as List<OrderTableModel>,
                        (dateFromTime.EditValue as DateTime?).Value,
                        (dateToTime.EditValue as DateTime?).Value
                    );
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Vui lòng kiểm tra lại dữ liệu",
                        "IN BÁO CÁO",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }

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
                    OrderTableModel model = gridControlOrders.SelectedItem as OrderTableModel;
                    Models.Order order = App.orderController.getById(model.Id);
                    App.orderController.ExportInvoice(order);
                }
                catch (Exception)
                {

                }
            }
        }

        private void btnSearchOrder_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSearchOrder.Text))
            {
                LoadOrderTable();
            }
            else
            {
                List<OrderTableModel> orders = App.orderController.GetListTableModelBySearch(txtSearchOrder.Text);
                gridControlOrders.ItemsSource = orders;
                gridControlOrders.RefreshData();
                ((TableView)gridControlOrders.View).BestFitColumns();
            }
        }

        private void btnClearSearchOrder_Click(object sender, RoutedEventArgs e)
        {
            txtSearchOrder.Clear();
            LoadOrderTable();
        }

        private void txtSearchOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                btnSearchOrder_Click(null, null);
        }
    }
}
