using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.UserService.Domain.Common.Models
{
    public class UserRoleInsertRequest
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
    }
}
