using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.HotelService.Domain.Common
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }
        public int Age { get; set; }
        public ICollection<UserRoleDTO> UserRoles { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
