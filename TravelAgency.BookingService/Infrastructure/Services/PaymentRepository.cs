using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.DTOs;
using TravelAgency.BookingService.Domain.Repositories;
using TravelAgency.BookingService.Infrastructure.Data;

namespace TravelAgency.BookingService.Infrastructure.Services
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly BookingDbContext context;
        private readonly IMapper mapper;

        public PaymentRepository(BookingDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public PaymentDTO AddPayment(PaymentCreateRequest payment)
        {
            var obj = mapper.Map<Payment>(payment);
            context.Add(obj);
            context.SaveChanges();
            return mapper.Map<PaymentDTO>(obj);
        }

        public bool DeletePayment(Guid id)
        {
            var obj = context.Payments.FirstOrDefault(_ => _.Id == id);
            if (obj != null)
            {
                context.Payments.Remove(obj);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<PaymentDTO> getPayment(PaymentSearchRequest payment)
        {


            var paymentSet = context.Set<Payment>().AsQueryable();
            var properties = payment.GetType().GetProperties();



            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(property);
                paymentSet = paymentSet.Where($"{property.Name} = {propertyValue}");
            }


            var res = paymentSet.AsEnumerable<Payment>();
            var dto = mapper.Map<IEnumerable<PaymentDTO>>(res);
            return dto ?? null;
        }

        public PaymentDTO getPaymentById(Guid id)
        {
            var res = context.Payments.First(_ => _.Id == id);
            if (res != null)
            {
                return mapper.Map<PaymentDTO>(res);
            }
            return null;
        }

        public PaymentDTO UpdatePayment(Guid Id,PaymentCreateRequest payment)
        {
            var obj = context.Payments.FirstOrDefault(_ => _.Id == Id);
            if (obj != null)
            {
                var dto = mapper.Map<Payment>(payment);
                obj = dto;
                context.Payments.Update(obj);
                return mapper.Map<PaymentDTO>(obj);
            }
            return null;
        }
    }
}
