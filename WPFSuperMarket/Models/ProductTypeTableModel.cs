using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSuperMarket.Models
{
    public class ProductTypeTableModel
    {
        [Display(Name = "Mã số")]
        [Editable(false)]
        public int Id { get; set; }

        [Display(Name = "Tên Loại Mặt hàng")]
        [Editable(false)]
        public string Name { get; set; }

        //[Display(Name = "Thời gian tạo")]
        //public string CreateTime { get; set; }

        //[Display(Name = "Tài khoản tạo")]
        //public string CreatedBy { get; set; }

        [Display(Name = "Loại Mặt hàng cha")]
        [Editable(false)]
        public string ParentName { get; set; }

        //[Display(Name = "Chi tiết")]
        //public string Detail { get; set; }

        [Display(Name = "Số Mặt hàng")]
        [Editable(false)]
        public int Quantity { get; set; }

        public ProductTypeTableModel()
        {

        }

        public ProductTypeTableModel(ProductType productType)
        {
            Id = productType.Id;
            Name = productType.Name;
            //CreateTime = productType.CreateTime.ToString("dd/MM/yyyy");
            //CreatedBy = productType.Account ? .Name ?? "";
            ParentName = productType.ParentProductType ? .Name ?? "";
            //Detail = productType.Detail;
            Quantity = productType.Products ? .Count ?? 0;
        }

        public static List<ProductTypeTableModel> ToListByListProductType(List<ProductType> list)
        {
            List<ProductTypeTableModel> all = new List<ProductTypeTableModel>();

            foreach (var item in list)
            {
                all.Add(new ProductTypeTableModel(item));
            }

            return all;
        }
    }
}
