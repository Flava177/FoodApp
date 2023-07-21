using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMenuService
    {
        IEnumerable<MenuItemDto> GetAllMenu(Guid restaurantId,MenuParameters menuParameters ,bool trackChanges);
        MenuItemDto GetMenu(Guid restaurantId, Guid id, bool trackChanges);
        MenuItemDto MenuItemForCreation(Guid restaurantId, MenuItemForCreationDto menuItemForCreation, bool trackChanges);
        void DeleteMenuForRestaurant(Guid restaurantId, Guid id, bool trackChanges);
        void UpdateMenuForRestaurant(Guid restaurantId, Guid id, MenuForUpdateDto menuForUpdate, bool trackChanges);
    }
}
