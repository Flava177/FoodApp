using Entities.Models;
using FoodDelivery.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace FoodDelivery.Controllers
{

    [Authorize]
    [Route("api/restaurants/{restaurantId}/menus")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IServiceManager _service;
        public MenusController(IServiceManager service) => _service = service;


        //Get All Menus
        [HttpGet]
        public IActionResult GetMenus(Guid restaurantId, [FromQuery] MenuParameters menuParameters)
        {

            var menus = _service.MenuService.GetAllMenu(restaurantId, menuParameters, trackChanges: false);
            return Ok(menus);
        }


        //Get A Menu
        [HttpGet("{id:guid}", Name = "MenuById")]
        public IActionResult GetMenu(Guid restaurantId, Guid id)
        {
            var menu = _service.MenuService.GetMenu(restaurantId, id, trackChanges: false);
            return Ok(menu);
        }


        //Add a MenuItem
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateMenuForRestaurant(Guid restaurantId, [FromBody] MenuItemForCreationDto menuItem)
        {

            var menuToReturn = _service.MenuService.MenuItemForCreation(restaurantId, menuItem, trackChanges: false);

            return CreatedAtRoute("MenuById", 
                new { restaurantId, id = menuToReturn.Id },
                menuToReturn);
        }

        //Delete a Menu
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult DeleteMenuForRestaurant( Guid restaurantId, Guid id)
        {
            _service.MenuService.DeleteMenuForRestaurant(restaurantId, id, trackChanges:false);

            var response = new
            {
                message = "Deleted successfully"
            };

            return Ok(response);
        }


        //Update a Menu
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult UpdateMenuForRestaurant(Guid restaurantId, Guid id, [FromBody] MenuForUpdateDto menuForUpdate)
        {

            _service.MenuService.UpdateMenuForRestaurant(restaurantId, id, menuForUpdate, trackChanges: true);

            return Ok(menuForUpdate);
        }
    }
}
