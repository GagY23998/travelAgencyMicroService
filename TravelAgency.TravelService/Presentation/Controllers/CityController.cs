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
    public class CityController : ControllerBase
    {
        public IMediator Mediator { get; }
        public ILogger<CityController> Logger { get; }

        public CityController(IMediator mediator, ILogger<CityController> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }

        [HttpGet("GetCountryCities")]
        public async Task<IEnumerable<CityDTO>> Get(int countryId){
            try
            {
                CitySearchRequest searchRequest = new CitySearchRequest{
                    CountryId = countryId
                };
                GetCitiesQuery offerQuery = new GetCitiesQuery(searchRequest);

                Logger.Log(LogLevel.Information, "Sending message to {0} handler at {1}", nameof(City), DateTime.Now);

                var result = await Mediator.Send(offerQuery, new System.Threading.CancellationToken());

                Logger.Log(LogLevel.Information, "Showing result of query {0} at {1}", result, DateTime.Now);

                return result;
            }
            catch (Exception e)
            {
                Logger.LogError("Error occured in {0}, method: {1}; Time: {2};", nameof(CityController), nameof(Get), DateTime.Now);
                return null;
            }
        }

        // GET: api/<TravelController>
        [HttpGet]
        public async Task<IEnumerable<CityDTO>> Get(CitySearchRequest searchRequest)
        {
            try
            {
                GetCitiesQuery offerQuery = new GetCitiesQuery(searchRequest);

                Logger.Log(LogLevel.Information, "Sending message to {0} handler at {1}", nameof(City), DateTime.Now);

                var result = await Mediator.Send(offerQuery, new System.Threading.CancellationToken());

                Logger.Log(LogLevel.Information, "Showing result of query {0} at {1}", result, DateTime.Now);

                return null;
            }
            catch (Exception e)
            {
                Logger.LogError("Error occured in {0}, method: {1}; Time: {2};", nameof(CityController), nameof(Get), DateTime.Now);
                return null;
            }

        }

        // GET api/<TravelController>/5
        [HttpGet("{id}")]
        public async Task<CityDTO> Get(object id)
        {
            GetCityByIdQuery query = new GetCityByIdQuery(id);
            var result = await Mediator.Send<CityDTO>(query, new System.Threading.CancellationToken());
            return result;
        }

        // POST api/<TravelController>
        [HttpPost]
        public async Task<CityDTO> Post([FromBody] CityInsertRequest insertRequest)
        {
            CreateCityCommand command = new CreateCityCommand(insertRequest);
            Logger.LogInformation($"Creating {nameof(City)}");
            var result = await Mediator.Send(command, new System.Threading.CancellationToken());
            Logger.LogInformation("Log result {0}", result);
            return result;
        }

        // PUT api/<TravelController>/5
        [HttpPut]
        public async Task<CityDTO> Put([FromRoute] object id, [FromBody] CityInsertRequest updateRequest)
        {
            var query = new GetCityByIdQuery(id);
            var targetObject = await Mediator.Send<CityDTO>(query, new System.Threading.CancellationToken());
            if (targetObject != null)
            {

                var updateCommand = new UpdateCityCommand(id, updateRequest);
                var result = await Mediator.Send<CityDTO>(updateCommand, new System.Threading.CancellationToken());

                return result;

            }
            return null;
        }

        // DELETE api/<TravelController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(object id)
        {
            var deleteCommand = new DeleteCityCommand(id);
            var result = await Mediator.Send<object>(deleteCommand, new System.Threading.CancellationToken());
            return Ok(result);
        }
        [HttpGet("/topDestinations")]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetTopDestinations()
        {
            Logger.LogInformation("Setting query request for top city destinations");
            var query = new GetCitiesQuery(new CitySearchRequest { });
            var result = await Mediator.Send(query, new System.Threading.CancellationToken());

            if (result.Any())
            {

                return Ok(result.OrderBy(_ => _.Rating).Take(5).ToList());
            }
            return BadRequest("Currently, top destinations don't exit");
        }
    }
}
