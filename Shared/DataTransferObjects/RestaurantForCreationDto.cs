using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record RestaurantForCreationDto(string Name, string Email, string PhoneNumber, string StartTime, string EndTime, Guid AddressId,
        IEnumerable<MenuItemForCreationDto> MenuItems);
}
