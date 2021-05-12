using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelAgency.HotelService.Application.Commands;
using TravelAgency.HotelService.Application.Queries;
using TravelAgency.HotelService.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgency.HotelService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        public IMediator Mediator { get; }
        public ILogger<HotelController> Logger { get; }

        public HotelController(IMediator mediator, ILogger<HotelController> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }
        // GET: api/<HotelController>
        [HttpGet]
        public async Task<IEnumerable<HotelDTO>> Get([FromQuery] HotelSearchRequest hotelSearchRequest)
        {

            GetHotelsQuery query = new GetHotelsQuery(hotelSearchRequest);

            var result = await Mediator.Send(query, new System.Threading.CancellationToken());

            return result;

        }

        // GET api/<HotelController>/5
        [HttpGet("{id}")]
        public async Task<HotelDTO> Get(int id)
        {
            GetHotelByIdQuery query = new GetHotelByIdQuery(id);

            var result = await Mediator.Send(query, new System.Threading.CancellationToken());

            return result;
        }

        // POST api/<HotelController>
        [HttpPost]
        public async Task<HotelDTO> Post([FromBody] HotelCreateRequest hotelCreateRequest)
        {
            CreateHotelCommand command = new CreateHotelCommand(hotelCreateRequest);

            var result = await Mediator.Send(command, new System.Threading.CancellationToken());

            return result;
        }

        // PUT api/<HotelController>/5
        [HttpPut("{id}")]
        public async Task<HotelDTO> Put([FromRoute]object id, [FromBody] HotelCreateRequest createRequest)
        {
            UpdateHotelCommand command = new UpdateHotelCommand(id, createRequest);

            var result = await Mediator.Send(command, new System.Threading.CancellationToken());


            return result;
        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public async Task<HotelDTO> Delete(object id)
        {
            DeleteHotelCommand command = new DeleteHotelCommand((int)id);

            var result = await Mediator.Send(command, new System.Threading.CancellationToken());

            return result;
        }
        [HttpGet("topRatings")]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetRatings()
        {
            
            var result = await this.Get(new HotelSearchRequest());

            Logger.LogInformation($"Call yielded {result.Count()} results");
            
            return Ok(result.OrderByDescending(_=>_.Rating).Take(5).AsEnumerable());
        }
    }
}
