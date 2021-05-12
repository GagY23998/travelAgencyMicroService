using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Validators
{
    public class CityValidator : AbstractValidator<CityDTO>
    {
        public CityValidator()
        {
            RuleFor(_ => _.Name).NotNull();
            RuleFor(_ => _.Description).NotNull();
            RuleFor(_ => _.Rating).GreaterThanOrEqualTo(0);
            RuleFor(_ => _.TotalVisits).GreaterThanOrEqualTo(0);
        }
    }
}
