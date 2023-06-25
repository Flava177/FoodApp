using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service
{
    internal sealed class OrderService : IOrderService
    { 
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public OrderService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) 
        { 
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<OrderDto> GetAllOrders(Guid restaurantId, bool trackChanges)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges) ?? throw new RestaurantNotFoundException(restaurantId);

            var orders = _repository.Order.GetAllOrders(restaurantId, trackChanges);

            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return ordersDto;

        }

        public OrderDto GetOrder(Guid restaurantId, Guid id, bool trackChanges)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges) ?? throw new RestaurantNotFoundException(restaurantId);

            var order = _repository.Order.GetOrder(restaurantId, id, trackChanges);
            if (order is null)
                throw new OrderNotFoundException(id);

            var orderDto = _mapper.Map<OrderDto>(order);

            return orderDto;
        }

        //public OrderDto CreateOrderForMenu(Guid restaurantId, string userId, int orderStatusId, Guid dispatchDriverId, OrderForCreationDto orderForCreationDto, bool trackChanges)
        //{
        //    var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges)
        //    ?? throw new RestaurantNotFoundException(restaurantId);

        //   var orderEntity = new Order
        //   {
        //       RestaurantId = restaurantId,
        //       UserId = userId,
        //       OrderStatusId = orderStatusId,
        //       DispatchDriverId = dispatchDriverId,
        //       OrderDate = orderForCreationDto.OrderDate,
        //       RequestedDeliveryTime = orderForCreationDto.RequestedDeliveryTime,
        //       TotalAmount = orderForCreationDto.TotalAmount,
        //       RestaurantRating = orderForCreationDto.RestaurantRating

        //   };

        //    _repository.Order.CreateOrderForMenu(restaurantId, userId, orderStatusId, dispatchDriverId, orderEntity);
        //    _repository.Save();

        //    var orderToReturn = new OrderDto(
        //      orderEntity.Id,
        //      orderEntity.OrderDate,
        //      orderEntity.RequestedDeliveryTime,
        //      orderEntity.TotalAmount,
        //      (int)orderEntity.RestaurantRating
        //  );

        //    return orderToReturn;
        //}
    }
}
