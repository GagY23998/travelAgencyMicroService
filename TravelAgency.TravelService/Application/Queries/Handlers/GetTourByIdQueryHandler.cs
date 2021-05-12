using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common.Interfaces;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetTourByIdQueryHandler : IRequestHandler<GetTourByIdQuery, TourDTO>
    {
        public GetTourByIdQueryHandler(IMapper mapper, IDbSession dbSession)
        {
            Mapper = mapper;
            DbSession = dbSession;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }

        public async Task<TourDTO> Handle(GetTourByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await DbSession.UnitOfWork.TourRepository.GetTByIdAsync(request.Id, DbSession.UnitOfWork.Transaction,nameof(Tour).ToLower());

            TourDTO dto = Mapper.Map<TourDTO>(result);

            return dto;
        }
    }
}
