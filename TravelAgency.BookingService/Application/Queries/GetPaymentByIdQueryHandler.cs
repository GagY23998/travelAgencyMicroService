using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.DTOs;
using TravelAgency.BookingService.Domain.Repositories;

namespace TravelAgency.BookingService.Application.Queries
{
    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, PaymentDTO>
    {
        private readonly IMediator mediator;
        private readonly IPaymentRepository paymentRepository;

        public GetPaymentByIdQueryHandler(IMediator mediator,IPaymentRepository paymentRepository)
        {
            this.mediator = mediator;
            this.paymentRepository = paymentRepository;
        }

        public Task<PaymentDTO> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            PaymentDTO result = paymentRepository.getPaymentById(request.Id);
            return Task.FromResult(result);
        }
    }
}
