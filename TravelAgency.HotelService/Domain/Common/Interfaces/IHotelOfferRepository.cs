using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Domain.Common.Interfaces
{
    public interface IHotelOfferRepository : IGenericRepository<HotelOffer,HotelOfferDTO,HotelOfferCreateRequest,HotelOfferCreateRequest,HotelOfferSearchRequest>
    {
    }
}
