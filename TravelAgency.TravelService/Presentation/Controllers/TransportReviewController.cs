using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Application.Commands;
using TravelAgency.TravelService.Application.Queries;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportReviewController : ControllerBase
    {
        public ILogger<TransportReviewController> Logger { get; }
        public IMediator Mediator { get; }

        public TransportReviewController(ILogger<TransportReviewController> logger, IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }
        // GET: api/<TravelController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IEnumerable<TransportReviewDTO>> Get([FromBody] TransportReviewSearchRequest searchRequest)
        {
            try
            {
                GetTransportReviewQuery offerQuery = new GetTransportReviewQuery(searchRequest);

                Logger.Log(LogLevel.Information, "Sending message to {0} handler at {1}", nameof(TransportReview), DateTime.Now);

                var result = await Mediator.Send(offerQuery, new System.Threading.CancellationToken());

                Logger.Log(LogLevel.Information, "Showing result of query {0} at {1}", result, DateTime.Now);

                return result;
            }
            catch (Exception e)
            {
                Logger.LogError("Error {0} occured in {1}, method: {2}; Time: {3};",e.Message, nameof(TransportReviewController), nameof(Get), DateTime.Now);
                return null;
            }

        }

        // GET api/<TravelController>/5
        [HttpGet("{id}")]
        public async Task<TransportReviewDTO> Get(object id)
        {
            GetTransportReviewByIdQuery query = new GetTransportReviewByIdQuery((int)id);
            var result = await Mediator.Send<TransportReviewDTO>(query, new System.Threading.CancellationToken());
            return result;
        }

        // POST api/<TravelController>
        [HttpPost]
        public async Task<TransportReviewDTO> Post([FromBody] TransportReviewInsertRequest insertRequest)
        {
            CreateTransportReviewCommand command = new CreateTransportReviewCommand(insertRequest);
            Logger.LogInformation($"Creating {nameof(TransportReview)}");
            var result = await Mediator.Send(command, new System.Threading.CancellationToken());
            Logger.LogInformation("Log result {0}", result);
            return result;
        }

        // PUT api/<TravelController>/5
        [HttpPut]
        public async Task<TransportReviewDTO> Put([FromRoute] object id, [FromBody] TransportReviewInsertRequest updateRequest)
        {
            var query = new GetTransportReviewByIdQuery((int)id);
            var targetObject = await Mediator.Send<TransportReviewDTO>(query, new System.Threading.CancellationToken());
            if (targetObject != null)
            {

                var updateCommand = new UpdateTransportReviewCommand((int)id, updateRequest);
                var result = await Mediator.Send<TransportReviewDTO>(updateCommand, new System.Threading.CancellationToken());

                return result;

            }
            return null;
        }

        // DELETE api/<TravelController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCommand = new DeleteTransportReviewCommand(id);
            var result = await Mediator.Send<int>(deleteCommand, new System.Threading.CancellationToken());
            return Ok(result);
        }
    }
}
