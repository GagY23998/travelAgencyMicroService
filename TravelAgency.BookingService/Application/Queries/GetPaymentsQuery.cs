using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.DTOs;

namespace TravelAgency.BookingService.Application.Queries
{
    public class GetPaymentsQuery : IRequest<IEnumerable<PaymentDTO>>
    {
        public PaymentSearchRequest SearchRequest { get; set; }
        public GetPaymentsQuery(PaymentSearchRequest searchRequest)
        {
            SearchRequest = searchRequest;
        }
    }
}
