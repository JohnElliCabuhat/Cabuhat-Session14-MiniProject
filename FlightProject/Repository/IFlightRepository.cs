using FlightProject.Models;

namespace FlightProject.Repository
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetFlights();
        Task AddFlight(Flight flight);
        Task UpdateFlight(string FlightNo, Flight flight);
        Task<Flight> DeleteFlight(string FlightNo);
    }
}