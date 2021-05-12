using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelAgency.TravelService.Application.Commands;
using TravelAgency.TravelService.Application.Queries;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgency.TravelService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        public IMediator Mediator { get; }
        public ILogger<TourController> Logger { get; }

        public TourController(IMediator mediator, ILogger<TourController> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }

        // GET: api/<TravelController>
        [HttpGet]
        public async Task<IEnumerable<TourDTO>> Get(TourSearchRequest searchRequest)
        {
            try
            {
                GetToursQuery offerQuery = new GetToursQuery(searchRequest);

                Logger.Log(LogLevel.Information, "Sending message to {0} handler at {1}", nameof(Tour), DateTime.Now);

                var result = await Mediator.Send(offerQuery, new System.Threading.CancellationToken());

                Logger.Log(LogLevel.Information, "Showing result of query {0} at {1}", result, DateTime.Now);

                return null;
            }
            catch (Exception e)
            {
                Logger.LogError("Error occured in {0}, method: {1}; Time: {2};", nameof(TourController), nameof(Get), DateTime.Now);
                return null;
            }

        }

        // GET api/<TravelController>/5
        [HttpGet("{id}")]
        public async Task<TourDTO> Get(int id)
        {
            GetTourByIdQuery query = new GetTourByIdQuery(id);
            var result = await Mediator.Send<TourDTO>(query, new System.Threading.CancellationToken());
            return result;
        }

        // POST api/<TravelController>
        [HttpPost]
        public async Task<TourDTO> Post([FromBody] TourInsertRequest insertRequest)
        {
            CreateTourCommand command = new CreateTourCommand(insertRequest);
            Logger.LogInformation($"Creating {nameof(Tour)}");
            var result = await Mediator.Send(command, new System.Threading.CancellationToken());
            Logger.LogInformation("Log result {0}", result);
            return result;
        }

        // PUT api/<TravelController>/5
        [HttpPut]
        public async Task<TourDTO> Put([FromRoute] object id, [FromBody] TourInsertRequest updateRequest)
        {
            var query = new GetTourByIdQuery(id);
            var targetObject = await Mediator.Send<TourDTO>(query, new System.Threading.CancellationToken());
            if (targetObject != null)
            {

                var updateCommand = new UpdateTourCommand(id, updateRequest);
                var result = await Mediator.Send<TourDTO>(updateCommand, new System.Threading.CancellationToken());

                return result;

            }
            return null;
        }

        // DELETE api/<TravelController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(object id)
        {
            var deleteCommand = new DeleteTourCommand(id);
            var result = await Mediator.Send<object>(deleteCommand, new System.Threading.CancellationToken());
            return Ok(result);
        }
    }
}
