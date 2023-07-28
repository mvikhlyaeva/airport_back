using airport_back.DomainModels;
using airport_back.Table;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace airport_back.Controllers
{
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class ValuesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public ValuesController(ApplicationContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
    }

        //[HttpPost("login")]
        //[ProducesResponseType(typeof(Airport), StatusCodes.Status200OK)]
        //public async Task<List<Airport>> DbSelect([FromBody] Auth Name, CancellationToken cancellationToken)
        //{
        //    // Set DbName for DbManager.
        //    var dbName = Name.Login + Name.Password;
        //    DbManager.DbName = dbName;

        //    dynamic myDynamic = new System.Dynamic.ExpandoObject();
        //    myDynamic.DbName = dbName;
        //    var json = JsonConvert.SerializeObject(myDynamic);
        //    try
        //    {
        //        var airports =  _context.airports.ToList();
        //        return airports;
        //    }
        //    catch
        //    {
        //        throw new Exception("Ошибка! Неверно введен логин или пароль");
        //    }

        //    //return Content(json, "application/json");
        //}
    }

    public class Auth
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public string Db { get; set; }


    }

}
