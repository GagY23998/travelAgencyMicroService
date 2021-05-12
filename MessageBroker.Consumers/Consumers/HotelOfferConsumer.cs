using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Definition;
using MessageBroker.Contracts;

namespace MessageBroker.Consumers.Consumers
{
    public class HotelOfferConsumer : IConsumer<VerifyHOffer>
    {
        public Task Consume(ConsumeContext<VerifyHOffer> context)
        {
            return Task.CompletedTask;
        }
    }
    class HotelOfferClassDefinition: ConsumerDefinition<HotelOfferConsumer>
    {
        public HotelOfferClassDefinition()
        {
            base.EndpointName = "booking-hoffer";
        }
    }
}
