using airport_back.DomainModels;
using airport_back.Table;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace airport_back.Controllers
{
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class FlightController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public FlightController(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(List<Flight>), StatusCodes.Status200OK)]
        public List<Flight> GetFlights()
        {
            var flights = _context.flights.ToList();
            return _mapper.Map<List<Flight>>(flights);
        }

        [HttpPost("flight")]
        [ProducesResponseType(typeof(PilotDomainModel), StatusCodes.Status200OK)]
        public async Task<FlightDomainModel> AddFlight([FromBody] FlightDomainModel newFlight, CancellationToken cancellationToken)
        {
            _context.flights.Add(_mapper.Map<Flight>(newFlight));
            await _context.SaveChangesAsync(cancellationToken);
            return newFlight;
        }

        [HttpPut("flight")]
        [ProducesResponseType(typeof(Flight), StatusCodes.Status200OK)]
        public async Task<Flight> UpdateFlight(FlightDomainModel flight, CancellationToken cancellationToken)
        {
            //var flightdb = _context.flights.FirstOrDefault(fl => fl.Id == flight.Id);
            //if (flightdb == null)
            //    throw new Exception("Невозможно изменить, так как рейса с таким ID нет в базе данных");

            var newFlight = _mapper.Map<Flight>(flight);

            _context.flights.Update(newFlight);
            await _context.SaveChangesAsync(cancellationToken);
            return newFlight;
        }

        [HttpDelete("flight/{flightId}")]
        [ProducesResponseType(typeof(FlightDomainModel), StatusCodes.Status200OK)]
        async public Task<Flight> DeleteFlight(int flightId)
        {
            var flight = await _context.flights.Include(fl => fl.Passengers)
                .FirstOrDefaultAsync(fl => fl.Id == flightId);

            if (flight == null)
                throw new Exception("Ошибка! Отсутсвует такая запись в бд");
            if (flight.Passengers.Any())
                throw new Exception("Ошибка! У рейса есть зависимые самолеты!");

            _context.flights.Remove(flight);
            await _context.SaveChangesAsync();
            return flight;
        }
    }
}