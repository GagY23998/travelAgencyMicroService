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
using TravelAgency.TravelService.Infrastructure.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgency.TravelService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportCompanyController : ControllerBase
    {
        public IMediator Mediator { get; }
        public ILogger<TransportCompanyController> Logger { get; }

        public TransportCompanyController(IMediator mediator, ILogger<TransportCompanyController> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<TransportCompanyDTO>> Get(TransportCompanySearchRequest searchRequest)
        {
            try
            {
                GetTransportCompaniesQuery offerQuery = new GetTransportCompaniesQuery(searchRequest);

                Logger.Log(LogLevel.Information, "Sending message to {0} handler at {1}", nameof(TransportCompany), DateTime.Now);

                var result = await Mediator.Send(offerQuery, new System.Threading.CancellationToken());

                Logger.Log(LogLevel.Information, "Showing result of query {0} at {1}", result, DateTime.Now);

                return null;
            }
            catch (Exception e)
            {
                Logger.LogError("Error occured in {0}, method: {1}; Time: {2};", nameof(TransportCompanyController), nameof(Get), DateTime.Now);
                return null;
            }

        }

        // GET api/<TravelController>/5
        [HttpGet("{id}")]
        public async Task<TransportCompanyDTO> Get(int id)
        {
            GetTransportCompanyByIdQuery query = new GetTransportCompanyByIdQuery(id);
            var result = await Mediator.Send<TransportCompanyDTO>(query, new System.Threading.CancellationToken());
            return result;
        }

        // POST api/<TravelController>
        [HttpPost]
        public async Task<TransportCompanyDTO> Post([FromBody] TransportCompanyInsertRequest insertRequest)
        {
            CreateTransportCompanyCommand command = new CreateTransportCompanyCommand(insertRequest);
            Logger.LogInformation($"Creating {nameof(TransportCompany)}");
            var result = await Mediator.Send(command, new System.Threading.CancellationToken());
            Logger.LogInformation("Log result {0}", result);
            return result;
        }

        // PUT api/<TravelController>/5
        [HttpPut]
        public async Task<TransportCompanyDTO> Put([FromRoute] object id, [FromBody] TransportCompanyInsertRequest updateRequest)
        {
            var query = new GetTransportCompanyByIdQuery(id);
            var targetObject = await Mediator.Send<TransportCompanyDTO>(query, new System.Threading.CancellationToken());
            if (targetObject != null)
            {

                var updateCommand = new UpdateTransportCompanyCommand(id, updateRequest);
                var result = await Mediator.Send<TransportCompanyDTO>(updateCommand, new System.Threading.CancellationToken());

                return result;

            }
            return null;
        }

        // DELETE api/<TravelController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(object id)
        {
            var deleteCommand = new DeleteTransportCompanyCommand(id);
            var result = await Mediator.Send<object>(deleteCommand, new System.Threading.CancellationToken());
            return Ok(result);
        }

        [HttpGet("/topRatings")]
        public async Task<ActionResult<IEnumerable<TransportCompanyDTO>>> GetRatings()
        {
            var result = await this.Get(new TransportCompanySearchRequest{
                
            });
            Logger.LogInformation($"Call returned {result.Count()} results");

            return Ok(result.OrderBy(_=>_.Rating).Take(5).AsEnumerable());
        }

    }
}
