using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSuperMarket.Models;

namespace WPFSuperMarket.Providers
{
    public class ProductProvider
    {
        private SuperMarketEntities db;

        public ProductProvider()
        {
            db = new SuperMarketEntities();
        }

        public List<Product> getAll()
        {
            try
            {
                return db.Products.OrderByDescending(m => m.Id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Product getById(int Id)
        {
            try
            {
                return db.Products.Single(m => m.Id == Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Product getByBarCode(string barcode)
        {
            try
            {
                return db.Products.Single(m => m.BarCode == barcode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(Product product)
        {
            try
            {
                product.CreateTime = DateTime.Now;

                db.Products.Add(product);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Product product)
        {
            try
            {
                Product old = getById(product.Id);

                old.BarCode = product.BarCode;
                old.Name = product.Name;
                old.TypeId = product.TypeId;
                old.Price = product.Price;
                old.Picture = product.Picture;
                old.Detail = product.Detail;
                old.ExpiredTime = product.ExpiredTime;

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
                db.Products.Remove(getById(Id));

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Pause(int Id)
        {
            try
            {
                Product product = getById(Id);
                product.Status = 1;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetBySearch(string search)
        {
            try
            {
                search = search.ToLower();

                return db.Products.Where(
                    m
                    => m.Id.ToString().Contains(search)
                    || m.BarCode.ToString().ToLower().Contains(search)
                    || (m.Account != null && m.Account.Name.ToLower().Contains(search))
                    || m.Name.ToLower().Contains(search)
                    || (m.ProductType != null && m.ProductType.Name.ToLower().Contains(search))
                ).OrderByDescending(m => m.Id).ToList();
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }

        public bool ChangeQuantity(int Id, int Quantity)
        {
            try
            {
                getById(Id).Quantity = Quantity;
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
