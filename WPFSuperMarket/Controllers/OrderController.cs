using DevExpress.Spreadsheet;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSuperMarket.Models;
using WPFSuperMarket.Providers;

namespace WPFSuperMarket.Controllers
{
    public class OrderController
    {
        private OrderProvider _orderProvider
        {
            get
            {
                return new OrderProvider();
            }
        }

        public bool Add(Models.Order order)
        {
            return _orderProvider.Insert(order);
        }


        internal bool Add(Order order, List<OrderLineTableModel> orderLines)
        {
            return _orderProvider.Insert(order, orderLines);
        }

        public List<OrderTableModel> ListOrdersTableModel
        {
            get
            {
                return OrderTableModel.ToListByListOrder(_orderProvider.getAll());
            }
        }

        public Order getById(int id)
        {
            return _orderProvider.getById(id);
        }

        public static void FormatHeader(ExcelWorksheet objWorksheet, int FromRow, int FromCol, int ToRow, int ToCol)
        {
            using (ExcelRange objRange = objWorksheet.Cells[FromRow, FromCol, ToRow, ToCol])
            {
                objRange.Style.Font.Bold = true;
                objRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                objRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                objRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                objRange.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(234, 234, 234));
            }
        }

        internal List<OrderTableModel> GetListTodayByAccountId(int accountId)
        {
            return OrderTableModel.ToListByListOrder(_orderProvider.GetListTodayByAccountId(accountId));
        }

