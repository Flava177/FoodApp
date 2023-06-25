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

            var order = _repository.Order.GetOrder(restaurantId, id, trackChanges) ?? throw new OrderNotFoundException(id);
            var orderDto = _mapper.Map<OrderDto>(order);

            return orderDto;
        }

        public OrderDto OrderForCreation(Guid restaurantId, Guid menuItemId, int userId, int orderStatusId, Guid dispatchDriver, OrderForCreationDto orderForCreation, bool trackChanges)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges) ?? throw new RestaurantNotFoundException(restaurantId);

            var menuItem = _repository.Menu.GetMenu(restaurantId, menuItemId, trackChanges) ?? throw new MenuNotFoundException(menuItemId);

            var dispatch = _repository.DispatchDriver.GetDriver(dispatchDriver, trackChanges) ?? throw new MenuNotFoundException(menuItemId);

            var getUserId = _repository.User.GetUser(userId, trackChanges);
          

            var status = _repository.StatusValue.GetStatus(orderStatusId, trackChanges) ?? throw new Exception("Order Status Unknown..Please wait");

            var orderEntity = _mapper.Map<Order>(orderForCreation);

            

            _repository.Order.CreateOrder(restaurantId, menuItemId, userId, orderStatusId, dispatchDriver, orderEntity);
            _repository.Save();

            var orderToReturn = _mapper.Map<OrderDto>(orderEntity);
            return orderToReturn;

        }
    }
}
