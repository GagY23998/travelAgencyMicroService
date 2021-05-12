using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.HotelService.Application.Commands;
using TravelAgency.HotelService.Application.Queries;
using TravelAgency.HotelService.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgency.HotelService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        public IMediator Mediator { get; }

        public RoomTypeController(IMediator mediator)
        {
            Mediator = mediator;
        }
        // GET: api/<RoomTypeController>
        [HttpGet]
        public async Task<IEnumerable<RoomTypeDTO>> Get([FromQuery] RoomTypeSearchRequest RoomTypeSearchRequest)
        {

            GetRoomTypesQuery query = new GetRoomTypesQuery(RoomTypeSearchRequest);

            var result = await Mediator.Send(query, new System.Threading.CancellationToken());

            return result;

        }

        // GET api/<RoomTypeController>/5
        [HttpGet("{id}")]
        public async Task<RoomTypeDTO> Get(int id)
        {
            GetRoomTypeByIdQuery query = new GetRoomTypeByIdQuery(id);

            var result = await Mediator.Send(query, new System.Threading.CancellationToken());

            return result;
        }

        // POST api/<RoomTypeController>
        [HttpPost]
        public async Task<RoomTypeDTO> Post([FromBody] RoomTypeCreateRequest RoomTypeCreateRequest)
        {
            CreateRoomTypeCommand command = new CreateRoomTypeCommand(RoomTypeCreateRequest);

            var result = await Mediator.Send(command, new System.Threading.CancellationToken());

            return result;
        }

        // PUT api/<RoomTypeController>/5
        [HttpPut("{id}")]
        public async Task<RoomTypeDTO> Put([FromRoute]object id, [FromBody] RoomTypeCreateRequest createRequest)
        {
            UpdateRoomTypeCommand command = new UpdateRoomTypeCommand(id, createRequest);

            var result = await Mediator.Send(command, new System.Threading.CancellationToken());

            return result;
        }

        // DELETE api/<RoomTypeController>/5
        [HttpDelete("{id}")]
        public async Task<RoomTypeDTO> Delete(object id)
        {
            DeleteRoomTypeCommand command = new DeleteRoomTypeCommand(id);

            var result = await Mediator.Send(command, new System.Threading.CancellationToken());

            return result;
        }
    }
}
