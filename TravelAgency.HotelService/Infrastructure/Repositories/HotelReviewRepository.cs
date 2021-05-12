using System.Collections.Generic;
using AutoMapper;
using TravelAgency.HotelService.Domain;
using TravelAgency.HotelService.Domain.Common.Interfaces;
using TravelAgency.HotelService.Domain.Models;
using TravelAgency.HotelService.Infrastructure.Data;

namespace TravelAgency.HotelService.Infrastructure.Repositories
{
    public class HotelReviewRepository : GenericRepository<HotelReview,
                                                           HotelReviewDTO,
                                                           HotelReviewInsertRequest,
                                                           HotelReviewInsertRequest,
                                                           HotelReviewSearchRequest>,IHotelReviewRepository
    {
       public HotelReviewRepository(IMapper mapper,HotelDbContext context)
       :base(mapper,context)
       {
           
       }
    }
}