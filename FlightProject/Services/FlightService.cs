using AutoMapper;
using FlightProject.DTO;
using FlightProject.Models;
using FlightProject.Repository;
using Microsoft.Identity.Client;

namespace FlightProject.Services
{
    public class FlightService : IFlightService
    {
        private IMapper _mapper;
        private IFlightRepository _flightRepository;
        public FlightService(IMapper mapper, IFlightRepository flightRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
        }

        public async Task<List<FlightDTO>> GetFlights()
        {
            var flights = await _flightRepository.GetFlights();
            var mapFlights = _mapper.Map<List<FlightDTO>>(flights);

            return mapFlights;
        }

        public async Task<FlightDTO> AddFlight(FlightDTO flightDTO)
        {
            var flights = _mapper.Map<Flight>(flightDTO);
            await _flightRepository.AddFlight(flights);

            return flightDTO;
        }

        public async Task<UpdateFlightDTO> UpdateFlight(string FlightNo, UpdateFlightDTO updateFlightDTO)
        {
            var flights = _mapper.Map<Flight>(updateFlightDTO);
            await _flightRepository.UpdateFlight(FlightNo, flights);

            return updateFlightDTO;
        }

        public async Task<Flight> DeleteFlight(string FlightNo)
        {
           
           return await _flightRepository.DeleteFlight(FlightNo);

        }
    }
}
