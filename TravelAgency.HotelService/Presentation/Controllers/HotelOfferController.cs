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

namespace TravelAgency.HotelOfferService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelOfferController : ControllerBase
    {
        public IMediator Mediator { get; }

        public HotelOfferController(IMediator mediator)
        {
            Mediator = mediator;
        }
        [HttpGet("GetLatestOffers")]
        public async Task<IEnumerable<HotelOfferDTO>> Get()
        {
            HotelOfferSearchRequest request= new HotelOfferSearchRequest(){
                StartDate = DateTime.Now.AddDays(-50),
                ExpirationDate= DateTime.Now.AddDays(50)
            };
            GetHotelOffersQuery query = new GetHotelOffersQuery(request);

            var result = await Mediator.Send(query, new System.Threading.CancellationToken());

            return result;

        }
        // GET: api/<HotelOfferController>
        [HttpPost("GetOffers")]
        public async Task<IEnumerable<HotelOfferDTO>> Post([FromBody] HotelOfferSearchRequest HotelOfferSearchRequest)
        {

            GetHotelOffersQuery query = new GetHotelOffersQuery(HotelOfferSearchRequest);

            var result = await Mediator.Send(query, new System.Threading.CancellationToken());

            return result;

        }
        // GET: api/<HotelOfferController>/GetLatestOffers
        
        // GET api/<HotelOfferController>/5
        [HttpGet("{id}")]
        public async Task<HotelOfferDTO> Get(int id)
        {
            GetHotelOfferByIdQuery query = new GetHotelOfferByIdQuery(id);

            var result = await Mediator.Send(query, new System.Threading.CancellationToken());

            return result;
        }

        // POST api/<HotelOfferController>
        [HttpPost]
        public async Task<HotelOfferDTO> Post([FromBody] HotelOfferCreateRequest HotelOfferCreateRequest)
        {
            CreateHotelOfferCommand command = new CreateHotelOfferCommand(HotelOfferCreateRequest);

            var result = await Mediator.Send(command, new System.Threading.CancellationToken());

            return result;
        }

        // PUT api/<HotelOfferController>/5
        [HttpPut("{id}")]
        public async Task<HotelOfferDTO> Put([FromRoute]object id, [FromBody] HotelOfferCreateRequest createRequest)
        {
            UpdateHotelOfferCommand command = new UpdateHotelOfferCommand(id, createRequest);

            var result = await Mediator.Send(command, new System.Threading.CancellationToken());


            return result;
        }

        // DELETE api/<HotelOfferController>/5
        [HttpDelete("{id}")]
        public async Task<HotelOfferDTO> Delete(object id)
        {
            DeleteHotelOfferCommand command = new DeleteHotelOfferCommand((int)id);

            var result = await Mediator.Send(command, new System.Threading.CancellationToken());

            return result;
        }
    }
}
