using FlightProject.DTO;
using FlightProject.Models;

namespace FlightProject.Services
{
    public interface IFlightService
    {
        Task<List<FlightDTO>> GetFlights();
        Task<FlightDTO> AddFlight(FlightDTO flightDTO);
        Task<UpdateFlightDTO> UpdateFlight(string FlightNo, UpdateFlightDTO updateFlightDTO);
        Task<Flight> DeleteFlight(string FlightNo);
    }
}