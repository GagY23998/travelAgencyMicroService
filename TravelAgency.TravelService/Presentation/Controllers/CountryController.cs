using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelAgency.TravelService.Application.Commands;
using TravelAgency.TravelService.Application.Queries;
using TravelAgency.TravelService.Application.Queries.Handlers;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        public IMediator Mediator { get; }
        public ILogger<CountryController> Logger { get; }

        public CountryController(IMediator mediator, ILogger<CountryController> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }

        [HttpGet("GetCountries")]
        public async Task<IEnumerable<CountryDTO>> Get()
        {
            try
            {
                GetCountriesQuery offerQuery = new GetCountriesQuery(new CountrySearchRequest());

                Logger.Log(LogLevel.Information, "Sending message to {0} handler at {1}", nameof(Country), DateTime.Now);

                var result = await Mediator.Send(offerQuery, new System.Threading.CancellationToken());

                Logger.Log(LogLevel.Information, "Showing result of query {0} at {1}", result, DateTime.Now);

                return result;
            }
            catch (Exception e)
            {
                Logger.LogError("Error occured in {0}, method: {1}; Time: {2};", nameof(CountryController), nameof(Get), DateTime.Now);
                return null;
            }

        }

        // GET: api/<TravelController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IEnumerable<CountryDTO>> Get([FromBody] CountrySearchRequest searchRequest)
        {
            try
            {
                GetCountriesQuery offerQuery = new GetCountriesQuery(searchRequest);

                Logger.Log(LogLevel.Information, "Sending message to {0} handler at {1}", nameof(Country), DateTime.Now);

                var result = await Mediator.Send(offerQuery, new System.Threading.CancellationToken());

                Logger.Log(LogLevel.Information, "Showing result of query {0} at {1}", result, DateTime.Now);

                return result;
            }
            catch (Exception e)
            {
                Logger.LogError("Error occured in {0}, method: {1}; Time: {2};", nameof(CountryController), nameof(Get), DateTime.Now);
                return null;
            }

        }

        // GET api/<TravelController>/5
        [HttpGet("{id}")]
        public async Task<CountryDTO> Get(int id)
        {
            GetCountryByIdQuery query = new GetCountryByIdQuery(id);
            var result = await Mediator.Send<CountryDTO>(query, new System.Threading.CancellationToken());
            return result;
        }

        // POST api/<TravelController>
        [HttpPost]
        public async Task<CountryDTO> Post([FromBody] CountryInsertRequest insertRequest)
        {
            CreateCountryCommand command = new CreateCountryCommand(insertRequest);
            Logger.LogInformation($"Creating {nameof(Country)}");
            var result = await Mediator.Send(command, new System.Threading.CancellationToken());
            Logger.LogInformation("Log result {0}", result);
            return result;
        }

        // PUT api/<TravelController>/5
        [HttpPut]
        public async Task<CountryDTO> Put([FromRoute] int id, [FromBody] CountryInsertRequest updateRequest)
        {
            var query = new GetCountryByIdQuery(id);
            var targetObject = await Mediator.Send<CountryDTO>(query, new System.Threading.CancellationToken());
            if (targetObject != null)
            {

                var updateCommand = new UpdateCountryCommand(id, updateRequest);
                var result = await Mediator.Send<CountryDTO>(updateCommand, new System.Threading.CancellationToken());

                return result;

            }
            return null;
        }

        // DELETE api/<TravelController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCommand = new DeleteCountryCommand(id);
            var result = await Mediator.Send<object>(deleteCommand, new System.Threading.CancellationToken());
            return Ok(result);
        }
    }

}
