using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IRestaurantService
    {
        IEnumerable<RestaurantDto> GetAllRestaurants(RestaurantParameters restaurantParameters, bool trackChanges);
        RestaurantDto GetRestaurant(Guid restaurantId, bool trackChanges);

        RestaurantDto CreateRestaurant(RestaurantForCreationDto restaurant);

    }
}
