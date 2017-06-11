using DevExpress.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSuperMarket.Models;
using WPFSuperMarket.Providers;

namespace WPFSuperMarket.Controllers
{
    public class InventoryController
    {
        private InventoryProvider _inventoryProvider
        {
            get
            {
                return new InventoryProvider();
            }
        }

        private ProductProvider _productProvider
        {
            get
            {
                return new ProductProvider();
            }
        }

        public InventoryController()
        {
        }

        public bool Update(Inventory inventory)
        {
            return (_inventoryProvider.Update(inventory)
                    && _productProvider.ChangeQuantity(inventory.ProductId, inventory.Quantity));
        }

        public bool In(Inventory inventory)
        {
            return _inventoryProvider.In(inventory);
        }

        public bool Out(Inventory inventory)
        {
            return _inventoryProvider.Out(inventory);
        }

        public void Export(int Id)
        {
            try
            {
                Inventory inventory = _inventoryProvider.GetById(Id);

                Workbook book = new Workbook();

                book.Styles.DefaultStyle.Font.Name = "Segoe UI";
                book.Styles.DefaultStyle.Font.Size = 11;

                book.Worksheets[0].MergeCells(book.Worksheets[0].Range["A2:B2"]);

                if (inventory.Type == 0)
                {
                    book.Worksheets[0].Range["A2:B2"].Value = "CẬP NHẬT TỒN KHO";
                }
                if (inventory.Type == 1)
                {
                    book.Worksheets[0].Range["A2:B2"].Value = "NHẬP KHO";
                }
                if (inventory.Type == 2)
                {
                    book.Worksheets[0].Range["A2:B2"].Value = "XUẤT KHO";
                }
                book.Worksheets[0].Range["A2:B2"].Font.Size = 13;
                book.Worksheets[0].Range["A2:B2"].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;

                book.Worksheets[0].Cells["A3"].Value = "Mã số: ";
                book.Worksheets[0].Cells["B3"].Value = inventory.Id;
                book.Worksheets[0].Cells["B3"].Font.Bold = true;
                book.Worksheets[0].Cells["A4"].Value = "Ngày: ";
                book.Worksheets[0].Cells["B4"].Value = inventory.CreateTime.Date.ToString("dd/MM/yyyy");
                book.Worksheets[0].Cells["A5"].Value = "Giờ: ";
                book.Worksheets[0].Cells["B5"].Value = inventory.CreateTime.ToString("HH:mm:ss");
                book.Worksheets[0].Cells["A6"].Value = "Nhân viên: ";
                book.Worksheets[0].Cells["A7"].Value = inventory.Account?.Name ?? "";
                book.Worksheets[0].Cells["A8"].Value = "Tên Mặt hàng: ";
                book.Worksheets[0].Cells["A8"].AutoFitColumns();
                book.Worksheets[0].Cells["A9"].Value = inventory.Product?.Name ?? "";
                book.Worksheets[0].Cells["A9"].Font.Bold = true;
                book.Worksheets[0].Cells["A10"].Value = "Số lượng: ";
                book.Worksheets[0].Cells["B10"].Value = inventory.Quantity;
                book.Worksheets[0].Cells["B10"].Font.Bold = true;

                book.Worksheets[0].Cells["A12"].Value = "Chi tiết: ";
                book.Worksheets[0].Cells["A13"].Value = inventory.Detail;

                book.SaveDocument(App.DefaultInventoryPath + inventory.Id + ".xlsx", DocumentFormat.Xlsx);

                System.Diagnostics.Process.Start(App.DefaultInventoryPath + inventory.Id + ".xlsx");
            }
            catch (Exception ex)
            {

            }
        }

        //public InventoryTableModel GetListTableModelByProductId(int productId)
        //{
        //    return InventoryTableModel.ToListTableModelByList(_inventoryProvider.GetByProductId(productId));
        //}
    }
}
