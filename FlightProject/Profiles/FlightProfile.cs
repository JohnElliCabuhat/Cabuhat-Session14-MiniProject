using AutoMapper;
using FlightProject.DTO;
using FlightProject.Models;

namespace FlightProject.Profiles
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightDTO>();
            CreateMap<FlightDTO, Flight>();
            CreateMap<UpdateFlightDTO, Flight>();
        }
    }
}
