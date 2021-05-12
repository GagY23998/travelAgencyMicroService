﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Domain.Common
{
    public interface IRoomTypeRepository : IGenericRepository<RoomType,RoomTypeDTO,RoomTypeCreateRequest,RoomTypeCreateRequest,RoomTypeSearchRequest>
    {
    }
}
