using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.Repositories;

namespace TravelAgency.BookingService.Application.Commands
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, bool>
    {
        public IPaymentRepository paymentRepository { get; set; }
        public CreatePaymentCommandHandler(/*IPaymentRepository paymentRepository*/)
        {

            this.paymentRepository = paymentRepository;

        }
        public Task<bool> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            paymentRepository.AddPayment(request.Request);
            return Task.FromResult(true);
        }
    }
}
