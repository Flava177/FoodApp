using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures;

namespace FoodDelivery.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/{v:apiversion}/restaurants")]
    [ApiController]
    public class RestaurantsV2Controller : ControllerBase
    {
        private readonly IServiceManager _service;
        public RestaurantsV2Controller(IServiceManager service) => _service = service;

        [HttpGet]
        public  IActionResult GetRestaurants([FromQuery] RestaurantParameters restaurantParameters)
        {
            var restaurants = _service.RestaurantService.GetAllRestaurants(restaurantParameters, trackChanges: false);

            var restaurants2 = restaurants.Select(s => $"{s.Name} V2");

            return Ok(restaurants);
        }
    }
}
