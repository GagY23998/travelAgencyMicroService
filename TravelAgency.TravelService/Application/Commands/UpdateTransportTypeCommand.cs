using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands.Handlers
{
    public class UpdateTransportTypeCommand : IRequest<TransportTypeDTO>
    {
        public UpdateTransportTypeCommand(object id, TransportTypeInsertRequest transportTypeInsertRequest)
        {
            Id = id;
            TransportTypeInsertRequest = transportTypeInsertRequest;
        }

        public object Id { get; }
        public TransportTypeInsertRequest TransportTypeInsertRequest { get; }
    }
}
