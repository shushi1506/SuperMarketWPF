using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSuperMarket.Models
{
    public class InventoryTableModel
    {
        [Display(Name = "Mã số")]
        [Editable(false)]
        public int Id { get; set; }

        [Display(Name = "Loại")]
        [Editable(false)]
        public string Type { get; set; }
        
        //[Display(Name = "Mã vạch")]
        //[Editable(false)]
        //public string ProductBarCode { get; set; }

        //[Display(Name = "Tên Sản phẩm")]
        //[Editable(false)]
        //public string ProductName { get; set; }

        [Display(Name = "Số lượng")]
        [Editable(false)]
        public int Quantity { get; set; }

        [Display(Name = "Thời gian")]
        [Editable(false)]
        public string CreateTime { get; set; }

        [Display(Name = "Nhân viên")]
        [Editable(false)]
        public string CreatedBy { get; set; }

        public InventoryTableModel()
        {

        }

        public InventoryTableModel(Inventory inventory)
        {
            Id = inventory.Id;
            if (inventory.Type == 0) Type = "Cập nhật";
            if (inventory.Type == 1) Type = "Nhập kho";
            if (inventory.Type == 2) Type = "Xuất kho";
            //ProductBarCode = inventory.Product ? .BarCode ?? "";
            //ProductName = inventory.Product ? .Name ?? "";
            Quantity = inventory.Quantity;
            CreateTime = inventory.CreateTime.ToString("dd/MM/yyyy HH:mm:ss");
            CreatedBy = inventory.Account ? .Name ?? "";
        }

        public static List<InventoryTableModel> ToListTableModelByList(List<Inventory> inventories)
        {
            List<InventoryTableModel> list = new List<InventoryTableModel>();

            foreach (var item in inventories)
            {
                list.Add(new InventoryTableModel(item));
            }

            return list;
        }
    }
}
