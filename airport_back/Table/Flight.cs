using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airport_back.Table
{
    public class Flight
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }

        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }

        public int AirportId { get; set; }
        public Airport Airport { get; set; }

        public int PlaneId { get; set; }
        public Plane Plane { get; set; }

        public List<Passenger> Passengers { get; set; }
    }
}