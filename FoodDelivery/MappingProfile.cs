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
            CreateMap<Address, AddressDto>()
                .ForMember(c => c.City,
                opt =>
                opt.MapFrom(x => x.City));
        }
    }
}
