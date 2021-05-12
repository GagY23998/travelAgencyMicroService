using AutoMapper;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common.Interfaces;
using TravelAgency.TravelService.Domain.DTOs;
using TravelAgency.TravelService.Infrastructure.Helper;

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetTourQueryHandler : IRequestHandler<GetToursQuery, IEnumerable<TourDTO>>
    {
        public GetTourQueryHandler(IMapper mapper, IDbSession dbSession)
        {
            Mapper = mapper;
            DbSession = dbSession;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }

        public async Task<IEnumerable<TourDTO>> Handle(GetToursQuery request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<TourSearchRequest>.GetAnonymousObjectFromType(request.TourSearchRequest);

            var result = await DbSession.UnitOfWork.TourRepository.GetTAsync(dParams, DbSession.UnitOfWork.Transaction,nameof(Tour).ToLower());

            IEnumerable<TourDTO> dto = Mapper.Map<IEnumerable<TourDTO>>(result);

            return dto;
        }
    }
}
