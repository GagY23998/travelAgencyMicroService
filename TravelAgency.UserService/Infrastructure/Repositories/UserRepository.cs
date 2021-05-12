using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain;
using TravelAgency.UserService.Domain.Common.Interfaces;
using TravelAgency.UserService.Domain.Common.Models;
using TravelAgency.UserService.Infrastructure.Data;

namespace TravelAgency.UserService.Infrastructure.Repositories
{
    public class UserRepository: GenericRepository<User,UserDTO,UserInsertRequest,UserInsertRequest,UserSearchRequest>,IUserRepository
    {
        public UserRepository(IMapper mapper, UserDbContext userDbContext)
            :base (mapper,userDbContext)
        {

        }
    }
}
