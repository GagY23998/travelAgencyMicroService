using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Validators
{
    public class TransportValidator : AbstractValidator<TransportCompanyDTO>
    {
        public TransportValidator()
        {
            RuleFor(_ => _.Name).NotNull().MinimumLength(4).MaximumLength(50);
            RuleFor(_=>_.TransportTypeId).NotNull();
        }
    }
}
