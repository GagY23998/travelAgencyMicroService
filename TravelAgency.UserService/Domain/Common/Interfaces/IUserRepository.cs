using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain.Common.Models;

namespace TravelAgency.UserService.Domain.Common.Interfaces
{
    public interface IUserRepository : IGenericRepository<User,UserDTO,UserInsertRequest,UserInsertRequest,UserSearchRequest>
    {
    }
}
