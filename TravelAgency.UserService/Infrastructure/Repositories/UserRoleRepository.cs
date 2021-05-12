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
    public class UserRoleRepository : GenericRepository<UserRole, UserRoleDTO, UserRoleInsertRequest, UserRoleInsertRequest,UserRoleSearchRequest>,IUserRoleRepository
    {
        public UserRoleRepository(IMapper mapper, UserDbContext userDbContext)
            : base(mapper,userDbContext)
        {

        }

        public bool RemoveUserRole(int userId)
        {
            var userRoles = System.Linq.Enumerable.Where(_context.UserRoles, (_ => _.UserId == userId));
            _context.RemoveRange(userRoles);
            _context.SaveChanges();
            return true;
        }
    }
}
