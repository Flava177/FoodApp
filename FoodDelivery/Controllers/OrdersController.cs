using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FoodDelivery.Controllers
{
    [Authorize]
    [Route("api/restaurants/{restaurantId}/menus/{menuId}/orders")]
    //[Route("api/[Controller]/action")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IServiceManager _service;
        public OrdersController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetOrders()
        {

            var orders = _service.OrderService.GetAllOrders(trackChanges: false);
            return Ok(orders);

        }


        [HttpGet("{id:guid}", Name = "OrderById")]
        public IActionResult GetOrder(Guid id)
        {
            var order = _service.OrderService.GetOrder(id, trackChanges: false);
            return Ok(order);
        }


        

    }
}
