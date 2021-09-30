using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airport_back.DomainModels
{
    public class PlaneDomainModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
    }
}