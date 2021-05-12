using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Application.Queries;

namespace TravelAgency.HotelService.Application.Validators
{
    public class QHotelValidator : AbstractValidator<GetHotelsQuery>
    {
        public QHotelValidator()
        {
            RuleFor(_ => _.SearchRequest.Name).NotNull();
        }
    }
}
