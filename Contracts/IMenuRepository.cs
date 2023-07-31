using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMenuRepository
    {
        IEnumerable<MenuItem> GetAllMenus (Guid restaurantId, MenuParameters menuParameters, bool trackChanges);
        MenuItem GetMenu(Guid restaurantId, Guid id, bool trackChanges);
        void CreateMenuItem(Guid restaurantId, MenuItem menuItem);

        void DeleteMenuItem(MenuItem menuItem);
    }
}
