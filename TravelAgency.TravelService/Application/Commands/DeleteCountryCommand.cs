using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Application.Commands
{
    public class DeleteCountryCommand : IRequest<object>
    {
        public DeleteCountryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
