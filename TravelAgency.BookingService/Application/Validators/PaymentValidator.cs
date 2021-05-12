using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.DTOs;

namespace TravelAgency.BookingService.Application.Validators
{
    public class PaymentValidator : AbstractValidator<PaymentCreateRequest>
    {

        public PaymentValidator()
        {
            RuleFor(_ => _.Discount).LessThanOrEqualTo(100);
            RuleFor(_ => _.PaymentDate).NotNull();
            RuleFor(_ => _.Price).GreaterThan(0);

        }
    }
}
