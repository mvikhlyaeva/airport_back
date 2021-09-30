using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airport_back.Table
{
    public class Plane
    {
        public int Id { get; set; }
        public string Model { get; set; }

        public int Capacity { get; set; }

        public List<Flight> Flights { get; set; }
    }
}