        public void ExportInvoice(Models.Order order)
        {
            try
            {
                Workbook book = new Workbook();

                book.Styles.DefaultStyle.Font.Name = "Segoe UI";
                book.Styles.DefaultStyle.Font.Size = 9;

                book.Worksheets[0].MergeCells(book.Worksheets[0].Range["A2:D2"]);
                book.Worksheets[0].Range["A2:D2"].Value = "HÓA ĐƠN BÁN LẺ";
                book.Worksheets[0].Range["A2:D2"].Font.Size = 12;
                book.Worksheets[0].Range["A2:D2"].Font.Bold = true;
                book.Worksheets[0].Range["A2:D2"].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                book.Worksheets[0].Range["A2:D2"].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                book.Worksheets[0].Range["A2:D2"].RowHeight = 110;

                book.Worksheets[0].Cells["A3"].Value = "Mã số: ";
                book.Worksheets[0].Cells["D3"].Value = order.Id;
                book.Worksheets[0].Cells["A4"].Value = "Ngày: ";
                book.Worksheets[0].Cells["D4"].Value = order.CreateTime.Date.ToString("dd/MM/yyyy");
                book.Worksheets[0].Cells["A5"].Value = "Giờ: ";
                book.Worksheets[0].Cells["D5"].Value = order.CreateTime.ToString("HH:mm:ss");
                book.Worksheets[0].Cells["A6"].Value = "Thu ngân: ";
                book.Worksheets[0].Cells["D6"].Value = order.Account?.Name ?? "";

                book.Worksheets[0].Cells["A7"].Value = "Tên khách: ";
                book.Worksheets[0].Cells["D7"].Value = order.GuessName;
                book.Worksheets[0].Cells["A7"].AutoFitColumns();

                book.Worksheets[0].Range["D3:D7"].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;


                book.Worksheets[0].Cells["A9"].Value = "Sản phẩm: ";
                book.Worksheets[0].Cells["C9"].Value = "S/L: ";
                book.Worksheets[0].Cells["D9"].Value = "Tổng: ";
                book.Worksheets[0].Range["A9:D9"].RowHeight = 90;


                book.Worksheets[0].Range["A9:D9"].ColumnWidthInCharacters = 8;
                Formatting header = book.Worksheets[0].Range["A9:D9"].BeginUpdateFormatting();
                header.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                header.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                header.Borders.BottomBorder.Color = System.Drawing.Color.Black;
                header.Borders.BottomBorder.LineStyle = BorderLineStyle.Dashed;
                header.Borders.TopBorder.Color = System.Drawing.Color.Black;
                header.Borders.TopBorder.LineStyle = BorderLineStyle.Dashed;
                book.Worksheets[0].Range["A9:D9"].EndUpdateFormatting(header);

                book.Worksheets[0].Cells["D9"].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;

                int row = 10;
                foreach (var item in order.OrderLines)
                {
                    book.Worksheets[0].Cells["A" + row].Value = item.Name;
                    book.Worksheets[0].Cells["C" + row].Value = item.Quantity;
                    book.Worksheets[0].Cells["D" + row].Value = Helpers.MoneyHelper.PriceToVND(item.TotalPrice);
                    book.Worksheets[0].Range["A" + row + ":D" + row].RowHeight = 90;
                    book.Worksheets[0].Range["A" + row + ":D" + row].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                    book.Worksheets[0].Cells["D" + row].AutoFitColumns();
                    row++;
                }

                book.Worksheets[0].Cells["A" + row].Value = "Tổng cộng: ";
                book.Worksheets[0].Cells["D" + row].Value = Helpers.MoneyHelper.PriceToVND(order.TotalPrice);
                header = book.Worksheets[0].Range["A" + row + ":D" + row].BeginUpdateFormatting();
                header.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                header.Borders.BottomBorder.Color = System.Drawing.Color.Black;
                header.Borders.BottomBorder.LineStyle = BorderLineStyle.Dashed;
                header.Borders.TopBorder.Color = System.Drawing.Color.Black;
                header.Borders.TopBorder.LineStyle = BorderLineStyle.Dashed;
                book.Worksheets[0].Range["A" + row + ":D" + row].EndUpdateFormatting(header);
                book.Worksheets[0].Range["A" + row + ":D" + row].RowHeight = 90;
                book.Worksheets[0].Cells["D" + row].AutoFitColumns();
                row++;

                book.Worksheets[0].Cells["A" + row].Value = "Khuyến mãi ";
                book.Worksheets[0].Cells["D" + row].Value = Helpers.MoneyHelper.PriceToVND(order.Discount);
                header = book.Worksheets[0].Range["A" + row + ":D" + row].BeginUpdateFormatting();
                header.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                header.Borders.BottomBorder.Color = System.Drawing.Color.Black;
                header.Borders.BottomBorder.LineStyle = BorderLineStyle.Dashed;
                header.Borders.TopBorder.Color = System.Drawing.Color.Black;
                header.Borders.TopBorder.LineStyle = BorderLineStyle.Dashed;
                book.Worksheets[0].Range["A" + row + ":D" + row].EndUpdateFormatting(header);
                book.Worksheets[0].Range["A" + row + ":D" + row].RowHeight = 90;
                book.Worksheets[0].Cells["D" + row].AutoFitColumns();
                row++;

                book.Worksheets[0].Cells["A" + row].Value = "VAT: ";
                book.Worksheets[0].Cells["D" + row].Value = Helpers.MoneyHelper.PriceToVND(order.VATPrice);
                header = book.Worksheets[0].Range["A" + row + ":D" + row].BeginUpdateFormatting();
                header.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                header.Borders.BottomBorder.Color = System.Drawing.Color.Black;
                header.Borders.BottomBorder.LineStyle = BorderLineStyle.Dashed;
                header.Borders.TopBorder.Color = System.Drawing.Color.Black;
                header.Borders.TopBorder.LineStyle = BorderLineStyle.Dashed;
                book.Worksheets[0].Range["A" + row + ":D" + row].EndUpdateFormatting(header);
                book.Worksheets[0].Range["A" + row + ":D" + row].RowHeight = 90;
                book.Worksheets[0].Cells["D" + row].AutoFitColumns();
                row++;
                row++;

                header = book.Worksheets[0].Range["A" + row + ":D" + row].BeginUpdateFormatting();
                header.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                header.Borders.BottomBorder.Color = System.Drawing.Color.Black;
                header.Borders.BottomBorder.LineStyle = BorderLineStyle.Dashed;
                header.Borders.TopBorder.Color = System.Drawing.Color.Black;
                header.Borders.TopBorder.LineStyle = BorderLineStyle.Dashed;
                header.Font.Bold = true;
                book.Worksheets[0].Range["A" + row + ":D" + row].EndUpdateFormatting(header);
                book.Worksheets[0].Cells["A" + row].Value = "Tổng thanh toán: ";
                book.Worksheets[0].Cells["D" + row].Value = Helpers.MoneyHelper.PriceToVND(order.PaidPrice);
                book.Worksheets[0].Range["A" + row + ":D" + row].RowHeight = 120;
                book.Worksheets[0].Cells["D" + row].AutoFitColumns();
                book.Worksheets[0].Range["C9:D" + row].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;

                book.SaveDocument(App.DefaultExportOrderPath + order.Id + ".xlsx", DocumentFormat.Xlsx);

                System.Diagnostics.Process.Start(App.DefaultExportOrderPath + order.Id + ".xlsx");
            }
            catch (Exception ex)
            {

            }

        }

        public List<OrderTableModel> GetListTableModelBySearch(string search)
        {
            return OrderTableModel.ToListByListOrder(_orderProvider.GetListBySearch(search));
        }

