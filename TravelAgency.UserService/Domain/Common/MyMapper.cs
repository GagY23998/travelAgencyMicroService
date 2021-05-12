using AutoMapper;
using MessageBroker.Consumers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain.Common.Models;

namespace TravelAgency.UserService.Domain.Common
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserInsertRequest>().ReverseMap();
            CreateMap<UserInsertRequest, UserDTO>().ReverseMap();
            CreateMap<RoleInsertRequest, RoleDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<RoleInsertRequest, Role>().ReverseMap();
            CreateMap<UserRole, UserRoleInsertRequest>().ReverseMap();
            CreateMap<UserRole, UserRoleDTO>().ReverseMap();
            CreateMap<UserRoleDTO, UserRoleInsertRequest>().ReverseMap();
            CreateMap<UserDTO, UserResult>().ReverseMap();
        }
    }
}
