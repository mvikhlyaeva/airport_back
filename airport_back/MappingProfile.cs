using airport_back.DomainModels;
using airport_back.Table;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airport_back
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Airport, AirportDomainModel>();
            CreateMap<AirportDomainModel, Airport>();

            CreateMap<Plane, PlaneDomainModel>();
            CreateMap<PlaneDomainModel, Plane>();

            CreateMap<Pilot, PilotDomainModel>();
            CreateMap<PilotDomainModel, Pilot>();

            CreateMap<Flight, FlightDomainModel>();
            CreateMap<FlightDomainModel, Flight>();

            //CreateMap<Passenger, PassengerDomainModel>();
            //CreateMap<PassengerDomainModel, Passenger>();
        }
    }
}