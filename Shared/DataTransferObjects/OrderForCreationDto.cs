using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record OrderForCreationDto(DateTime OrderDate, DateTime RequestedDeliveryTime, decimal TotalAmount);

}
