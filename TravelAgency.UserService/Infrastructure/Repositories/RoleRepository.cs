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
    public class RoleRepository : GenericRepository<Role, RoleDTO, RoleInsertRequest, RoleInsertRequest, RoleSearchRequest>,IRoleRepository
    {
        public RoleRepository(IMapper mapper, UserDbContext userDbContext):base(mapper,userDbContext)
        {

        }
    }
}
