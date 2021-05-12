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
    public class CreateHotelReviewCommandHandler : IRequestHandler<CreateHotelReviewCommand, HotelReviewDTO>
    {
        public CreateHotelReviewCommandHandler(IMediator mediator, IHotelReviewRepository hotelReviewRepository, ILogger<CreateHotelReviewCommandHandler> logger)
        {
            Mediator = mediator;
            HotelReviewRepository = hotelReviewRepository;
            Logger = logger;
        }

        public IMediator Mediator { get; }
        public IHotelReviewRepository HotelReviewRepository { get; }
        public ILogger<CreateHotelReviewCommandHandler> Logger { get; }

        public Task<HotelReviewDTO> Handle(CreateHotelReviewCommand request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Creating Hotel Review at time: {0}", DateTime.Now);
            HotelReviewDTO result = HotelReviewRepository.Add(request.InsertRequest);

            Logger.LogInformation("Returned result of type", result.GetType().Name);

            return Task.FromResult(result);
        }
    }
}
