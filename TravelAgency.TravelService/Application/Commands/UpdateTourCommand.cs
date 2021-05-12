using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class UpdateTourCommand : IRequest<TourDTO>
    {
        public UpdateTourCommand(object Id, TourInsertRequest insertRequest)
        {
            this.Id = Id;
            InsertRequest = insertRequest;
        }

        public object Id { get; }
        public TourInsertRequest InsertRequest { get; }
    }
}
