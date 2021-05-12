using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.DTOs;

namespace TravelAgency.BookingService.Application.Commands
{
    public class CreatePaymentCommand : IRequest<bool>
    {
        public PaymentCreateRequest Request { get; }
        public CreatePaymentCommand(PaymentCreateRequest request)
        {
            Request = request;
        }

    }
}
