using AutoMapper;
using System;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Domain.Common
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<TransportCompany, TransportCompanyDTO>().ReverseMap();
            CreateMap<TransportCompany, TransportCompanyInsertRequest>().ReverseMap();
            CreateMap<TransportCompanyDTO, TransportCompanyInsertRequest>().ReverseMap();
            CreateMap<TransportOffer, TransportOfferDTO>().ReverseMap();
            CreateMap<TransportOffer, TransportOfferInsertRequest>().ReverseMap();
            CreateMap<TransportOfferDTO, TransportOffer>().ReverseMap();
            CreateMap<TransportType, TransportTypeDTO>().ReverseMap();
            CreateMap<TransportType, TransportTypeDTO>().ReverseMap();
            CreateMap<TransportTypeDTO, TransportTypeInsertRequest>().ReverseMap();
            CreateMap<TransportReview, TransportReviewDTO>().ReverseMap();
            CreateMap<TransportReview, TransportReviewInsertRequest>().ReverseMap();
            CreateMap<TransportReviewDTO, TransportReviewInsertRequest>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<City, CityInsertRequest>().ReverseMap();
            CreateMap<CityDTO, CityInsertRequest>().ReverseMap();
            CreateMap<Country,CountryDTO>().ReverseMap();
            CreateMap<CountryDTO,CountryInsertRequest>().ReverseMap();
        }
    }
}
