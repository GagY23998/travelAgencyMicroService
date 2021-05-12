using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class UpdateCityCommand : IRequest<CityDTO>
    {
        public UpdateCityCommand(object id, CityInsertRequest request)
        {
            Id = id;
            Request = request;
        }

        public object Id { get; }
        public CityInsertRequest Request { get; }
    }
}
