using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBroker.Consumers.Contracts
{
    public interface UserResult
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
