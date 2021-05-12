using AutoMapper;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common;
using TravelAgency.TravelService.Domain.DTOs;
using TravelAgency.TravelService.Infrastructure.Helper;
using TravelAgency.TravelService.Infrastructure.Repositories;

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetTransportTypesQueryHandler : IRequestHandler<GetTransportTypesQuery, IEnumerable<TransportTypeDTO>>
    {

        public GetTransportTypesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IConfiguration Configuration { get; }

        public async Task<IEnumerable<TransportTypeDTO>> Handle(GetTransportTypesQuery request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<TransportTypeSearchRequest>.GetAnonymousObjectFromType(request.SearchRequest);

            var result = await UnitOfWork.TTypeRepository.GetTAsync(dParams,UnitOfWork.Transaction,nameof(TransportType).ToLower());

            var dto = Mapper.Map<IEnumerable<TransportTypeDTO>>(result);
            return dto;
        }
    }
}
