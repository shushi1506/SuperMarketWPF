using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSuperMarket.Models
{
    public class ProductTableModel
    {
        [Display(Name = "Mã số")]
        [Editable(false)]
        public int Id { get; set; }

        [Display(Name = "Mã vạch")]
        [Editable(false)]
        public string BarCode { get; set; }

        [Display(Name = "Tên Mặt hàng")]
        [Editable(false)]
        public string Name { get; set; }

        [Display(Name = "Tên Loại Mặt hàng")]
        [Editable(false)]
        public string TypeName { get; set; }

        [Display(Name = "Giá tiền")]
        [Editable(false)]
        public string Price { get; set; }

        [Display(Name = "Tồn kho")]
        [Editable(false)]
        public int Quantity { get; set; }

        [Display(Name = "Tình trạng")]
        [Editable(false)]
        public string Status { get; set; }
        [Browsable(false)]
        public string Picture { get; set; }
        public ProductTableModel()
        {

        }

        public ProductTableModel(Product product)
        {
            Id = product.Id;
            BarCode = product.BarCode;
            Name = product.Name;
            TypeName = product.ProductType ? .Name ?? "";
            Price = Helpers.MoneyHelper.PriceToVND(product.Price);
            Quantity = product.Quantity.HasValue ? product.Quantity.Value : 0;

            if (product.Status == 0)
            {
                Status = "Đang bán. ";
                if (product.Quantity.HasValue && product.Quantity.Value < 10 && product.Quantity.Value > 0)
                {
                    Status += "Sắp hết hàng. ";
                }
                if (!product.Quantity.HasValue || (product.Quantity.HasValue && product.Quantity.Value <= 0))
                {
                    Status += "Hết hàng. ";
                }
                if (product.ExpiredTime.HasValue && (product.ExpiredTime.Value >= DateTime.Now) && ((product.ExpiredTime.Value - DateTime.Now).Days <= 10))
                {
                    Status += "Sắp hết hạn. ";
                }
                if (product.ExpiredTime.HasValue && (product.ExpiredTime.Value < DateTime.Now))
                {
                    Status += "Hết hạn. ";
                }
            }
            if (product.Status == 1)
            {
                Status = "Tạm ngưng.";
            }
            Picture = product.Picture;
        }

        public static List<ProductTableModel> ToListByListProduct(List<Product> products)
        {
            List<ProductTableModel> list = new List<ProductTableModel>();

            foreach (var item in products)
            {
                list.Add(new ProductTableModel(item));
            }

            return list;
        }
    }
}
