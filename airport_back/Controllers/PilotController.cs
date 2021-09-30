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
    public class PilotController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public PilotController(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("pilot")]
        [ProducesResponseType(typeof(List<PilotDomainModel>), StatusCodes.Status200OK)]
        public List<PilotDomainModel> GetPilots()
        {
            var pilots = _context.pilots.OrderBy(p => p.Id).ToList();
            return _mapper.Map<List<PilotDomainModel>>(pilots);
        }

        [HttpPost("pilot")]
        [ProducesResponseType(typeof(PilotDomainModel), StatusCodes.Status200OK)]
        public async Task<PilotDomainModel> AddPilot([FromBody] PilotDomainModel newPilot, CancellationToken cancellationToken)
        {
            _context.pilots.Add(_mapper.Map<Pilot>(newPilot));
            await _context.SaveChangesAsync(cancellationToken);
            return newPilot;
        }

        [HttpPut("pilot")]
        [ProducesResponseType(typeof(Plane), StatusCodes.Status200OK)]
        public async Task<Pilot> UpdatePilot(PilotDomainModel pilot, CancellationToken cancellationToken)
        {
            //var planedb = _context.planes.FirstOrDefault(planes => planes.Id == plane.Id);
            //if (planedb == null)
            //    throw new Exception();

            var newPilot = _mapper.Map<Pilot>(pilot);

            _context.pilots.Update(newPilot);
            await _context.SaveChangesAsync(cancellationToken);
            return newPilot;
        }

        [HttpDelete("pilot/{pilotId}")]
        [ProducesResponseType(typeof(PilotDomainModel), StatusCodes.Status200OK)]
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