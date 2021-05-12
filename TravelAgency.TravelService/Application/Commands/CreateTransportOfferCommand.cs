using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class CreateTransportOfferCommand :IRequest<TransportOfferDTO>
    {
        public CreateTransportOfferCommand(TransportOfferInsertRequest sqlParameters)
        {
            SqlParameters = sqlParameters;
        }

        public TransportOfferInsertRequest SqlParameters { get; }
    }
}
