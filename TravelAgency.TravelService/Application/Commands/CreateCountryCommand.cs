using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class CreateCountryCommand : IRequest<CountryDTO>
    {
        public CreateCountryCommand(CountryInsertRequest countryInsertRequest)
        {
            CountryInsertRequest = countryInsertRequest;
        }

        public CountryInsertRequest CountryInsertRequest { get; }
    }
}
