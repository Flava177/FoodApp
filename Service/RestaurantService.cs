using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service
{
    internal sealed class RestaurantService : IRestaurantService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public RestaurantService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<RestaurantDto> GetAllRestaurants(bool trackChanges)
        {
            var restaurants = _repository.Restaurant.GetAllRestaurants(trackChanges);

            var restaurantsDto = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            return restaurantsDto;

        }

        public RestaurantDto GetRestaurant(Guid id, bool trackChanges)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(id, trackChanges) ?? throw new RestaurantNotFoundException(id);

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

            return restaurantDto;
        }

        public RestaurantDto CreateRestaurant(RestaurantForCreationDto restaurant)
        {
            var restaurantEntity = new Restaurant
            {
                Id = Guid.NewGuid(),
                Name = restaurant.Name,
                Email = restaurant.Email,
                PhoneNumber = restaurant.PhoneNumber,
                StartTime = restaurant.StartTime,
                EndTime = restaurant.EndTime,
                AddressId = restaurant.AddressId
            };

            _repository.Restaurant.CreateRestaurant(restaurantEntity);
            _repository.Save();

            var restaurantToReturn = new RestaurantDto(
                restaurantEntity.Id,
                restaurantEntity.Name,
                restaurantEntity.Email,
                restaurantEntity.PhoneNumber,
                restaurantEntity.StartTime,
                restaurantEntity.EndTime,
                restaurantEntity.AddressId
            );

            return restaurantToReturn;

        }








    }
}
