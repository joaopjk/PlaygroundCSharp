using AirlineWeb.Data;
using AirlineWeb.Dtos;
using AirlineWeb.MessageBus;
using AirlineWeb.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AirlineWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly AirlineDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public FlightsController(AirlineDbContext context,
            IMapper mapper,
            IMessageBusClient messageBusClient)
        {
            _context = context;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet("{flightCode}", Name = "GetFlightDetailByCode")]
        public ActionResult<FlightDetailReadDto> GetFlightDetailByCode(string flightCode)
        {
            var flight = _context.FlightDetails.FirstOrDefault(x => x.FlightCode == flightCode);
            if (flight == null)
                return NotFound();

            return Ok(_mapper.Map<FlightDetailReadDto>(flight));
        }

        [HttpPost]
        public ActionResult<FlightDetailReadDto> CreateFlight(FlightDetailCreateDto request)
        {
            var flight = _context.FlightDetails.FirstOrDefault(x => x.FlightCode == request.FlightCode);
            if (flight == null)
            {
                var flightDetailModel = _mapper.Map<FlightDetail>(request);

                try
                {
                    _context.Add(flightDetailModel);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return CreatedAtRoute(nameof(CreateFlight),
                    new { flightCode = _mapper.Map<FlightDetailReadDto>(flightDetailModel).FlightCode });
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<FlightDetailReadDto> UpdateFligh(int id, FlightDetailUpdateDto request)
        {
            var flight = _context.FlightDetails.FirstOrDefault(x => x.Id == id);
            if (flight == null)
                return NotFound();

            decimal oldPrice = flight.Price;

            _mapper.Map(request, flight);
            try
            {
                _context.SaveChanges();

                if (oldPrice != flight.Price)
                {
                    var message = new NotificationMessageDto
                    {
                        WebhookType = "pricechange",
                        OldPrice = oldPrice,
                        NewPrice = flight.Price,
                        FlightCode = flight.FlightCode
                    };
                    _messageBusClient.SendMessage(message);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
