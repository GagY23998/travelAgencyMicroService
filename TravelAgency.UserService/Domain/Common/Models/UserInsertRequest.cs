using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.UserService.Domain.Common.Models
{
    public class UserInsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public IList<UserRoleInsertRequest> UserRoles { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
