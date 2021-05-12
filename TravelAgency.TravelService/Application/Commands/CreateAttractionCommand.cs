using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Commands
{
    public class CreateAttractionCommand : IRequest<AttractionDTO>
    {
        public CreateAttractionCommand(AttractionInsertRequest insertRequest)
        {
            InsertRequest = insertRequest;
        }

        public AttractionInsertRequest InsertRequest { get; }
    }
}
