using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Domain.Common.Interfaces
{
    public interface IHotelReviewRepository : IGenericRepository<HotelReview,
                                                                 HotelReviewDTO,
                                                                 HotelReviewInsertRequest,
                                                                 HotelReviewInsertRequest,
                                                                 HotelReviewSearchRequest>
    {
        
    }
}