using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TravelAgency.TravelService.Application.Commands;
using TravelAgency.TravelService.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelAgency.TravelService.Domain.DTOs;
using TravelAgency.TravelService.Infrastructure.Helper;
using Newtonsoft.Json;
using Dapper;
using System.Text;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Application.Commands.Handlers;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace TravelAgency.TravelService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportOfferController : ControllerBase
    {
        public IMediator Mediator { get; }
        public ILogger<TransportOfferController> Logger { get; }

        public TransportOfferController(IMediator mediator, ILogger<TransportOfferController> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }
        [HttpGet("GetLatestOffers")]
        public async Task<IEnumerable<TransportOfferDTO>> Get()
        {
            // try
            // {
                System.Console.WriteLine("Entered GetOffer without any parameters");
                TransportOfferSearchRequest searchRequest = new TransportOfferSearchRequest
                {
                    StartDate = DateTime.MinValue,
                    FinishDate = DateTime.MaxValue
                };
                GetTransportOfferQuery offerQuery = new GetTransportOfferQuery(searchRequest);

                Logger.Log(LogLevel.Information, "Sending message to {0} handler at {1}", nameof(TransportOffer), DateTime.Now);

                var result = await Mediator.Send<IEnumerable<TransportOfferDTO>>(offerQuery, new System.Threading.CancellationToken());

                Logger.Log(LogLevel.Information, "Showing result of query {0} at {1}", result, DateTime.Now);

                return result;
            // }
            // catch (Exception e)
            // {
            //     Logger.LogError("Error occured in {0}, method: {1}; Time: {2};", nameof(TransportOfferController), nameof(Get), DateTime.Now);
            //     Logger.LogError(e.Message);
            //     return null;
            // }
        }

        // GET: api/<TravelController>
        [HttpPost("GetOffers")]
        public async Task<IEnumerable<TransportOfferDTO>> Post([FromBody]TransportOfferSearchRequest searchRequest)
        {
            try
            {
                Logger.LogInformation("Receieved request with cityId: {0}",searchRequest.CityId);
                GetTransportOfferQuery offerQuery = new GetTransportOfferQuery(searchRequest);
               
                Logger.Log(LogLevel.Information, "Sending message to {0} handler at {1}",nameof(TransportOffer) ,DateTime.Now);
                
                var result = await Mediator.Send(offerQuery, new System.Threading.CancellationToken());
                
                Logger.Log(LogLevel.Information, "Showing result of query {0} at {1}",result, DateTime.Now);

                return result;
            }catch(Exception e)
            {
                Logger.LogError("Error: {0} occured in {1}, method: {2}; Time: {3};",e.Message,nameof(TransportOfferController),nameof(Get) , DateTime.Now);
                return null;
            }

        }

        // GET api/<TravelController>/5
        [HttpGet("{id}")]
        public async Task<TransportOfferDTO> Get(object id)
        {
            GetTransportOfferByIdQuery query = new GetTransportOfferByIdQuery(id);
            var result = await Mediator.Send<TransportOfferDTO>(query, new System.Threading.CancellationToken());
            return result;
        }

        // POST api/<TravelController>
        [HttpPost]
        public async Task<TransportOfferDTO> Post([FromBody] TransportOfferInsertRequest insertRequest)
        {
            CreateTransportOfferCommand command = new CreateTransportOfferCommand(insertRequest);
            Logger.LogInformation($"Creating {nameof(TransportOffer)}");
            var result = await Mediator.Send(command, new System.Threading.CancellationToken());
            Logger.LogInformation("Log result {0}", result);
            return result;
        }

        // PUT api/<TravelController>/5
        [HttpPut]
        public async Task<TransportOfferDTO> Put([FromRoute]object id, [FromBody] TransportOfferInsertRequest updateRequest)
        {
            var query = new GetTransportOfferByIdQuery(id);
            var targetObject = await Mediator.Send<TransportOfferDTO>(query,new System.Threading.CancellationToken());
            if (targetObject != null)
            {

                var updateCommand = new UpdateTransportOfferCommand(id,updateRequest);
                var result = await Mediator.Send<TransportOfferDTO>(updateCommand, new System.Threading.CancellationToken());

                return result;

            }
            return null;
        }

        // DELETE api/<TravelController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(object id)
        {
            var deleteCommand = new DeleteTransportOfferCommand(id);
            var result = await Mediator.Send<object>(deleteCommand,new System.Threading.CancellationToken());
            return Ok(result);
        }
    }
}
