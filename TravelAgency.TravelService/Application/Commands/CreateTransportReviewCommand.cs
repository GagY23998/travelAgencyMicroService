using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class CreateTransportReviewCommand : IRequest<TransportReviewDTO>
    {
        public CreateTransportReviewCommand(TransportReviewInsertRequest transportReviewInsertRequest)
        {
            TransportReviewInsertRequest = transportReviewInsertRequest;
        }

        public TransportReviewInsertRequest TransportReviewInsertRequest { get; }
    }
}
