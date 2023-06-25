using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FoodDelivery
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<DispatchDriver, DispatchDriverDto>();
            CreateMap<DispatchDriver, DispatchDriverDto>();
            CreateMap<MenuItem, MenuDto>();
            CreateMap<User, UserDto>();
            CreateMap<Order, OrderDto>();
        }
    }
}
