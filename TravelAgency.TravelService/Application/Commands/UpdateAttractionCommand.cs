using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class UpdateAttractionCommand : IRequest<AttractionDTO>
    {
        public UpdateAttractionCommand(object Id, AttractionInsertRequest attractionInsertRequest)
        {
            this.Id = Id;
            AttractionInsertRequest = attractionInsertRequest;
        }

        public object Id { get; }
        public AttractionInsertRequest AttractionInsertRequest { get; }
    }
}
