using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSuperMarket.Models;

namespace WPFSuperMarket.Providers
{
    public class AccountProvider
    {
        private SuperMarketEntities db;
    
        public AccountProvider()
        {
            db = new SuperMarketEntities();
        }

        public AccountProvider(string connectionString)
        {
            db = new SuperMarketEntities(connectionString);
        }

        public List<Account> getAll()
        {
            try
            {
                return db.Accounts.OrderByDescending(m => m.Id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Account getById(int Id)
        {
            try
            {
                return db.Accounts.Single(m => m.Id == Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Account getByUsernameAndHashedPassword(string Username, string HashedPassword)
        {
            try
            {
                return db.Accounts
                    .Single(
                        m 
                        => m.Username.Equals(Username) 
                        && m.HashedPassword.Equals(HashedPassword)
                    );
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Insert(Account account)
        {
            try
            {
                account.CreateTime = DateTime.Now;

                db.Accounts.Add(account);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Account account)
        {
            try
            {
                Account oldAccount = getById(account.Id);
                oldAccount.Name = account.Name;
                oldAccount.IdCard = account.IdCard;
                oldAccount.Phone = account.Phone;
                oldAccount.Detail = account.Detail;
                oldAccount.Picture = account.Picture;
                    

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                db.Accounts.Remove(getById(Id));

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteList(List<int> Idies)
        {
            try
            {
                foreach (var Id in Idies)
                {
                    db.Accounts.Remove(getById(Id));
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal bool UnSetAdmin(int id)
        {
            try
            {
                if (db.Accounts.Count(m => m.Admin.HasValue && m.Admin.Value == 1) <= 1) return false;

                getById(id).Admin = 0;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal bool SetAdmin(int id)
        {
            try
            {
                getById(id).Admin = 1;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ChangePassword(int Id, string HashedPassword)
        {
            try
            {
                Account account = getById(Id);
                account.HashedPassword = HashedPassword;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
