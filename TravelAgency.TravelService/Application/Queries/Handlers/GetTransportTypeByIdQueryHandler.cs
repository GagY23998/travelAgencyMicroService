using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetTransportTypeByIdQueryHandler : IRequestHandler<GetTransportTypeByIdQuery, TransportTypeDTO>
    {
        public GetTransportTypeByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IConfiguration Configuration { get; }

        public async Task<TransportTypeDTO> Handle(GetTransportTypeByIdQuery request, CancellationToken cancellationToken)
        {
            UnitOfWork.BeginTransaction();
            var result = await UnitOfWork.TTypeRepository.GetTByIdAsync(request.Id,UnitOfWork.Transaction,nameof(TransportType).ToLower());
            UnitOfWork.CommitTransaction();
            var dto = Mapper.Map<TransportTypeDTO>(result);

            return dto;
        }
    }
}
