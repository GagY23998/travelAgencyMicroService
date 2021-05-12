using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBroker.Consumers.Contracts
{
    public interface VerifyTOffer
    {
        public Guid TransportOfferId { get; set; }
        public DateTime Date { get; set; }
    }
}
