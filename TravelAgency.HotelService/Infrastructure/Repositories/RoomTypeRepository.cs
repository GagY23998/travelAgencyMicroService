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
    public class RoomTypeRepository : GenericRepository<RoomType, RoomTypeDTO, RoomTypeCreateRequest, RoomTypeCreateRequest, RoomTypeSearchRequest>,IRoomTypeRepository
    {
        public RoomTypeRepository(IMapper mapper,HotelDbContext context): base(mapper,context)
        {

        }
    }
}
