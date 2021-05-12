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

namespace TravelAgency.TravelService.Application.Commands.Handlers
{
    public class UpdateTourCommandHandler : IRequestHandler<UpdateTourCommand, TourDTO>
    {
        public UpdateTourCommandHandler(IMapper mapper, IDbSession dbSession)
        {
            Mapper = mapper;
            DbSession = dbSession;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }

        public async Task<TourDTO> Handle(UpdateTourCommand request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<TourInsertRequest>.UpdateAnonymouseObjectFromType(request.Id, request.InsertRequest);

            var result = await DbSession.UnitOfWork.TourRepository.UpdateOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(Tour).ToLower());


            var dto = Mapper.Map<TourDTO>(result);

            return dto;

        }
    }
}
