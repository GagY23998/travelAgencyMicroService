using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Application.Commands;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.DTOs;

namespace TravelAgency.BookingService.Domain.Repositories
{
    public interface IBookingRepository
    {
        BookingDTO AddBooking(BookingCreateRequest booking);
        BookingDTO UpdateBooking(Guid Id,BookingCreateRequest booking);
        bool DeleteBooking(Guid id);
        BookingDTO getBookingById(Guid id);
        IEnumerable<BookingDTO> getBooking(BookingSearchRequest booking);
        BookingDTO ChangeHotelOfferBooking(Guid Id);
        //BookingDTO ChangeTourOfferBooking(Guid Id);
        BookingDTO ChangeTransportOfferBooking(Guid Id);
        bool CancelBooking(Guid id);
    }
}
