using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBroker.Contracts
{
    public interface TransportOfferRejected
    {
        public bool Rejected { get; set; }
        public DateTime Date { get; set; }

    }
}
