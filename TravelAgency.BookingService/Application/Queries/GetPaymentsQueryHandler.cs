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
    public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQuery, IEnumerable<PaymentDTO>>
    {
        private readonly IMediator mediator;
        private readonly IPaymentRepository paymentRepository;

        public GetPaymentsQueryHandler(IMediator mediator,IPaymentRepository paymentRepository)
        {
            this.mediator = mediator;
            this.paymentRepository = paymentRepository;
        }
        public Task<IEnumerable<PaymentDTO>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
        {
            var result = paymentRepository.getPayment(request.SearchRequest);

            return Task.FromResult(result);
        }
    }
}
