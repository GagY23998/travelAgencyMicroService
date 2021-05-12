using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class UpdateTransportOfferCommand : IRequest<TransportOfferDTO>
    {
        public UpdateTransportOfferCommand(object id, TransportOfferInsertRequest sqlParameters)
        {
            Id = id;
            SqlParameters = sqlParameters;
        }

        public object Id { get; }
        public TransportOfferInsertRequest SqlParameters { get; }
    }
}
