using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Application.Commands
{
    public class DeleteCityCommand : IRequest<object>
    {
        public DeleteCityCommand(object Id)
        {
            this.Id = Id;
        }

        public object Id { get; }
    }
}
