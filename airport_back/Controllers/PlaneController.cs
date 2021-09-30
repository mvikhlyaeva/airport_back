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
    public class PlaneController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public PlaneController(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("planes")]
        [ProducesResponseType(typeof(List<PlaneDomainModel>), StatusCodes.Status200OK)]
        public List<PlaneDomainModel> GetAllStoreDepartments()
        {
            var planes = _context.planes.OrderBy(p => p.Id).ToList();
            return _mapper.Map<List<PlaneDomainModel>>(planes);
        }

        [HttpPost("plane")]
        [ProducesResponseType(typeof(PlaneDomainModel), StatusCodes.Status200OK)]
        public async Task<PlaneDomainModel> AddPlane([FromBody] PlaneDomainModel newPlane, CancellationToken cancellationToken)
        {
            _context.planes.Add(_mapper.Map<Plane>(newPlane));
            await _context.SaveChangesAsync(cancellationToken);
            return newPlane;
        }

        [HttpPut("plane")]
        [ProducesResponseType(typeof(Plane), StatusCodes.Status200OK)]
        public async Task<Plane> UpdatePlane(PlaneDomainModel plane, CancellationToken cancellationToken)
        {
            //var planedb = _context.planes.FirstOrDefault(planes => planes.Id == plane.Id);
            //if (planedb == null)
            //    throw new Exception();

            var newPlane = _mapper.Map<Plane>(plane);

            _context.planes.Update(newPlane);
            await _context.SaveChangesAsync(cancellationToken);
            return newPlane;
        }

        [HttpDelete("plane/{planeId}")]
        [ProducesResponseType(typeof(PlaneDomainModel), StatusCodes.Status200OK)]
        async public Task<Plane> DeleteStoreDepartments(int planeId)
        {
            var plane = await _context.planes.Include(pl => pl.Flights)
                .FirstOrDefaultAsync(pl => pl.Id == planeId);

            if (plane == null)
                throw new Exception("Ошибка! Отсутсвует такая запись в бд");
            if (plane.Flights.Any())
                throw new Exception("Ошибка! У самолета есть зависимые рейсы!");

            _context.planes.Remove(plane);
            await _context.SaveChangesAsync();
            return plane;
        }
    }
}