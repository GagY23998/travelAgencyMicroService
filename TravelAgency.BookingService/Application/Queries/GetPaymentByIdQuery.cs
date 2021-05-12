using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.DTOs;

namespace TravelAgency.BookingService.Application.Queries
{
    public class GetPaymentByIdQuery : IRequest<PaymentDTO>
    {
        public Guid Id { get; set; }
        public GetPaymentByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
