using AutoMapper;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.DTOs;
using TravelAgency.BookingService.Domain.Repositories;
using TravelAgency.BookingService.Infrastructure.Data;

namespace TravelAgency.BookingService.Infrastructure.Services
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _context;
        private readonly IMapper mapper;

        public BookingRepository(BookingDbContext context,IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }
        public BookingDTO AddBooking(BookingCreateRequest booking)
        {
            
                var obj = mapper.Map<Booking>(booking);
                _context.Bookings.Add(obj);
                _context.SaveChanges();
                return mapper.Map<BookingDTO>(obj);
        }

        public bool CancelBooking(Guid id)
        {
            var entity = _context.Bookings.Find(id);
            if (entity != null)
            {
                entity.CanceledStatus = true;
                _context.Update(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public BookingDTO ChangeHotelOfferBooking(Guid Id)
        {
            var entity = _context.Bookings.Find(Id);
            if (entity != null)
            {
                entity.HotelOfferId = Id;
                _context.Update(entity);
                _context.SaveChanges();
                return mapper.Map<BookingDTO>(entity);
            }
            return null;
        }

        //public BookingDTO ChangeTourOfferBooking(Guid Id)
        //{
        //    var entity = _context.Bookings.Find(Id);
        //    if (entity != null)
        //    {
        //        entity.TourOffer = Id;
        //        _context.Update(entity);
        //        _context.SaveChanges();
        //        return mapper.Map<BookingDTO>(entity);
        //    }
        //    return null;
        //}

        public BookingDTO ChangeTransportOfferBooking(Guid Id)
        {
            var entity = _context.Bookings.Find(Id);
            if (entity != null)
            {
                entity.TransportOfferId = Id;
                _context.Update(entity);
                _context.SaveChanges();
                return mapper.Map<BookingDTO>(entity);
            }
            return null;
        }

        public bool DeleteBooking(Guid id)
        {
            var entity =_context.Bookings.Find(id);
            if(entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<BookingDTO> getBooking(BookingSearchRequest booking)
        {

            var queryable = _context.Set<Booking>().AsQueryable();
            foreach (var prop in booking.GetType().GetProperties())
            {
                var thatValue = prop.GetValue(booking,null);
                var instance = Activator.CreateInstance(prop.PropertyType);
                if(thatValue != null && !((object)thatValue).Equals((object)instance) && prop.PropertyType != typeof(DateTime)){
                    queryable = queryable.Where($"{prop.Name}=@0",thatValue);
                }
            }
            queryable = queryable.Where(_=>_.ReservationDate >= booking.FromDate && _.ReservationDate< booking.ToDate);
            var result = queryable.AsEnumerable<Booking>();
            
            return mapper.Map<IEnumerable<BookingDTO>>(result);
        }

        public BookingDTO getBookingById(Guid id)
        {
            var result = _context.Bookings.FirstOrDefault(_=>_.Id == id);
            if (result != null)
            {
                return mapper.Map<BookingDTO>(result);
            }
            return null;
        }

        public BookingDTO UpdateBooking(Guid Id,BookingCreateRequest booking)
        {
            var entity = _context.Bookings.Find(Id);
            if (entity != null)
            {
                var mapChange = mapper.Map<Booking>(booking);
                entity = mapChange;
                _context.Update(entity);
                _context.SaveChanges();
                return mapper.Map<BookingDTO>(entity);
            }
            return null;
        }
    }
}
