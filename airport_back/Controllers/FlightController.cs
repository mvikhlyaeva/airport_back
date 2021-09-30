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
    public class FlightController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public FlightController(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("flight")]
        [ProducesResponseType(typeof(List<Flight>), StatusCodes.Status200OK)]
        public List<Flight> GetFlights()
        {
            var flights = _context.flights.Include(fl => fl.Plane).ToList();
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
    }
}