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

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetTransportCompaniesQueryHandler : IRequestHandler<GetTransportCompaniesQuery, IEnumerable<TransportCompanyDTO>>
    {
        public GetTransportCompaniesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IRepository<TransportCompany> repository, IConfiguration configuration)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Repository = repository;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IRepository<TransportCompany> Repository { get; }
        public IConfiguration Configuration { get; }

        public async Task<IEnumerable<TransportCompanyDTO>> Handle(GetTransportCompaniesQuery request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<TransportCompanySearchRequest>.GetAnonymousObjectFromType(request.SearchRequest);

             var result = await Repository.GetTAsync(dParams, UnitOfWork.Transaction,nameof(TransportCompany).ToLower());

            var dto = Mapper.Map<IEnumerable<TransportCompanyDTO>>(result);

            return dto;
        }
    }
}
