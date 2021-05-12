using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TravelAgency.UserService.Domain.Common.Models
{
    public class UserRoleDTO
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
