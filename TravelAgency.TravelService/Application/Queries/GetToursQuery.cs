using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries
{
    public class GetToursQuery : IRequest<IEnumerable<TourDTO>>
    {
        public GetToursQuery(TourSearchRequest tourSearchRequest)
        {
            TourSearchRequest = tourSearchRequest;
        }

        public TourSearchRequest TourSearchRequest { get; }
    }
}
