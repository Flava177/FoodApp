using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        
        //Get all Orders
        public IEnumerable<Order> GetAllOrders(Guid restaurantId, bool trackChanges) =>
            FindAll(trackChanges)
               .OrderBy(c => c.OrderDate)
               .ToList();

        //Get a single order
        public Order GetOrder(Guid restaurantId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.RestaurantId.Equals(restaurantId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefault() ?? throw new Exception("Couldnt place");


        //Place an order
        public void CreateOrder(Guid restaurantId, Guid menuItemId, string userId,Guid dispatchDriver, Order order)
        {
            order.RestaurantId = restaurantId;
            order.MenuItemId = menuItemId;
            order.UserId = userId;
            order.DispatchDriverId = dispatchDriver;

            Create(order);
        }

        public Task<Order> GetOrdersAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrdersForUserAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
