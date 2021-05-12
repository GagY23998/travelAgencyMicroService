using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Application.Commands;
using TravelAgency.BookingService.Domain.DTOs;

namespace TravelAgency.BookingService.Application.Validators
{
    public class BookingValidator : AbstractValidator<CreateBookingCommand>
    {

        public BookingValidator()
        {
            RuleFor(_ => _.Booking.HotelOffer).NotEmpty();
            RuleFor(_ => _.Booking.TourOffer).NotEmpty();
            RuleFor(_ => _.Booking.TransportOffer).NotEmpty();
            RuleFor(_ => _.Booking.ReservationDate).NotEmpty();
            RuleFor(_ => _.Booking.Payment).NotEmpty();
        }
    }
}
