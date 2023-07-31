using FoodDelivery.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace FoodDelivery.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public RestaurantsController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetRestaurants([FromQuery] RestaurantParameters restaurantParameters)
        {
            var restaurants = _service.RestaurantService.GetAllRestaurants(restaurantParameters,trackChanges: false);
            return Ok(restaurants);

        }


        [HttpGet("{id:guid}", Name = "RestaurantById")]
        public IActionResult GetRestaurant(Guid id)
        {
            var restaurant = _service.RestaurantService.GetRestaurant(id, trackChanges: false);
            return Ok(restaurant);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateRestaurant([FromBody] RestaurantForCreationDto restaurant)
        { 
            var createdRestaurant = _service.RestaurantService.CreateRestaurant(restaurant);

            return CreatedAtRoute("RestaurantById", new { id = createdRestaurant.Id }, createdRestaurant);
        }
    }
}
