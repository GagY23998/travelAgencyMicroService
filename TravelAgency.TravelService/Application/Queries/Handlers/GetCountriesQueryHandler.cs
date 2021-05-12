using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Infrastructure.Helper;
using TravelAgency.TravelService.Domain.Common.Interfaces;
using TravelAgency.TravelService.Domain.DTOs;
using TravelAgency.TravelService.Domain;

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IEnumerable<CountryDTO>>
    {
        public GetCountriesQueryHandler(IMapper mapper, IDbSession session, ILogger<GetCountriesQueryHandler> logger)
        {
            Mapper = mapper;
            Session = session;
            Logger = logger;
        }

        public IMapper Mapper { get; }
        public IDbSession Session { get; }
        public ILogger<GetCountriesQueryHandler> Logger { get; }

        public async Task<IEnumerable<CountryDTO>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Converting parameters for query, time: {0}", DateTime.Now);

            DynamicParameters dParams = DynamicParamConverter<CountrySearchRequest>.GetAnonymousObjectFromType(request.CountrySearchRequest);

            Logger.LogInformation("Retrieving data on countries, time: {0}", DateTime.Now);

            var countries = await Session.UnitOfWork.CountryRepository.GetTAsync(dParams,Session.UnitOfWork.Transaction,nameof(Country).ToLower());

            IEnumerable<CountryDTO> result = Mapper.Map<IEnumerable<CountryDTO>>(countries);
            Logger.LogInformation("Got result count: {0}", result.Count());

            return result;
        }
    }
}
