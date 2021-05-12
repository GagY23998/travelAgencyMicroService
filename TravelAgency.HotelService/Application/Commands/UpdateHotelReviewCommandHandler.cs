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
    public class UpdateHotelReviewCommandHandler : IRequestHandler<UpdateHotelReviewCommand, HotelReviewDTO>
    {
        public UpdateHotelReviewCommandHandler(IMediator mediator, IHotelReviewRepository hotelReviewRepository, ILogger<UpdateHotelReviewCommandHandler> logger)
        {
            Mediator = mediator;
            HotelReviewRepository = hotelReviewRepository;
            Logger = logger;
        }

        public IMediator Mediator { get; }
        public IHotelReviewRepository HotelReviewRepository { get; }
        public ILogger<UpdateHotelReviewCommandHandler> Logger { get; }

        public Task<HotelReviewDTO> Handle(UpdateHotelReviewCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation("Updating hotel review at: {0}", DateTime.Now);
            
                HotelReviewDTO result = HotelReviewRepository.Update(request.Id, request.UpdateRequest);

                return Task.FromResult(result);

            }catch(Exception e)
            {
                Logger.LogInformation("Error occured at {0} ,time :{0}", nameof(UpdateHotelReviewCommandHandler), DateTime.Now);
                Logger.LogError(e.Message);
                return null;
            }
        }
    }
}
