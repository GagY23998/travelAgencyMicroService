using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries
{
    public class GetTransportReviewByIdQuery : IRequest<TransportReviewDTO>
    {
        public GetTransportReviewByIdQuery(int Id)
        {
            this.Id = Id;
        }

        public int Id { get; }
    }
}