        public void ExportStatistic(List<OrderTableModel> list, DateTime from, DateTime to)
        {
            try
            {
                Workbook book = new Workbook();

                book.Styles.DefaultStyle.Font.Name = "Segoe UI";
                book.Styles.DefaultStyle.Font.Size = 10;

                book.Worksheets[0].MergeCells(book.Worksheets[0].Range["A2:G2"]);
                book.Worksheets[0].Range["A2:G2"].Value = "SAO KÊ HÓA ĐƠN";
                book.Worksheets[0].Range["A2:G2"].Font.Size = 12;
                book.Worksheets[0].Range["A2:G2"].Font.Bold = true;
                book.Worksheets[0].Range["A2:G2"].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                book.Worksheets[0].Range["A2:G2"].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                book.Worksheets[0].Range["A2:G2"].RowHeight = 150;

                book.Worksheets[0].Cells["A3"].Value = "Từ ngày: ";
                book.Worksheets[0].Cells["A4"].Value = "Đến ngày: ";
                book.Worksheets[0].Cells["B3"].Value = from.ToString("dd/MM/yyyy HH:mm:ss");
                book.Worksheets[0].Cells["B4"].Value = to.ToString("dd/MM/yyyy HH:mm:ss");
                book.Worksheets[0].Cells["A5"].Value = "Số lượng: ";
                book.Worksheets[0].Cells["B5"].Value = list.Count;
                book.Worksheets[0].Cells["A6"].Value = "Nhân viên: ";
                book.Worksheets[0].Cells["B6"].Value = App.accountController.Account ? .Name ?? "";
                book.Worksheets[0].Cells["B6"].AutoFitColumns();

                book.Worksheets[0].Cells["A8"].Value = "Mã số";
                book.Worksheets[0].Cells["B8"].Value = "Thời gian tạo";
                book.Worksheets[0].Cells["C8"].Value = "Thu ngân";
                book.Worksheets[0].Cells["D8"].Value = "Tên khách";
                book.Worksheets[0].Cells["E8"].Value = "Tổng tiền";
                book.Worksheets[0].Cells["F8"].Value = "VAT";
                book.Worksheets[0].Cells["G8"].Value = "Thanh toán";

                book.Worksheets[0].Range["A8:G8"].RowHeight = 110;

                Formatting header = book.Worksheets[0].Range["A8:G8"].BeginUpdateFormatting();
                header.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                header.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                header.Borders.BottomBorder.Color = System.Drawing.Color.Black;
                header.Borders.BottomBorder.LineStyle = BorderLineStyle.Dashed;
                header.Borders.TopBorder.Color = System.Drawing.Color.Black;
                header.Borders.TopBorder.LineStyle = BorderLineStyle.Dashed;
                book.Worksheets[0].Range["A8:G8"].EndUpdateFormatting(header);

                int row = 9;
                foreach (var item in list)
                {
                    book.Worksheets[0].Cells["A" + row].Value = item.Id;
                    book.Worksheets[0].Cells["B" + row].Value = item.CreateTime;
                    book.Worksheets[0].Cells["C" + row].Value = item.CreatedBy;
                    book.Worksheets[0].Cells["D" + row].Value = item.GuessName;
                    book.Worksheets[0].Cells["E" + row].Value = item.TotalPrice;
                    book.Worksheets[0].Cells["F" + row].Value = item.VATPrice;
                    book.Worksheets[0].Cells["G" + row].Value = item.PaidPrice;
                    book.Worksheets[0].Range["A" + row + ":G" + row].RowHeight = 110;
                    book.Worksheets[0].Range["A" + row + ":G" + row].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                    book.Worksheets[0].Range["B" + row + ":G" + row].AutoFitColumns();
                    row++;
                }

                long totalTotal = 0;
                long totalVAT = 0;
                long totalPaid = 0;
                
                foreach (var item in list)
                {
                    totalTotal += App.orderController.getById(item.Id).TotalPrice;
                    totalVAT += App.orderController.getById(item.Id).VATPrice;
                    totalPaid += App.orderController.getById(item.Id).PaidPrice;
                }

                header = book.Worksheets[0].Range["A" + row + ":G" + row].BeginUpdateFormatting();
                header.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                header.Borders.BottomBorder.Color = System.Drawing.Color.Black;
                header.Borders.BottomBorder.LineStyle = BorderLineStyle.Dashed;
                header.Borders.TopBorder.Color = System.Drawing.Color.Black;
                header.Borders.TopBorder.LineStyle = BorderLineStyle.Dashed;
                header.Font.Bold = true;
                book.Worksheets[0].Range["A" + row + ":G" + row].EndUpdateFormatting(header);
                book.Worksheets[0].Cells["A" + row].Value = "Tổng: ";
                book.Worksheets[0].Cells["E" + row].Value = Helpers.MoneyHelper.PriceToVND(totalTotal);
                book.Worksheets[0].Cells["F" + row].Value = Helpers.MoneyHelper.PriceToVND(totalVAT);
                book.Worksheets[0].Cells["G" + row].Value = Helpers.MoneyHelper.PriceToVND(totalPaid);
                book.Worksheets[0].Range["A" + row + ":G" + row].RowHeight = 140;
                book.Worksheets[0].Range["B" + row + ":G" + row].AutoFitColumns();

                string path =
                    App.DefaultExportOrderPath
                    + from.ToString("dd-MM-yyyy") + " - " + to.ToString("dd-MM-yyyy")
                    + " bởi " + (App.accountController.Account?.Name ?? "")
                    + ".xlsx";

                book.SaveDocument(path, DocumentFormat.Xlsx);

                System.Diagnostics.Process.Start(path);
            }
            catch (Exception)
            {

            }

        }

        public List<OrderTableModel> GetListByCreateTime(DateTime from, DateTime to)
        {
            return OrderTableModel.ToListByListOrder(_orderProvider.GetListByCreateTime(from, to));
        }

    }
}
