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
    public class GetAttractionsQueryHandler : IRequestHandler<GetAttractionsQuery, IEnumerable<AttractionDTO>>
    {
        public GetAttractionsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IConfiguration Configuration { get; }

        public async Task<IEnumerable<AttractionDTO>> Handle(GetAttractionsQuery request, CancellationToken cancellationToken)
        {

            DynamicParameters dParams = DynamicParamConverter<AttractionSearchRequest>.GetAnonymousObjectFromType(request.SearchRequest);

            var result = await UnitOfWork.AttrRepository.GetTByIdAsync(dParams,UnitOfWork.Transaction,nameof(Attraction).ToLower());

         
            var dto = Mapper.Map<IEnumerable<AttractionDTO>>(result);

            return dto;
        }
    }
}
