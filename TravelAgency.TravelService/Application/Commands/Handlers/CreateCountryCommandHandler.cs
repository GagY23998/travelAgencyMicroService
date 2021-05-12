using AutoMapper;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;
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
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CountryDTO>
    {
        public CreateCountryCommandHandler(IMapper mapper, IDbSession dbSession, ILogger<CreateCountryCommandHandler> logger)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            DbSession = dbSession ?? throw new ArgumentNullException(nameof(dbSession));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }
        public ILogger<CreateCountryCommandHandler> Logger { get; }

        public async Task<CountryDTO> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<CountryInsertRequest>.GetAnonymousObjectFromType(request.CountryInsertRequest);

            var result = await DbSession.UnitOfWork.CountryRepository.InsertOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(Country).ToLower());

            CountryDTO dto = Mapper.Map<CountryDTO>(result);
            return dto;
        }
    }
}
