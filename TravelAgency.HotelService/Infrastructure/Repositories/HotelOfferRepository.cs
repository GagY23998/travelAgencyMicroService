using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain;
using TravelAgency.HotelService.Domain.Common;
using TravelAgency.HotelService.Domain.Common.Interfaces;
using TravelAgency.HotelService.Domain.Models;
using TravelAgency.HotelService.Infrastructure.Data;

namespace TravelAgency.HotelService.Infrastructure.Repositories
{
    public class HotelOfferRepository : GenericRepository<HotelOffer, HotelOfferDTO, HotelOfferCreateRequest, HotelOfferCreateRequest, HotelOfferSearchRequest>, IHotelOfferRepository
    {
        public HotelOfferRepository(IMapper mapper,HotelDbContext context):base(mapper,context)
        {

        }
        public async override Task<IEnumerable<HotelOfferDTO>> Get(HotelOfferSearchRequest searchRequest)
        {
            IEnumerable<HotelOfferDTO> result= await base.Get(searchRequest);
            result = searchRequest.CityId != 0 ? result.Where(_ => _.Hotel.CityId == searchRequest.CityId).AsEnumerable() : result;
                    
            result =(searchRequest.ExpirationDate != default &&
                     searchRequest.StartDate!= default) ?
                     result.Where(_ => _.ExpirationDate < searchRequest.ExpirationDate).Where(_ => _.StartDate > searchRequest.StartDate).AsEnumerable() 
                     : result;
            return result;
        }

    }
}
