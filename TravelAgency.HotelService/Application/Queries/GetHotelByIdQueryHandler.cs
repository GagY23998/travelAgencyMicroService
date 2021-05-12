using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Common;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, HotelDTO>
    {
        public IHotelRepository HotelRepository { get; }

        public GetHotelByIdQueryHandler(IHotelRepository hotelRepository)
        {
            HotelRepository = hotelRepository;
        }

       
        public Task<HotelDTO> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
        {
            var result = HotelRepository.GetById(request.Id);

            return result != null ? Task.FromResult(result) : null;
        }
    }
}
