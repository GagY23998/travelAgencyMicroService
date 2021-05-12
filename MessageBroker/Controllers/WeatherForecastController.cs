using MassTransit;
using MassTransit.RabbitMqTransport;
using MessageBroker.Consumers;
using MessageBroker.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBroker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        readonly ILogger<WeatherForecastController> _logger;
        readonly IRequestClient<VerifyTOffer> _submitOrderRequestClient;
        readonly ISendEndpointProvider _sendEndpointProvider;
        readonly IRequestClient<VerifyHOffer> _checkOrderClient;
        readonly IPublishEndpoint _publishEndpoint;
        readonly IRabbitMqHost host;
        readonly IBus bus;
        public IPublishEndpoint PublishEndpoint { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBus bus, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            this.bus = bus;
            PublishEndpoint = publishEndpoint;
        }

        // [HttpGet]
        // public async Task<string> Get()
        // {
        //     //IRequestClient<VerifyTOffer> sendEndpoint = bus.CreateRequestClient<VerifyTOffer>();
        //     //var end = await sendEndpoint.GetResponse<TransportOfferAccepted, TransportOfferRejected>(new { TransportOfferId = Guid.NewGuid(), Date = DateTime.Now });
        //     //await PublishEndpoint.Publish<VerifyTOffer>(new { TransportOfferId = Guid.NewGuid(), Date = DateTime.Now }, new System.Threading.CancellationToken());
        //     //var result = end.Message as Tuple<TransportOfferAccepted, TransportOfferRejected>;
        //     return Task.FromResult("What's up");
        // }
    }
}
