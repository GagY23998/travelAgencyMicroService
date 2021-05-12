using System;
using TravelAgency.UserService.Domain.Common.Interfaces;
using Xunit;
using Moq;
using AutoMapper;
using TravelAgency.UserService.Domain;
using TravelAgency.UserService.Domain.Common.Models;
using System.Threading.Tasks;
using System.Threading;
using TravelAgency.UserService.Application.Commands;
using TravelAgency.UserService.Application.Commands.Handlers;
using System.Collections.Generic;

namespace UnitTesting.UserService
{
    public class CommandTests
    {
        Mock<IMapper> mockMapper;
        Mock<IUserRepository> mockUserRepository;
        Mock<IUserRoleRepository> mockUserRoleRepository;
        Mock<IRoleRepository> mockRoleRepository;
        public CommandTests()
        {
            mockMapper = new Mock<IMapper>();
            mockUserRepository = new Mock<IUserRepository>();
            mockRoleRepository = new Mock<IRoleRepository>();
            mockUserRoleRepository = new Mock<IUserRoleRepository>();

        }


        [Fact]
        public async Task CreateUser_IfValid_ReturnSuccess()
        {
            //Arrange
            var fakeInsertUser = new UserInsertRequest();
            var fakeUser = new User();
            var fakeUserDTO = new UserDTO();
            fakeInsertUser.UserRoles = new List<UserRoleInsertRequest> { new UserRoleInsertRequest(), new UserRoleInsertRequest() };
            mockMapper.Setup(_ => _.Map<UserDTO>(It.IsAny<User>())).Returns(fakeUserDTO);
            mockMapper.Setup(_ => _.Map<User>(It.IsAny<UserInsertRequest>())).Returns(new User());
            mockMapper.Setup(_ => _.Map<User>(It.IsAny<UserDTO>())).Returns(fakeUser);
            mockUserRepository.Setup(_ => _.Add(It.IsAny<UserInsertRequest>())).Returns(fakeUserDTO);
            mockUserRoleRepository.Setup(_ => _.Add(It.IsAny<UserRoleInsertRequest>())).Returns(It.IsAny<UserRoleDTO>());
            var fakeCommand = new CreateUserCommand(fakeInsertUser);
            var fakeCommandHandler = new CreateUserCommandHandler(mockMapper.Object, mockUserRepository.Object, mockUserRoleRepository.Object);
            //Act

            var result = await fakeCommandHandler.Handle(fakeCommand, new CancellationToken());

            //Assert
            Assert.IsType<UserDTO>(result);
        }

        [Fact]
        public async Task DeleteUser_IfValid_ReturnSuccess()
        {
            //Arrange
            var fakeInsertUser = new UserInsertRequest();
            var fakeUser = new User();
            var fakeUserDTO = new UserDTO();
            fakeInsertUser.UserRoles = new List<UserRoleInsertRequest> { new UserRoleInsertRequest(), new UserRoleInsertRequest() };
            mockMapper.Setup(_ => _.Map<UserDTO>(It.IsAny<User>())).Returns(fakeUserDTO);
            mockMapper.Setup(_ => _.Map<User>(It.IsAny<UserInsertRequest>())).Returns(new User());
            mockMapper.Setup(_ => _.Map<User>(It.IsAny<UserDTO>())).Returns(fakeUser);
            mockUserRepository.Setup(_ => _.Remove(It.IsAny<object>())).Returns(fakeUserDTO);
            mockUserRoleRepository.Setup(_ => _.Remove(It.IsAny<object>())).Returns(It.IsAny<UserRoleDTO>());
            var fakeCommand = new DeleteUserCommand(It.IsAny<object>());
            var fakeCommandHandler = new DeleteUserCommandHandler(mockMapper.Object, mockUserRepository.Object, mockUserRoleRepository.Object);
            //Act

            var result = await fakeCommandHandler.Handle(fakeCommand, new CancellationToken());

            //Assert
            Assert.IsType<UserDTO>(result);
        }
        [Fact]
        public async Task CreateRole_IfValid_ReturnSuccess()
        {
            //Arrange
            var fakeUser = new RoleInsertRequest();
            var fakeUserDTO = new RoleDTO();
            mockMapper.Setup(_ => _.Map<RoleDTO>(It.IsAny<Role>())).Returns(fakeUserDTO);
            mockMapper.Setup(_ => _.Map<Role>(It.IsAny<RoleDTO>())).Returns(new Role());
            mockRoleRepository.Setup(_ => _.Add(It.IsAny<RoleInsertRequest>())).Returns(fakeUserDTO);
            var fakeCommand = new CreateRoleCommand(fakeUser);
            var fakeCommandHandler = new CreateRoleCommandHandler(mockMapper.Object, mockRoleRepository.Object);
            //Act

            var result = await fakeCommandHandler.Handle(fakeCommand, new CancellationToken());

            //Assert
            Assert.IsType<RoleDTO>(result);
        }
        [Fact]
        public async Task DeleteRole_IfValid_ReturnSuccess()
        {
            //Arrange
            var fakeUser = new RoleInsertRequest();
            var fakeUserDTO = new RoleDTO();
            mockMapper.Setup(_ => _.Map<RoleDTO>(It.IsAny<Role>())).Returns(fakeUserDTO);
            mockMapper.Setup(_ => _.Map<Role>(It.IsAny<RoleDTO>())).Returns(new Role());
            mockRoleRepository.Setup(_ => _.Remove(It.IsAny<object>())).Returns(fakeUserDTO);
            var fakeCommand = new DeleteRoleCommand(fakeUser);
            var fakeCommandHandler = new DeleteRoleCommandHandler(mockMapper.Object, mockRoleRepository.Object);
            //Act

            var result = await fakeCommandHandler.Handle(fakeCommand, new CancellationToken());

            //Assert
            Assert.IsType<RoleDTO>(result);
        }
    }
}
