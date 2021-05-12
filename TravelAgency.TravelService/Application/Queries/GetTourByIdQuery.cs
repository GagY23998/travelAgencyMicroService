using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries
{
    public class GetTourByIdQuery : IRequest<TourDTO>
    {
        public GetTourByIdQuery(object id)
        {
            Id = id;
        }

        public object Id { get; }
    }
}
