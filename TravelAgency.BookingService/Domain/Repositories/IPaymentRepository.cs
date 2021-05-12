using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.DTOs;

namespace TravelAgency.BookingService.Domain.Repositories
{
    public interface IPaymentRepository
    {
        PaymentDTO AddPayment(PaymentCreateRequest payment);
        PaymentDTO UpdatePayment(Guid Id, PaymentCreateRequest payment);
        bool DeletePayment(Guid id);
        PaymentDTO getPaymentById(Guid id);
        IEnumerable<PaymentDTO> getPayment(PaymentSearchRequest payment);
       
    }
}
