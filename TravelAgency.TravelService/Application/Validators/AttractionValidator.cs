using FluentValidation;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Validators
{
    public class AttractionValidator : AbstractValidator<AttractionDTO>
    {
        public AttractionValidator()
        {
            RuleFor(_ => _.Name).NotNull().MinimumLength(5).MaximumLength(50);
            RuleFor(_ => _.Description).NotNull().MaximumLength(150);
            RuleFor(_ => _.CityId).NotNull();
        }
    }
}
