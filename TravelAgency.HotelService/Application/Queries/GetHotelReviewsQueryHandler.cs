using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Common.Interfaces;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetHotelReviewsQueryHandler : IRequestHandler<GetHotelReviewsQuery, IEnumerable<HotelReviewDTO>>
    {
        public GetHotelReviewsQueryHandler(IMediator mediator, IHotelReviewRepository hotelReviewRepository, ILogger<GetHotelReviewsQuery> logger)
        {
            Mediator = mediator;
            HotelReviewRepository = hotelReviewRepository;
            Logger = logger;
        }

        public IMediator Mediator { get; }
        public IHotelReviewRepository HotelReviewRepository { get; }
        public ILogger<GetHotelReviewsQuery> Logger { get; }

        public async Task<IEnumerable<HotelReviewDTO>> Handle(GetHotelReviewsQuery request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Retrieving hotel reviews for given request at : {0}", DateTime.Now);
            IEnumerable<HotelReviewDTO> result = await HotelReviewRepository.Get(request.Request);

            return result;
        }
    }
}
