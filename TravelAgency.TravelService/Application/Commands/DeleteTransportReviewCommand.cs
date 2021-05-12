using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class DeleteTransportReviewCommand : IRequest<int>
    {
        public DeleteTransportReviewCommand(int Id)
        {
            this.Id = Id;
        }

        public object Id { get; }
    }
}
