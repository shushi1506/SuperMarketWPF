using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSuperMarket.Models;

namespace WPFSuperMarket.Providers
{
    public class OrderLineProvider
    {
        private SuperMarketEntities db;

        public OrderLineProvider()
        {
            db = new SuperMarketEntities();
        }


        //public bool Insert(OrderLine orderLine, Order order)
        //{
        //    try
        //    {
        //        orderLine.OrderId = order.Id;
        //        orderLine.AccountId = order.AccountId;
        //        orderLine.CreateTime = DateTime.Now;

        //        db.OrderLines.Add(orderLine);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public bool Insert(List<OrderLine> orderLines, Order order)
        {
            try
            {
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
    }
}
