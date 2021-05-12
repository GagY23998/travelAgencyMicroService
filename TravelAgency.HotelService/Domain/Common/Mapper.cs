using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Domain.Common
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<HotelDTO, HotelCreateRequest>().ReverseMap();
            CreateMap<Hotel, HotelCreateRequest>().ReverseMap();
            CreateMap<HotelOffer, HotelOfferCreateRequest>().ReverseMap();
            CreateMap<HotelOfferDTO, HotelOfferCreateRequest>().ReverseMap();
            CreateMap<HotelOffer, HotelOfferDTO>().ReverseMap();
            CreateMap<HotelReview, HotelReviewDTO>().ReverseMap();
            CreateMap<HotelReview, HotelReviewInsertRequest>();
            CreateMap<HotelReviewDTO, HotelReviewInsertRequest>();
            CreateMap<RoomType, RoomTypeDTO>().ReverseMap();
            CreateMap<RoomType, RoomTypeCreateRequest>().ReverseMap();
            CreateMap<RoomTypeDTO, RoomTypeCreateRequest>().ReverseMap();
            CreateMap<HotelRoom,HotelRoomDTO>().ReverseMap();
            CreateMap<HotelRoom,HotelRoomCreateRequest>().ReverseMap();
            CreateMap<HotelRoomDTO,HotelRoomCreateRequest>().ReverseMap();
        }
    }
}
