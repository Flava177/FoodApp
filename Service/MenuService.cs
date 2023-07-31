using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class MenuService : IMenuService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public MenuService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        //Get All Menus
        public IEnumerable<MenuItemDto> GetAllMenu(Guid restaurantId,MenuParameters menuParameters ,bool trackChanges)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges) ?? throw new RestaurantNotFoundException(restaurantId);
            var menuFromDb = _repository.Menu.GetAllMenus(restaurantId,menuParameters ,trackChanges);

            var menuDto = _mapper.Map<IEnumerable<MenuItemDto>>(menuFromDb);

            return menuDto;

        }

        //Get Single MenuItem
        public MenuItemDto GetMenu(Guid restaurantId, Guid id, bool trackChanges)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges);
            if (restaurant is null) throw new RestaurantNotFoundException(restaurantId);

            var menuDb = _repository.Menu.GetMenu(restaurantId, id, trackChanges);
            if  (menuDb is null) throw new MenuNotFoundException(id);

            var menu = new MenuItemDto(
                Id: menuDb.Id,
                Name: menuDb.Name,
                Description: menuDb.Description,
                Price: menuDb.Price
            );
            return menu;
        }

        //Create MenuItem
        public MenuItemDto MenuItemForCreation(Guid restaurantId, MenuItemForCreationDto menuItemForCreation, bool trackChanges)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges) ?? throw new RestaurantNotFoundException(restaurantId);

            var menuEntity = _mapper.Map<MenuItem>(menuItemForCreation);

            _repository.Menu.CreateMenuItem(restaurantId, menuEntity);
            _repository.Save();

            var menuToReturn = _mapper.Map<MenuItemDto>(menuEntity);

            return menuToReturn;
        }

        //Delete MenuItem 
        public void DeleteMenuForRestaurant(Guid restaurantId, Guid id, bool trackChanges) 
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges) ?? throw new RestaurantNotFoundException(restaurantId);

            var menuForRestaurant = _repository.Menu.GetMenu(restaurantId, id, trackChanges) ?? throw new MenuNotFoundException(id);

            _repository.Menu.DeleteMenuItem(menuForRestaurant);
            _repository.Save();
        }


        //Update MenuItem
        public void UpdateMenuForRestaurant(Guid restaurantId, Guid id, MenuForUpdateDto menuForUpdate , bool trackChanges)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges) ?? throw new RestaurantNotFoundException(restaurantId);

            var menuForRestaurant = _repository.Menu.GetMenu(restaurantId, id, trackChanges) ?? throw new MenuNotFoundException(id);

            _mapper.Map(menuForUpdate, menuForRestaurant);
            _repository.Save();
        }

      
    }
}
