using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record OrderForCreationDto(DateTime OrderDate, int? Quantity, DateTime RequestedDeliveryTime, decimal TotalAmount);

}
