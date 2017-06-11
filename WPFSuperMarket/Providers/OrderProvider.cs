using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSuperMarket.Models;

namespace WPFSuperMarket.Providers
{
    public class OrderProvider
    {
        private SuperMarketEntities db;

        public OrderProvider()
        {
            db = new SuperMarketEntities();
        }

        public List<Order> getAll()
        {
            try
            {
                return db.Orders.OrderByDescending(m => m.Id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Order getById(int Id)
        {
            try
            {
                return db.Orders.Single(m => m.Id == Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Insert(Order order, List<OrderLineTableModel> orderLineModels)
        {
            try
            {
                order.CreateTime = DateTime.Now;

                List<OrderLine> orderLines = new List<OrderLine>(order.OrderLines);
                order.OrderLines.Clear();

                db.Orders.Add(order);
                db.SaveChanges();

                foreach (var orderLine in orderLines)
                {
                    orderLine.OrderId = order.Id;
                    orderLine.AccountId = order.AccountId;
                    orderLine.CreateTime = DateTime.Now;

                    db.OrderLines.Add(orderLine);
                }

                db.SaveChanges();

                foreach (var item in orderLineModels)
                {
                    Product product = db.Products.Single(m => m.Id == item.ProductId);

                    if (product.Quantity.HasValue && (product.Quantity.Value - item.Quantity >= 0))
                        product.Quantity = product.Quantity.Value - item.Quantity;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Insert(Order order)
        {
            try
            {
                order.CreateTime = DateTime.Now;

                List<OrderLine> orderLines = new List<OrderLine>(order.OrderLines);
                order.OrderLines.Clear();

                db.Orders.Add(order);
                db.SaveChanges();

                foreach (var orderLine in orderLines)
                {
                    orderLine.OrderId = order.Id;
                    orderLine.AccountId = order.AccountId;
                    orderLine.CreateTime = DateTime.Now;

                    db.OrderLines.Add(orderLine);
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Order> GetListByCreateTime(DateTime from, DateTime to)
        {
            try
            {
                from = from.Date;
                to = to.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                return db.Orders.Where(
                        m
                        => from <= m.CreateTime
                        && m.CreateTime <= to
                    ).ToList();
            }
            catch (Exception ex)
            {

                return new List<Order>();
            }
        }

        public List<Order> GetListTodayByAccountId(int accountId)
        {
            try
            {
                return GetListByCreateTime(DateTime.Now, DateTime.Now)
                    .Where(m => m.AccountId == accountId).ToList();
            }
            catch (Exception ex)
            {
                return new List<Order>();
            }
        }

        public List<Order> GetListBySearch(string search)
        {
            try
            {
                return db.Orders.Where(
                    m
                    => m.Id.ToString().Contains(search)
                    || (m.Account != null && m.Account.Name.ToLower().Contains(search))
                    || (m.Account != null && m.Account.Username.ToLower().Contains(search))
                    || m.GuessName.Contains(search)
                ).OrderByDescending(m => m.Id).ToList();
            }
            catch (Exception ex)
            {
                return new List<Order>();
            }
        }
    }
}
