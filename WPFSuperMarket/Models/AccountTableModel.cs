using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSuperMarket.Models
{
    public class AccountTableModel
    {
        [Display(Name = "Mã số")]
        [Editable(false)]
        public int Id { get; set; }

        [Display(Name = "Tên Tài khoản")]
        [Editable(false)]
        public string Username { get; set; }

        [Display(Name = "Thư điện tử")]
        [Editable(false)]
        public string Email { get; set; }

        [Display(Name = "Thời gian tạo")]
        [Editable(false)]
        public System.DateTime CreateTime { get; set; }

        [Display(Name = "Tài khoản tạo")]
        [Editable(false)]
        public string CreatedBy { get; set; }

        [Editable(false)]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }

        [Display(Name = "CMND")]
        [Editable(false)]
        public string IdCard { get; set; }

        [Display(Name = "Điện thoại")]
        [Editable(false)]
        public string Phone { get; set; }
        [Browsable(false)]
        public string Picture { get; set; }
        public AccountTableModel()
        {

        }

        public AccountTableModel(Account account)
        {
            Id = account.Id;
            Username = account.Username;
            Email = account.Email;
            CreateTime = account.CreateTime;
            CreatedBy = account.ParentAccount ? .Name ?? "";
            Name = account.Name;
            IdCard = account.IdCard;
            Phone = account.Phone;
            Picture = account.Picture;
        }

        public static List<AccountTableModel> ToListByListAccount(List<Account> accounts)
        {
            List<AccountTableModel> list = new List<AccountTableModel>();

            foreach (var item in accounts)
            {
                list.Add(new AccountTableModel(item));
            }

            return list;
        }
    }
}
