using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Application.Commands;

namespace TravelAgency.HotelService.Application.Validators
{
    public class HotelOfferValidator : AbstractValidator<CreateHotelOfferCommand>
    {
        public HotelOfferValidator()
        {
            RuleFor(_ => _.CreateRequest.ExpirationDate).NotNull().GreaterThan(DateTime.Now.AddDays(7));
            RuleFor(_ => _.CreateRequest.StartDate).NotNull().GreaterThan(DateTime.Now).LessThan(DateTime.Now.AddDays(6));
            RuleFor(_ => _.CreateRequest.HotelRoomId).NotNull();
        }
    }
}
