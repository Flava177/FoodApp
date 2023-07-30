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
        void CreateOrder(Guid restaurantId, Guid menuItemId, string userId, Guid dispatchDriver, Order order);
        Task<Order> GetOrdersAsync(Guid id);
        Task<List<Order>> GetAllOrdersForUserAsync(string userId);

    }
}
