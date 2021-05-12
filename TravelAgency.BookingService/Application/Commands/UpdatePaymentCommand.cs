using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.DTOs;

namespace TravelAgency.BookingService.Application.Commands
{
    public class UpdatePaymentCommand : IRequest<PaymentDTO>
    {
        public Guid Id { get; set; }
        public PaymentCreateRequest Request{get;set;}
        public UpdatePaymentCommand(Guid Id,PaymentCreateRequest payment)
        {
            this.Id = Id;
            this.Request = payment;
        }
    }
}
