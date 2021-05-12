using MassTransit;
using TravelAgency.UserService.Domain.Common.Models;
using MessageBroker.Consumers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain.Common.Interfaces;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;

namespace TravelAgency.UserService.Infrastructure.Consumers
{
    public class GetUserConsumer : IConsumer<GetUser>
    {
        IUserRepository userRepository;
        private readonly ILogger<GetUserConsumer> logger;

        public GetUserConsumer()
        {

        }
        public GetUserConsumer(IUserRepository userRepository, ILogger<GetUserConsumer> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }
        public async Task Consume(ConsumeContext<GetUser> context)
        {
            var user = userRepository.GetById(context.Message.UserId);

            logger.LogInformation("Got User : {0}", user);
            byte[] picBytes= await File.ReadAllBytesAsync($"/app/Images/{user.FirstName+"-"+user.LastName}.png");
            user.Picture = Convert.ToBase64String(picBytes);
            await context.RespondAsync<UserResult>(new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.Age,
                user.Picture,
                user.Address,
                user.BirthDate
            });

            return;
        }
    }
}
