using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using AutoMapper;
    using Contracts;
    using Entities.Models;
    using global::Contracts;
    using Shared.DataTransferObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Service
    {
        internal sealed class StatusService : IStatusService
        {
            private readonly IRepositoryManager _repository;
            private readonly ILoggerManager _logger;
            private readonly IMapper _mapper;
            public StatusService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
            {
                _repository = repository;
                _logger = logger;
                _mapper = mapper;
            }

            public IEnumerable<OrderStatusDto> GetAllStatuses(bool trackChanges)
            {

                var statuses = _repository.StatusValue.GetAllStatuses(trackChanges);

                var statusDto = _mapper.Map<IEnumerable<OrderStatus>>(statuses);

                return (IEnumerable<OrderStatusDto>)statusDto;

            }

            public OrderStatusDto GetStatus(int id, bool trackChanges)
            {
                var status = _repository.StatusValue.GetStatus(id, trackChanges);

                var statusDto = _mapper.Map<OrderStatusDto>(status);

                return statusDto;

            }

          
        }
    }

}
