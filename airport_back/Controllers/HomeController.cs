using airport_back.DomainModels;
using airport_back.Models;
using airport_back.Table;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace airport_back.Controllers
{
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context, IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
        }

        [HttpPost("storeDepartments")]
        [ProducesResponseType(typeof(AirportDomainModel), StatusCodes.Status200OK)]
        public async Task<AirportDomainModel> AddStoreDepartments([FromBody] AirportDomainModel a, CancellationToken cancellationToken)
        {
            _context.airports.Add(_mapper.Map<Airport>(a));
            await _context.SaveChangesAsync(cancellationToken);
            return a;
        }
    }
}