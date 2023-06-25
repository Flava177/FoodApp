﻿using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class AddressService : IAddressService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public AddressService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public IEnumerable<AddressDto> GetAllAddresses(bool trackChanges)
        {

            var addresses = _repository.Address.GetAllAddresses(trackChanges);

            var addressesDto = addresses.Select(c =>

            new AddressDto(c.Id, c.Street, c.Area, c.City)).ToList();

            return addressesDto;

        }

        public AddressDto GetAddress(Guid id, bool trackChanges)
        {
            var address = _repository.Address.GetAddress(id, trackChanges);

            var addressDto = new AddressDto(
                id,
                address.Street,
                address.Area,
                address.City
            );

            return addressDto;
        }


        public AddressDto CreateAddress(AddressForCreationDto address)
        {
            var addressEntity = new Address
            {
                Id = Guid.NewGuid(),
                Street = address.Street,
                Area = address.Area,
                City = address.City
            };

            _repository.Address.CreateAddress(addressEntity);

            _repository.Save();

            var addressDto = new AddressDto(
                addressEntity.Id,
                addressEntity.Street,
                addressEntity.Area,
                addressEntity.City
            );

            return addressDto;
        }
    }
}
