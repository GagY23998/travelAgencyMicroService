using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelAgency.TravelService.Application.Commands;
using TravelAgency.TravelService.Application.Queries.Handlers;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgency.TravelService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        public IMediator Mediator { get; }
        public ILogger<AttractionController> Logger { get; }

        public AttractionController(IMediator mediator, ILogger<AttractionController> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }

        // GET: api/<TravelController>
        [HttpGet]
        public async Task<IEnumerable<AttractionDTO>> Get(AttractionSearchRequest searchRequest)
        {
            try
            {
                GetAttractionsQuery offerQuery = new GetAttractionsQuery(searchRequest);

                Logger.Log(LogLevel.Information, "Sending message to {0} handler at {1}", nameof(Attraction), DateTime.Now);

                var result = await Mediator.Send(offerQuery, new System.Threading.CancellationToken());

                Logger.Log(LogLevel.Information, "Showing result of query {0} at {1}", result, DateTime.Now);

                return null;
            }
            catch (Exception e)
            {
                Logger.LogError("Error occured in {0}, method: {1}; Time: {2};", nameof(AttractionController), nameof(Get), DateTime.Now);
                return null;
            }

        }

        // GET api/<TravelController>/5
        [HttpGet("{id}")]
        public async Task<AttractionDTO> Get(int id)
        {
            GetAttractionByIdQuery query = new GetAttractionByIdQuery(id);
            var result = await Mediator.Send<AttractionDTO>(query, new System.Threading.CancellationToken());
            return result;
        }

        // POST api/<TravelController>
        [HttpPost]
        public async Task<AttractionDTO> Post([FromBody] AttractionInsertRequest insertRequest)
        {
            CreateAttractionCommand command = new CreateAttractionCommand(insertRequest);
            Logger.LogInformation($"Creating {nameof(Attraction)}");
            var result = await Mediator.Send(command, new System.Threading.CancellationToken());
            Logger.LogInformation("Log result {0}", result);
            return result;
        }

        // PUT api/<TravelController>/5
        [HttpPut]
        public async Task<AttractionDTO> Put([FromRoute] object id, [FromBody] AttractionInsertRequest updateRequest)
        {
            var query = new GetAttractionByIdQuery(id);
            var targetObject = await Mediator.Send<AttractionDTO>(query, new System.Threading.CancellationToken());
            if (targetObject != null)
            {

                var updateCommand = new UpdateAttractionCommand(id, updateRequest);
                var result = await Mediator.Send<AttractionDTO>(updateCommand, new System.Threading.CancellationToken());

                return result;

            }
            return null;
        }

        // DELETE api/<TravelController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(object id)
        {
            var deleteCommand = new DeleteAttractionCommand(id);
            var result = await Mediator.Send<object>(deleteCommand, new System.Threading.CancellationToken());
            return Ok(result);
        }
    }
}
