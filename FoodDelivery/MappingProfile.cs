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
            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<User, UserDto>();
            CreateMap<Order, OrderDto>();

            //Creation DTO's
            CreateMap<OrderForCreationDto, Order>();
            CreateMap<AddressForCreationDto, Address>();
            CreateMap<DispatchDriverForCreationDto, DispatchDriver>();
            CreateMap<RestaurantForCreationDto, Restaurant>();
            CreateMap<MenuItemForCreationDto, MenuItem>();
            CreateMap<UserForRegistrationDto, User>();

            //Update DTO's
            CreateMap<MenuForUpdateDto, MenuItem>();
        }
    }
}
