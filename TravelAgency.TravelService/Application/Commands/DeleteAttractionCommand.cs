using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Application.Commands
{
    public class DeleteAttractionCommand : IRequest<object>
    {
        public DeleteAttractionCommand(object id)
        {
            Id = id;
        }

        public object Id { get; }
    }
}
