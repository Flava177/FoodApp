using FoodDelivery.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FoodDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AddressesController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetAddresses()
        {

            var addresses = _service.AddressService.GetAllAddresses(trackChanges: false);
            return Ok(addresses);
        }

        
        [HttpGet("{id:guid}", Name = "AddressById")]
        public IActionResult GetAddress(Guid id)
        {
            var address = _service.AddressService.GetAddress(id, trackChanges: false);
            return Ok(address);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateAddress([FromBody] AddressForCreationDto address)
        {
          
            var createdAddress = _service.AddressService.CreateAddress(address);

            return CreatedAtRoute("AddressById", new { id = createdAddress.Id },
                createdAddress);
        }
    }
}
