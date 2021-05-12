using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.UserService.Application.Commands;
using TravelAgency.UserService.Application.Queries;
using TravelAgency.UserService.Domain.Common.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgency.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IMediator Mediator { get; }

        public UserController(IMediator mediator)
        {
            Mediator = mediator;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get(UserSearchRequest searchRequest)
        {
            GetUsersQuery query = new GetUsersQuery(searchRequest);
            var result = await Mediator.Send(query, new System.Threading.CancellationToken());
            return result;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<UserDTO> Get(Guid id)
        {
            GetUserByIdQuery query = new GetUserByIdQuery(id);
            UserDTO result = await Mediator.Send(query, new System.Threading.CancellationToken());
            return result;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<UserDTO> Post([FromBody] UserInsertRequest insertRequest)
        {
            CreateUserCommand command = new CreateUserCommand(insertRequest);

            var result = await Mediator.Send(command, new System.Threading.CancellationToken());

            return result;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<UserDTO> Put([FromRoute]object id, [FromBody] UserInsertRequest updateRequest)
        {
            UpdateUserCommand command = new UpdateUserCommand(id, updateRequest);
            var result = await Mediator.Send(command, new System.Threading.CancellationToken());
            return result;
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(object Id)
        {

            DeleteUserCommand command = new DeleteUserCommand(Id);
            var result = await Mediator.Send(command, new System.Threading.CancellationToken());

            return result;
        }
    }
}
