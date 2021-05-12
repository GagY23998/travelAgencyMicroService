using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetAttractionByIdQuery : IRequest<AttractionDTO>
    {
        public GetAttractionByIdQuery(object Id)
        {
            this.Id = Id;
        }

        public object Id { get; }
    }
}
