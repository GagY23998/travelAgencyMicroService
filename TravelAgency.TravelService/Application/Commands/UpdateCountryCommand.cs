using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class UpdateCountryCommand : IRequest<CountryDTO>
    {
        public UpdateCountryCommand(int id, CountryInsertRequest countryInsertRequest)
        {
            Id = id;
            CountryInsertRequest = countryInsertRequest;
        }

        public int Id { get; }
        public CountryInsertRequest CountryInsertRequest { get; }
    }
}
