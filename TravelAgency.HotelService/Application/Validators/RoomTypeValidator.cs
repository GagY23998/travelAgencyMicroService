using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Application.Commands;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Validators
{
    public class RoomTypeValidator : AbstractValidator<CreateRoomTypeCommand>
    {
        public RoomTypeValidator()
        {
            RuleFor(_ => _.CreateRequest.RoomType).NotNull().MinimumLength(4);
        }
    }
}
