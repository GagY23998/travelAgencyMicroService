using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class UpdateTransportCompanyCommand : IRequest<TransportCompanyDTO>
    {
        public UpdateTransportCompanyCommand(object id, TransportCompanyInsertRequest insertRequest)
        {
            Id = id;
            InsertRequest = insertRequest;
        }

        public object Id { get; }
        public TransportCompanyInsertRequest InsertRequest { get; }
    }
}
