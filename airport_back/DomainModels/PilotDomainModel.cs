﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airport_back.DomainModels
{
    public class PilotDomainModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}