using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries
{
    public class GetTransportCompaniesQuery : IRequest<IEnumerable<TransportCompanyDTO>>
    {
        public TransportCompanySearchRequest SearchRequest { get; }

        public GetTransportCompaniesQuery(TransportCompanySearchRequest searchRequest)
        {
            SearchRequest = searchRequest;
        }
    }
}
