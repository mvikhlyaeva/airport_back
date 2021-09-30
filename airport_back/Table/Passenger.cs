using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace airport_back.Table
{
    public class Passenger
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}