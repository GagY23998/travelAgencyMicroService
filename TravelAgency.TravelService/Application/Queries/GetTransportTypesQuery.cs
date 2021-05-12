using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries
{
    public class GetTransportTypesQuery : IRequest<IEnumerable<TransportTypeDTO>>
    {
        public GetTransportTypesQuery(TransportTypeSearchRequest searchRequest)
        {
            SearchRequest = searchRequest;
        }
        public TransportTypeSearchRequest SearchRequest { get; }
    }
}
