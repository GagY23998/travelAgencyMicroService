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
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, CountryDTO>
    {
        public UpdateCountryCommandHandler(IMapper mapper, IDbSession dbSession)
        {
            Mapper = mapper;
            DbSession = dbSession;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }

        public async Task<CountryDTO> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<CountryInsertRequest>.UpdateAnonymouseObjectFromType(request.Id, request.CountryInsertRequest);

            var result = await DbSession.UnitOfWork.CountryRepository.UpdateOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(Country).ToLower());

            CountryDTO dto = Mapper.Map<CountryDTO>(result);

            return dto;
        }
    }
}
