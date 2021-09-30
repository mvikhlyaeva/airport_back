using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airport_back.DomainModels
{
    public class FlightDomainModel
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }

        public int PilotId { get; set; }

        public int AirportId { get; set; }

        public int PlaneId { get; set; }
    }
}