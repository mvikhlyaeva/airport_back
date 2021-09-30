using airport_back.DomainModels;
using airport_back.Table;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class AirportController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public AirportController(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("airport")]
        [ProducesResponseType(typeof(List<AirportDomainModel>), StatusCodes.Status200OK)]
        public List<AirportDomainModel> GetAirports()
        {
            var airports = _context.airports.OrderBy(p => p.Id).ToList();
            return _mapper.Map<List<AirportDomainModel>>(airports);
        }

        [HttpPost("airport")]
        [ProducesResponseType(typeof(AirportDomainModel), StatusCodes.Status200OK)]
        public async Task<AirportDomainModel> AddAirport([FromBody] AirportDomainModel newAirport, CancellationToken cancellationToken)
        {
            _context.airports.Add(_mapper.Map<Airport>(newAirport));
            await _context.SaveChangesAsync(cancellationToken);
            return newAirport;
        }

        [HttpPut("airport")]
        [ProducesResponseType(typeof(Airport), StatusCodes.Status200OK)]
        public async Task<Airport> UpdateAirport(AirportDomainModel airport, CancellationToken cancellationToken)
        {
            //var planedb = _context.planes.FirstOrDefault(planes => planes.Id == plane.Id);
            //if (planedb == null)
            //    throw new Exception();

            var newAirport = _mapper.Map<Airport>(airport);

            _context.airports.Update(newAirport);
            await _context.SaveChangesAsync(cancellationToken);
            return newAirport;
        }

        [HttpDelete("airport/{airportId}")]
        [ProducesResponseType(typeof(AirportDomainModel), StatusCodes.Status200OK)]
        public List<Plane> DeleteStoreDepartments(int planeId)
        {
            var plane = _context.planes.ToList();
            //   .Include(pl => pl.Flights).FirstOrDefaultAsync(pl => pl.Id == planeId);
            //if (plane == null)
            //    throw new Exception("Ошибка! Отсутсвует такая запись в бд");
            //if (plane.Flights.Any())
            //    throw new Exception("Ошибка! У данной записи присутствуют зависимости");

            //_context.planes.Remove(plane);
            //await _context.SaveChangesAsync(cancellationToken);
            return plane;
        }
    }
}