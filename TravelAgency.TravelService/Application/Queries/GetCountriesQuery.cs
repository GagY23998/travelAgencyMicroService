using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries
{
    public class GetCountriesQuery : IRequest<IEnumerable<CountryDTO>>
    {
        public GetCountriesQuery(CountrySearchRequest countrySearchRequest)
        {
            CountrySearchRequest = countrySearchRequest;
        }

        public CountrySearchRequest CountrySearchRequest { get; }
    }
}
