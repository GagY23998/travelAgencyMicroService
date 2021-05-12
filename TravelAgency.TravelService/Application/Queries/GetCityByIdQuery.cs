using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries
{
    public class GetCityByIdQuery : IRequest<CityDTO>
    {
        public GetCityByIdQuery(object Id)
        {
            this.Id = Id;
        }

        public object Id { get; }
    }
}
