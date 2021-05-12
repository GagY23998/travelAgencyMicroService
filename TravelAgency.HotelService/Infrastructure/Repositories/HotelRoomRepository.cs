using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain;
using TravelAgency.HotelService.Domain.Common;
using TravelAgency.HotelService.Domain.Models;
using TravelAgency.HotelService.Infrastructure.Data;

namespace TravelAgency.HotelService.Infrastructure.Repositories
{
    public class HotelRoomRepository: GenericRepository<HotelRoom, HotelRoomDTO, HotelRoomCreateRequest, HotelRoomCreateRequest, HotelRoomSearchRequest>,IHotelRoomRepository
    {
        public HotelRoomRepository(IMapper mapper,HotelDbContext context):base(mapper,context)
        {

        }
    }
}
