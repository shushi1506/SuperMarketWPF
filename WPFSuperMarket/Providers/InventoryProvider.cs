using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSuperMarket.Models;

namespace WPFSuperMarket.Providers
{
    public class InventoryProvider
    {
        private SuperMarketEntities db;

        public InventoryProvider()
        {
            db = new SuperMarketEntities();
        }

        public bool Update(Inventory inventory)
        {
            try
            {
                inventory.CreateTime = DateTime.Now;
                inventory.Type = 0;
                db.Inventories.Add(inventory);

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool In(Inventory inventory)
        {
            try
            {
                Product product = db.Products.Single(m => m.Id == inventory.ProductId);
                if (product.Quantity.HasValue)
                {
                    product.Quantity = product.Quantity.Value + inventory.Quantity;
                }
                else
                {
                    product.Quantity = inventory.Quantity;
                }

                inventory.CreateTime = DateTime.Now;
                inventory.Type = 1;
                db.Inventories.Add(inventory);

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Out(Inventory inventory)
        {
            try
            {
                Product product = db.Products.Single(m => m.Id == inventory.ProductId);
                if (product.Quantity.HasValue)
                {
                    product.Quantity = product.Quantity.Value - inventory.Quantity;
                }
                else
                {
                    return false;
                }

                inventory.CreateTime = DateTime.Now;
                inventory.Type = 2;
                db.Inventories.Add(inventory);

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Inventory GetById(int Id)
        {
            try
            {
                return db.Inventories.Single(m => m.Id == Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public List<Inventory> GetByProductId(int productId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
