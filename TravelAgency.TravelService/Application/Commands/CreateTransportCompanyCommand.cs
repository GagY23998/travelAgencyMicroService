using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class CreateTransportCompanyCommand : IRequest<TransportCompanyDTO>
    {
        public CreateTransportCompanyCommand(TransportCompanyInsertRequest insertRequest)
        {
            InsertRequest = insertRequest;
        }

        public TransportCompanyInsertRequest InsertRequest { get; }
    }
}
