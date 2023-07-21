using Contracts;
using Entities.Models;
using Repository.Extensions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    internal sealed class RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public IEnumerable<Restaurant> GetAllRestaurants(RestaurantParameters restaurantParameters, bool trackChanges) =>
            FindAll(trackChanges)
            .Search(restaurantParameters.SearchTerm)
               .OrderBy(c => c.Name)
               .ToList();


        public Restaurant GetRestaurant(Guid companyId, bool trackChanges)
            => FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();


        public void CreateRestaurant(Restaurant restaurant) => Create(restaurant);
    }
}
