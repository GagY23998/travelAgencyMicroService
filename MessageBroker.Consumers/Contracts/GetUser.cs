using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBroker.Consumers.Contracts
{
    public interface GetUser
    {
        public int UserId { get; set; }
        public object User { get; set; }
        public DateTime Date { get; set; }
    }
}
