using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavTech.Models;
namespace NavTech.DAL
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int Id);
        void Add(Order order);
        void Delete(int Id);
        void Update(Order order);
     

    }
}






