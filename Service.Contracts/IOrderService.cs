using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAllOrders(Guid restaurantId, bool trackChanges);
        OrderDto GetOrder(Guid restaurantId, Guid id, bool trackChanges);
        OrderDto OrderForCreation(Guid restaurantId, Guid menuItemId, string userId, Guid dispatchDriver, OrderForCreationDto orderForCreation, bool trackChanges);

    }
}
