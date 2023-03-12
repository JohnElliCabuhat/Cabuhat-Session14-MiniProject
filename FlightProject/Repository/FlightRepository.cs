using FlightProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private FlightDbContext _flightDBContext;
        public FlightRepository(FlightDbContext flightDbContext)
        {
            _flightDBContext = flightDbContext;
        }

        public async Task<List<Flight>> GetFlights()
        {
            return await _flightDBContext.Flights.ToListAsync();
        }

        public async Task AddFlight (Flight flight)
        {
            await _flightDBContext.Flights.AddAsync(flight);
            await _flightDBContext.SaveChangesAsync();
        }

        public async Task UpdateFlight (string FlightNo, Flight flight)
        {
            var flights = _flightDBContext.Flights.SingleOrDefault(fl => fl.FlightNo == FlightNo);
            flights.ToAirport = flight.ToAirport;
            flights.FromAirport = flight.FromAirport;
            flights.DepTime = flight.DepTime;
            flights.ArrTime = flight.ArrTime;
            flights.RouteNo = flight.RouteNo;
            await _flightDBContext.SaveChangesAsync();
        }

        public async Task<Flight> DeleteFlight(string FlightNo)
        {
            var flights = await _flightDBContext.Flights.SingleOrDefaultAsync(fl => fl.FlightNo == FlightNo);
            _flightDBContext.Flights.Remove(flights);
            await _flightDBContext.SaveChangesAsync();

            return flights;

            
        }
    }
}
