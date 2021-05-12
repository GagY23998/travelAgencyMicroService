using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.DTOs;
using TravelAgency.BookingService.Domain.Repositories;

namespace TravelAgency.BookingService.Application.Commands
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, PaymentDTO>
    {
        private readonly IMediator mediator;
        private readonly IPaymentRepository paymentRepository;

        public UpdatePaymentCommandHandler(IMediator mediator,IPaymentRepository paymentRepository)
        {
            this.mediator = mediator;
            this.paymentRepository = paymentRepository;
        }
        public Task<PaymentDTO> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var result = paymentRepository.UpdatePayment(request.Id,request.Request);
            return Task.FromResult(result);
        }
    }
}
