using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record OrderDto(Guid Id, DateTime OrderDate, DateTime RequestedDeliveryTime, decimal TotalAmount);
    //{

    //    public DispatchDriverDto DispatchDriver { get; init; }
    //    public UserDto User { get; init; }
    //    public OrderStatusDto orderstatus { get; init; }
    //}
}
