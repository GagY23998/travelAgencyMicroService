using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Common.Interfaces;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class DeleteHotelReviewCommandHandler : IRequestHandler<DeleteHotelReviewCommand, HotelReviewDTO>
    {
        public DeleteHotelReviewCommandHandler(IMediator mediator, IHotelReviewRepository hotelReviewRepository, ILogger<DeleteHotelReviewCommandHandler> logger)
        {
            Mediator = mediator;
            HotelReviewRepository = hotelReviewRepository;
            Logger = logger;
        }

        public IMediator Mediator { get; }
        public IHotelReviewRepository HotelReviewRepository { get; }
        public ILogger<DeleteHotelReviewCommandHandler> Logger { get; }

        public Task<HotelReviewDTO> Handle(DeleteHotelReviewCommand request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Deleting HotelReview for given Id at time:{0}",DateTime.Now);

            HotelReviewDTO result = HotelReviewRepository.Remove(request.HotelReviewId);

            return Task.FromResult(result);

        }
    }
}
