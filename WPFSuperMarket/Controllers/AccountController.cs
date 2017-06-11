using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WPFSuperMarket.Models;
using WPFSuperMarket.Providers;

namespace WPFSuperMarket.Controllers
{
    public class AccountController
    {
        private AccountProvider _accountProvider
        {
            get
            {
                return new AccountProvider();
            }
        }

        public Account Account { get; set; }

        public AccountController()
        {
            Account = null;
            //_accountProvider = new AccountProvider();
        }

        public bool Login(string Username, string Password)
        {
            Account = _accountProvider.getByUsernameAndHashedPassword(Username, MD5(Password));
            if (Account != null)
            {
                return true;
            }

            return false;
        }

        public byte[] EncryptData(string data)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }

        public string MD5(string data)
        {
            return BitConverter.ToString(EncryptData(data)).Replace("-", "").ToLower();
        }

        public List<AccountTableModel> ListAccountsTableModel
        {
            get
            {
                return AccountTableModel.ToListByListAccount(_accountProvider.getAll());
            }
        }

        public Account GetAccountById(int Id)
        {
            return _accountProvider.getById(Id);
        }

        public bool Update(Account account)
        {
            return _accountProvider.Update(account);
        }

        public bool Add(Account account)
        {
            account.HashedPassword = MD5(account.HashedPassword);
            bool key = _accountProvider.Insert(account);
            if (!key) return key;

            try
            {
                byte[] imageBytes = System.IO.File.ReadAllBytes(App.BaseImageDirectory + account.Picture);

                System.IO.File.WriteAllBytes(
                    App.BaseImageDirectory + account.Id + ".jpg",
                    (byte[])imageBytes);

                account.Picture = account.Id + ".jpg";
                _accountProvider.Update(account);
            }
            catch (Exception)
            {

            }

            return key;
        }

        internal bool ChangePassword(int id, string password)
        {
            password = MD5(password);
            return _accountProvider.ChangePassword(id, password);
        }

        public bool Delete(int id)
        {
            return _accountProvider.Delete(id);
        }

        internal bool UnSetAdmin(int id)
        {
            return _accountProvider.UnSetAdmin(id);
        }

        internal bool SetAdmin(int id)
        {
            return _accountProvider.SetAdmin(id);
        }
    }
}
