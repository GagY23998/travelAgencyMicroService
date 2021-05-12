using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBroker.Contracts
{
    public interface VerifyHOffer
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
    }
}
