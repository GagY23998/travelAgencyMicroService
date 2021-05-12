using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Application.Queries;

namespace TravelAgency.HotelService.Application.Validators
{
    public class QHotelOfferValidator : AbstractValidator<GetHotelOffersQuery>
    {
        public QHotelOfferValidator()
        {
            RuleFor(_ => _.SearchRequest.ExpirationDate).NotNull();
            RuleFor(_ => _.SearchRequest.StartDate).NotNull();
            RuleFor(_ => _.SearchRequest.HotelName).NotNull();
            RuleFor(_ => _.SearchRequest.NumberOfRooms).NotNull();
        }
    }
}
