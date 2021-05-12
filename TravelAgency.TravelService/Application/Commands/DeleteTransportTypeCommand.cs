using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class DeleteTransportTypeCommand : IRequest<TransportTypeDTO>
    {
        public DeleteTransportTypeCommand(object id)
        {
            Id = id;
        }

        public object Id { get; }
    }
}
