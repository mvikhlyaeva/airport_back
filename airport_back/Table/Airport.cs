using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airport_back.Table
{
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Flight> Flights { get; set; }
    }
}