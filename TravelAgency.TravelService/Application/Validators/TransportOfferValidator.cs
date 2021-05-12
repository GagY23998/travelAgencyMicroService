using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Validators
{
    public class TransportOfferValidator : AbstractValidator<TransportOfferDTO>
    {
        public TransportOfferValidator()
        {
            RuleFor(_ => _.CityId).NotNull();
            RuleFor(_ => _.TransportCompanyId).NotNull();
            RuleFor(_ => _.StartDate).NotNull().GreaterThan(DateTime.Now.AddDays(1)).LessThan(DateTime.Now.AddDays(7));
        }
    }
}
