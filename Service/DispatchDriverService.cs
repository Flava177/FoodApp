using AutoMapper;
using Contracts;
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
    internal sealed class DispatchDriverService : IDispatchDriverService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public DispatchDriverService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<DispatchDriverDto> GetAllDrivers(bool trackChanges)
        {

            var drivers = _repository.DispatchDriver.GetAllDrivers(trackChanges);

            var driversDto = _mapper.Map<IEnumerable<DispatchDriverDto>>(drivers);

            return driversDto;

        }

        public DispatchDriverDto GetDriver(Guid id, bool trackChanges)
        {
            var driver = _repository.DispatchDriver.GetDriver(id, trackChanges);

            var driverDto = _mapper.Map<DispatchDriverDto>(driver);

            return driverDto;
        }


        public DispatchDriverDto CreateDriver(DispatchDriverForCreationDto dispatchDriver)
        {
            var dispatchDriverEntity = _mapper.Map<DispatchDriver>(dispatchDriver);

            _repository.DispatchDriver.CreateDriver(dispatchDriverEntity);
            _repository.Save();

            var dispatchDriverDto = _mapper.Map<DispatchDriverDto>(dispatchDriverEntity) ;
            return dispatchDriverDto;
        }
    }
}
