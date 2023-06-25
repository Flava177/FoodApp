using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FoodDelivery.Controllers
{
    //[Authorize]
    [Route("api/restaurants/{restaurantId}/menus/{menuId}/orders")]
    //[Route("api/[Controller]/action")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IServiceManager _service;
        public OrdersController(IServiceManager service) => _service = service;


        //Get All Orders in a Restaurant
        [HttpGet]
        public IActionResult GetOrders(Guid restaurantId)
        {
            var orders = _service.OrderService.GetAllOrders(restaurantId, trackChanges: false);
            return Ok(orders);
        }


        //Get An Order in a Restaurant
        [HttpGet("{id:guid}", Name = "OrderById")]
        public IActionResult GetOrder(Guid restaurantId, Guid id)
        {
            var order = _service.OrderService.GetOrder(restaurantId, id, trackChanges: false);
            return Ok(order);
        }


        

    }
}
