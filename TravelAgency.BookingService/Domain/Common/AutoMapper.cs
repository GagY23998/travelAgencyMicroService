using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.DTOs;

namespace TravelAgency.BookingService.Domain.Common
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Booking, BookingDTO>().ReverseMap();
            CreateMap<BookingDTO, Booking>().ReverseMap();
            CreateMap<Booking,BookingCreateRequest>().ReverseMap();
            CreateMap<BookingDTO,BookingCreateRequest>().ReverseMap();
            CreateMap<BookingSearchRequest,BookingDTO>().ReverseMap();
            CreateMap<Payment,PaymentDTO>().ReverseMap();
            CreateMap<PaymentSearchRequest,PaymentDTO>().ReverseMap();
            CreateMap<Payment,PaymentSearchRequest>().ReverseMap();
            CreateMap<PaymentCreateRequest,PaymentSearchRequest>().ReverseMap();
            CreateMap<Payment,PaymentCreateRequest>().ReverseMap();
        }
    }
}
