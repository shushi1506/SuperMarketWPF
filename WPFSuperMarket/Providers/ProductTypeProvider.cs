using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSuperMarket.Models;

namespace WPFSuperMarket.Providers
{
    public class ProductTypeProvider
    {
        private SuperMarketEntities db;

        public ProductTypeProvider()
        {
            db = new SuperMarketEntities();
        }

        public ProductTypeProvider(string connectionString)
        {
            db = new SuperMarketEntities(connectionString);
        }

        public List<ProductType> getAll()
        {
            try
            {
                return db.ProductTypes.OrderByDescending(m => m.Id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ProductType getById(int Id)
        {
            try
            {
                return db.ProductTypes.Single(m => m.Id == Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Insert(ProductType productType)
        {
            try
            {
                productType.CreateTime = DateTime.Now;

                db.ProductTypes.Add(productType);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(ProductType productType)
        {
            try
            {
                ProductType old = getById(productType.Id);
                old.Name = productType.Name;
                old.Detail = productType.Detail;
                old.ParentId = productType.ParentId;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ProductType> Search(string search)
        {
            try
            {
                search = search.ToLower();
                return db.ProductTypes.Where(
                        m
                        => m.Id.ToString().ToLower().Contains(search)
                        || m.Name.ToLower().Contains(search)
                        || ((m.ParentProductType != null) && m.ParentProductType.Name.ToLower().Contains(search))
                    ).ToList(); 

            }
            catch (Exception)
            {
                return new List<ProductType>();
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                db.ProductTypes.Remove(getById(Id));

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
                    db.ProductTypes.Remove(getById(Id));
                }

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
