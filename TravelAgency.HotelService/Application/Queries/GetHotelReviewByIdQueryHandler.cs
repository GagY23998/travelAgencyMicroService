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
    public class GetHotelReviewByIdQueryHandler : IRequestHandler<GetHotelReviewByIdQuery, HotelReviewDTO>
    {
        public GetHotelReviewByIdQueryHandler(IMediator mediator, IHotelReviewRepository hotelReviewRepository, ILogger<GetHotelReviewByIdQueryHandler> logger)
        {
            Mediator = mediator;
            HotelReviewRepository = hotelReviewRepository;
            Logger = logger;
        }

        public IMediator Mediator { get; }
        public IHotelReviewRepository HotelReviewRepository { get; }
        public ILogger<GetHotelReviewByIdQueryHandler> Logger { get; }

        public Task<HotelReviewDTO> Handle(GetHotelReviewByIdQuery request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Fetching hotel review for given id at {0}", DateTime.Now);

            HotelReviewDTO result = HotelReviewRepository.GetById(request.Id);

            return Task.FromResult(result);
        }
    }
}
