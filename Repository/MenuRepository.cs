using Contracts;
using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Extensions;

namespace Repository
{
    internal sealed class MenuRepository : RepositoryBase<MenuItem>, IMenuRepository
    {
        public MenuRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public IEnumerable<MenuItem> GetAllMenus(Guid restaurantId,MenuParameters menuParameters ,bool trackChanges) 
            => FindByCondition(e => e.RestaurantId.Equals(restaurantId), trackChanges)
            .Search(menuParameters.SearchTerm)
            .OrderBy(m => m.Name)
            .Skip((menuParameters.PageNumber - 1) * menuParameters.PageSize)
            .Take(menuParameters.PageSize)
            .ToList();


        public MenuItem GetMenu(Guid restaurantId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.RestaurantId.Equals(restaurantId) && e.Id.Equals(id), trackChanges).SingleOrDefault();


        public void CreateMenuItem(Guid restaurantId, MenuItem menuItem) 
        {
            menuItem.RestaurantId = restaurantId;

            Create(menuItem);
        }

        public void DeleteMenuItem(MenuItem menuItem)
        {
            Delete(menuItem);
        }

    }
}
