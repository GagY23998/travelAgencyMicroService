using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class CreateTourCommand : IRequest<TourDTO>
    {
        public CreateTourCommand(TourInsertRequest insertRequest)
        {
            InsertRequest = insertRequest;
        }

        public TourInsertRequest InsertRequest { get; }
    }
}
