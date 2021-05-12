using TravelAgency.BookingService.Application.Queries;
using System.Collections.Generic;
using MediatR;
using TravelAgency.BookingService.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TravelAgency.BookingService.Application.Commands;
using System;
using MassTransit;
using MessageBroker.Consumers;
using MessageBroker.Contracts;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgency.BookingService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<IMediator> logger;
        private readonly IPublishEndpoint publishEndpoint;
        private readonly IBus bus;

        public BookingController(IMediator mediator, ILogger<IMediator> logger, IPublishEndpoint publishEndpoint, IBus bus)
        {
            this.mediator = mediator;
            this.logger = logger;
            this.publishEndpoint = publishEndpoint;
            this.bus = bus;
        }
        // GET: api/<ValuesController>
        [HttpPost("GetBookings")]
        public async Task<IEnumerable<BookingDTO>> Post([FromBody]BookingSearchRequest searchRequest )
        {
            logger.Log(LogLevel.Information, "Accessing booking service");

            GetBookingsQuery query = new GetBookingsQuery(searchRequest);
            var result = await mediator.Send(query, new System.Threading.CancellationToken());

            logger.Log(LogLevel.Information, "Returning booking service result");
            return result;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<BookingDTO> Get(Guid id)
        {
            GetBookingByIdQuery query = new GetBookingByIdQuery(id);

            var result = await mediator.Send(query, new System.Threading.CancellationToken());
            return result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<BookingDTO> Post([FromBody] BookingCreateRequest createRequest)
        {
            logger.Log(LogLevel.Information,"Accessing booking create service");
            CreateBookingCommand booking = new CreateBookingCommand(createRequest);
            var result = await mediator.Send(booking,new System.Threading.CancellationToken());

            return result;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<BookingDTO> Put([FromRoute] Guid id, [FromBody] BookingCreateRequest bookingCreateRequest)
        {
            UpdateBookingCommand command = new UpdateBookingCommand(id, bookingCreateRequest);
            var result = await mediator.Send(command, new System.Threading.CancellationToken());

            return result;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            DeleteBookingCommand command = new DeleteBookingCommand(id);
            var result = await mediator.Send(command, new System.Threading.CancellationToken());

            return result;
        }
        [HttpGet("TopOffers")]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetTopOffers()
        {
            return null;
        }
        
        [HttpPost("CreateBooking")]
        public async Task<ActionResult<BookingDTO>> CreateBooking()
        {
            return null;
        }
    }
}
