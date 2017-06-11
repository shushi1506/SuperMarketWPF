using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSuperMarket.Models
{
    public class OrderTableModel
    {
        [Display(Name = "Mã số")]
        [Editable(false)]
        public int Id { get; set; }

        [Display(Name = "Thời gian tạo")]
        [Editable(false)]
        public string CreateTime { get; set; }

        [Display(Name = "Tài khoản tạo")]
        [Editable(false)]
        public string CreatedBy { get; set; }

        [Display(Name = "Tên khách")]
        [Editable(false)]
        public string GuessName { get; set; }

        [Display(Name = "Tổng tiền")]
        [Editable(false)]
        public string TotalPrice { get; set; }

        [Display(Name = "Thuế VAT")]
        [Editable(false)]
        public string VATPrice { get; set; }

        [Display(Name = "Thanh toán")]
        [Editable(false)]
        public string PaidPrice { get; set; }
        [Browsable(false)]
        public string PictureAccount { get; set; }
        public OrderTableModel()
        {

        }

        public OrderTableModel(Order order)
        {
            Id = order.Id;
            CreateTime = order.CreateTime.ToString("dd/MM/yyyy");
            CreatedBy = order.Account ? .Name ?? "";
            PictureAccount = order.Account.Picture;
            GuessName = order.GuessName;
            TotalPrice = Helpers.MoneyHelper.PriceToVND(order.TotalPrice);
            VATPrice = Helpers.MoneyHelper.PriceToVND(order.VATPrice);
            PaidPrice = Helpers.MoneyHelper.PriceToVND(order.PaidPrice);
        }

        public static List<OrderTableModel> ToListByListOrder(List<Order> orders)
        {
            List<OrderTableModel> list = new List<OrderTableModel>();

            foreach (var item in orders)
            {
                list.Add(new OrderTableModel(item));
            }

            return list;
        }
    }
}
