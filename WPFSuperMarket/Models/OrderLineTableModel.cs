using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSuperMarket.Models
{
    public class OrderLineTableModel
    {
        [Display(Name = "STT")]
        [Editable(false)]
        public int Id { get; set; }

        [Display(Name = "Mã SP")]
        [Editable(false)]
        public int ProductId { get; set; }

        [Display(Name = "Mã vạch")]
        [Editable(false)]
        public string ProductBarCode { get; set; }

        [Display(Name = "Sản phẩm")]
        [Editable(false)]
        public string ProductName { get; set; }

        [Display(Name = "Số lượng")]
        [Editable(false)]
        public int Quantity { get; set; }

        [Display(Name = "Giá tiền")]
        [Editable(false)]
        public string ProductUnitPrice { get; set; }

        [Display(Name = "Thành tiền")]
        [Editable(false)]
        public string TotalPrice { get; set; }
        [Browsable(false)]
        public string PictureAcount { get; set; }
        [Browsable(false)]
        public string PictureProduct { get; set; }
        public OrderLineTableModel()
        {

        }

        public OrderLineTableModel(OrderLine orderLine)
        {
            this.Id = orderLine.Id;
            ProductBarCode = orderLine.BarCode;
            ProductName = orderLine.Name;
            ProductUnitPrice = Helpers.MoneyHelper.PriceToVND(orderLine.UnitPrice);
            Quantity = orderLine.Quantity;
            TotalPrice = Helpers.MoneyHelper.PriceToVND(orderLine.TotalPrice);
            PictureAcount = orderLine.Account.Picture;
            PictureProduct = App.productController.GetByBarCode(orderLine.BarCode).Picture;
        }

        public OrderLineTableModel(int Id, Product product, int Quantity)
        {
            this.Id = Id;
            ProductId = product.Id;
            ProductBarCode = product.BarCode;
            ProductName = product.Name;
            this.Quantity = Quantity;
            ProductUnitPrice = Helpers.MoneyHelper.PriceToVND(product.Price);
            TotalPrice = Helpers.MoneyHelper.PriceToVND((long)(product.Price * Quantity));
            PictureProduct = product.Picture;
        }

        public OrderLine ToOrderLine()
        {
            OrderLine orderLine = new OrderLine();

            try
            {
                Product product = App.productController.GetById(ProductId);
                orderLine.BarCode = product.BarCode;
                orderLine.Name = product.Name;
                orderLine.Quantity = Quantity;
                orderLine.UnitPrice = product.Price;
                long totalnoVAT= (long)(orderLine.Quantity * orderLine.UnitPrice); ;
                orderLine.VATPrice = (long)(totalnoVAT/ 10);
                orderLine.TotalPrice = (long)(orderLine.Quantity * orderLine.UnitPrice );
                orderLine.PaidPrice = orderLine.TotalPrice +orderLine.VATPrice;
            }
            catch (Exception)
            {

            }

            return orderLine;
        }

        public static List<OrderLineTableModel> ToListByListOrderLine(List<OrderLine> orderLines)
        {
            List<OrderLineTableModel> list = new List<OrderLineTableModel>();

            foreach (var item in orderLines)
            {
                list.Add(new OrderLineTableModel(item));
            }

            return list;
        }
    }
}
