using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NavTech.Models;
using System.Data.Entity;
using System.Web.Http.ModelBinding;
using System.Security.Claims;
using NavTech.Services;
using System.Web.Http;
namespace NavTech.DAL
{
    public class OrderRepository : IOrderRepository
    {
        OrderContext context = new OrderContext();


        public IEnumerable<Order> GetOrders()
        {

            return context.Orders.ToList();
        }

        public Order GetOrder(int Id)
        {
            return context.Orders.Find(Id);
        }
        public void Add(Order order)
        {

            if (order == null)
            {
                throw new ArgumentNullException("order");
            }

            context.Orders.Add(order);
            context.SaveChanges();
        }


        public void Update(Order order)
        {
            Order od = context.Orders.Find(order.Id);

            od.ShippingAddress = order.ShippingAddress;
            od.Status = order.Status;
            context.SaveChangesAsync();

        }



        public void Delete(int ProdId)
        {
            Order od = context.Orders.Find(ProdId);
            context.Orders.Remove(od);
            context.SaveChangesAsync();
        }







        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}