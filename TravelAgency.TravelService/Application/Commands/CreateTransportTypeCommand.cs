using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class CreateTransportTypeCommand : IRequest<TransportTypeDTO>
    {
        public CreateTransportTypeCommand(TransportTypeInsertRequest insertRequest)
        {
            InsertRequest = insertRequest;
        }

        public TransportTypeInsertRequest InsertRequest { get; }
    }
}
