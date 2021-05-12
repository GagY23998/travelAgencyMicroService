using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Definition;
using MessageBroker.Contracts;
using Microsoft.Extensions.Logging;

namespace MessageBroker.Consumers.Consumers
{
    public class TransportOfferConsumer : IConsumer<VerifyTOffer>
    {
        public TransportOfferConsumer()
        {
        }
        public Task Consume(ConsumeContext<VerifyTOffer> context)
        {
            return Task.CompletedTask;
        }
    }
    class TransportOfferConsumerDefinition :ConsumerDefinition<TransportOfferConsumer>
    {
        public TransportOfferConsumerDefinition()
        {
            EndpointName = "booking-toffer";
        }
    }
}
