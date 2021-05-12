using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Application.Commands;
using TravelAgency.HotelService.Application.Queries;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelReviewService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelReviewController : ControllerBase
    {
        public IMediator Mediator { get; }
        public ILogger<HotelReviewController> Logger { get; }

        public HotelReviewController(IMediator mediator, ILogger<HotelReviewController> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }
        // GET: api/<HotelReviewController>
        [HttpGet]
        public async Task<IEnumerable<HotelReviewDTO>> Get([FromQuery] HotelReviewSearchRequest HotelReviewSearchRequest)
        {

            GetHotelReviewsQuery query = new GetHotelReviewsQuery(HotelReviewSearchRequest);

            var result = await Mediator.Send(query, new System.Threading.CancellationToken());

            return result;

        }

        // GET api/<HotelReviewController>/5
        [HttpGet("{id}")]
        public async Task<HotelReviewDTO> Get(int id)
        {
            GetHotelReviewByIdQuery query = new GetHotelReviewByIdQuery(id);

            var result = await Mediator.Send(query, new System.Threading.CancellationToken());

            return result;
        }

        // POST api/<HotelReviewController>
        [HttpPost]
        public async Task<HotelReviewDTO> Post([FromBody] HotelReviewInsertRequest HotelReviewCreateRequest)
        {
            CreateHotelReviewCommand command = new CreateHotelReviewCommand(HotelReviewCreateRequest);

            var result = await Mediator.Send(command, new System.Threading.CancellationToken());

            return result;
        }

        // PUT api/<HotelReviewController>/5
        [HttpPut("{id}")]
        public async Task<HotelReviewDTO> Put([FromRoute] object id, [FromBody] HotelReviewInsertRequest createRequest)
        {
            UpdateHotelReviewCommand command = new UpdateHotelReviewCommand((int)id, createRequest);

            var result = await Mediator.Send(command, new System.Threading.CancellationToken());


            return result;
        }

        // DELETE api/<HotelReviewController>/5
        [HttpDelete("{id}")]
        public async Task<HotelReviewDTO> Delete(object id)
        {
            DeleteHotelReviewCommand command = new DeleteHotelReviewCommand((int)id);

            var result = await Mediator.Send(command, new System.Threading.CancellationToken());

            return result;
        }
    }
}
