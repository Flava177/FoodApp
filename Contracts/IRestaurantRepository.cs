using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAllRestaurants(RestaurantParameters restaurantParameters, bool trackChanges);
        Restaurant GetRestaurant(Guid restaurantId, bool trackChanges);

        void CreateRestaurant(Restaurant restaurant);
    }
}
