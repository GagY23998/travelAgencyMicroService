using AutoMapper;
using MassTransit;
using MediatR;
using MessageBroker.Consumers.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Common;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetHotelsQueryHandler : IRequestHandler<GetHotelsQuery, IEnumerable<HotelDTO>>
    {
        public IMediator Mediator { get; }
        public IMapper Mapper { get; }
        public IHotelRepository HotelRepository { get; }
        public ILogger<GetHotelsQueryHandler> Logger { get; }
        public IRequestClient<GetUser> RequestClient { get; set; }
        public IPublishEndpoint PublishEndpoint { get; }

        public GetHotelsQueryHandler(IMediator mediator, IMapper mapper, IHotelRepository hotelRepository, IBus bus, ILogger<GetHotelsQueryHandler> logger)
        {
            Mediator = mediator;
            Mapper = mapper;
            HotelRepository = hotelRepository;
            Logger = logger;
            RequestClient = bus.CreateRequestClient<GetUser>();
            
        }

        public async Task<IEnumerable<HotelDTO>> Handle(GetHotelsQuery request, CancellationToken cancellationToken)
        {
            var result = await HotelRepository.Get(request.SearchRequest);
            await ResolveUsersForReviewsAsync(result);

            return result.Any() ? result : null;
        }
        Task ResolveUsersForReviewsAsync(IEnumerable<HotelDTO> hotels)
        {
            List<Task> tasks = new List<Task>();
            foreach (var item in hotels)
            {
                tasks.Add(GetUsersForHotelAsync(item));
            }
            return Task.WhenAll(tasks);
        }
        
        Task GetUsersForHotelAsync(HotelDTO hotelDTO)
        {
            List<Task> tasks = new List<Task>();
            hotelDTO.hotelReviews = hotelDTO.hotelReviews.Take(5);
            foreach (var review in hotelDTO.hotelReviews)
            {
                tasks.Add(FetchUserForHotelReviewAsync(review));
            }
            return Task.WhenAll(tasks);
        }
        async Task FetchUserForHotelReviewAsync(HotelReviewDTO hotelReviewDTO)
        {
            var res = await RequestClient.GetResponse<UserResult>(new { UserId = hotelReviewDTO.UserId },new CancellationToken());
            Logger.LogInformation("Recieved : {0}", res.Message.FirstName + " " + res.Message.LastName);
            hotelReviewDTO.User = new UserDTO
            {
                Id = res.Message.Id,
                FirstName = res.Message.FirstName,
                LastName = res.Message.LastName,
                Address = res.Message.Address,
                Age = res.Message.Age,
                BirthDate = res.Message.BirthDate,
                Picture = res.Message.Picture
            };
        }
    }
}
