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

        [HttpGet("pilot/{pilotId}")]
        [ProducesResponseType(typeof(PilotDomainModel), StatusCodes.Status200OK)]
        async public Task<PilotDomainModel> Getpilot(int pilotId)
        {
            var pilot = await _context.pilots.FirstOrDefaultAsync(pl => pl.Id == pilotId);

            if (pilot == null) throw new Exception("Пилота не существует");
            return _mapper.Map<PilotDomainModel>(pilot);
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
        public async Task<Pilot> DeleteStoreDepartments(int pilotId)
        {
            var pilot = await _context.pilots.Include(pl => pl.Flights)
                            .FirstOrDefaultAsync(pl => pl.Id == pilotId);

            if (pilot == null)
                throw new Exception("Ошибка! Отсутсвует такая запись в бд");
            if (pilot.Flights.Any())
                throw new Exception("Ошибка! У пилота есть зависимые рейсы!");

            _context.pilots.Remove(pilot);
            await _context.SaveChangesAsync();
            return pilot;
        }
    }
}