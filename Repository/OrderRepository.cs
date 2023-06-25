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
            .SingleOrDefault();


        //Place an order
        public void CreateOrderForMenu(Guid restaurantId, string userId, int orderStatusId, Guid dispatchDriverId, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
