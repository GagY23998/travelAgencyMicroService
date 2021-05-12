using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class CreateCityCommand : IRequest<CityDTO>
    {

        public CreateCityCommand(CityInsertRequest insertRequest)
        {
            InsertRequest = insertRequest;
        }
        public CityInsertRequest InsertRequest { get; }
    }
}
