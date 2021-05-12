using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class UpdateTransportReviewCommand : IRequest<TransportReviewDTO>
    {
        public UpdateTransportReviewCommand(int id, TransportReviewInsertRequest transportReviewInsertRequest)
        {
            Id = id;
            TransportReviewInsertRequest = transportReviewInsertRequest;
        }

        public int Id { get; }
        public TransportReviewInsertRequest TransportReviewInsertRequest { get; }
    }
}
