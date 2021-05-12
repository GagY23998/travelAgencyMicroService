using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Application.Commands;

namespace TravelAgency.HotelService.Application.Validators
{
    public class HotelValidator : AbstractValidator<CreateHotelCommand>
    {
        public HotelValidator()
        {
            RuleFor(_ => _.CreateRequest.CityId).NotNull();
            RuleFor(_ => _.CreateRequest.HotelRooms).NotNull();
            RuleFor(_ => _.CreateRequest.Description).NotNull().MinimumLength(15);
            RuleFor(_ => _.CreateRequest.Name).NotNull().MinimumLength(4);
        }
    }
}
