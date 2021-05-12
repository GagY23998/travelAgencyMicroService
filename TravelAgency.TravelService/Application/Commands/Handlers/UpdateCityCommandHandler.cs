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
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, CityDTO>
    {
        public UpdateCityCommandHandler(IMapper mapper, IDbSession dbSession)
        {
            Mapper = mapper;
            DbSession = dbSession;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }

        public async Task<CityDTO> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<CityInsertRequest>.UpdateAnonymouseObjectFromType(request.Id, request.Request);

            var result = await DbSession.UnitOfWork.CityRepository.UpdateOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(City).ToLower());

            CityDTO dto = Mapper.Map<CityDTO>(result);

            return dto;
        }
    }
}
