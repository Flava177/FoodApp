using AutoMapper;
using Contracts;
using Entities.Exceptions;
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
        private readonly IMapper _mapper;
        public AddressService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
       
        public IEnumerable<AddressDto> GetAllAddresses(bool trackChanges)
        {

            var addresses = _repository.Address.GetAllAddresses(trackChanges);

            var addressesDto = _mapper.Map<IEnumerable<AddressDto>>(addresses);

            return addressesDto;

        }

        public AddressDto GetAddress(Guid id, bool trackChanges)
        {
            var address = _repository.Address.GetAddress(id, trackChanges) ?? throw new AddressNotFoundException(id);
            var addressDto = _mapper.Map<AddressDto>(address);

            return addressDto;
        }


        public AddressDto CreateAddress(AddressForCreationDto address)
        {
            var addressEntity = _mapper.Map<Address>(address);

            _repository.Address.CreateAddress(addressEntity);

            _repository.Save();

            var addressToReturn = _mapper.Map<AddressDto>(addressEntity);

            return addressToReturn;
        }
    }
}
