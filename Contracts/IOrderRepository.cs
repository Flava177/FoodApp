using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders(Guid restaurantId, bool trackChanges);
        Order GetOrder(Guid restaurantId, Guid id, bool trackChanges);
        //void CreateOrderForMenu(Guid restaurantId, string userId, int orderStatusId, Guid dispatchDriverId, Order order);

        void CreateOrder(Guid restaurantId, Guid menuItemId, int userId,int orderStatusId, Guid dispatchDriver, Order order);

    }
}
