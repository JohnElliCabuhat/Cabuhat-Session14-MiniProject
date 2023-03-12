using FlightProject.DTO;
using FlightProject.Models;
using FlightProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace FlightProject.Controllers
{
    [Route("api/flights")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private IFlightService _flightService;
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        [Route("GetAllFlights")]
        public async Task<ActionResult<List<FlightDTO>>> GetFlights()
        {
            var flights = await _flightService.GetFlights();
            if (flights == null)
                return NotFound();

            return Ok(flights);
                 
        }

        [HttpPost]
        [Route("AddFlight")]
        public async Task<ActionResult<FlightDTO>> AddFlight(FlightDTO flightDTO)
        {
            try
            {
                var flights = await _flightService.AddFlight(flightDTO);
                return Ok(flights);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateFlight")]
        public async Task<ActionResult<UpdateFlightDTO>>UpdateFlight(string FlightNo, UpdateFlightDTO updateFlightDTO)
        {
            try
            {
                var flights = await _flightService.UpdateFlight(FlightNo, updateFlightDTO);
                return Ok(flights);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteFlights")]
        public async Task<ActionResult<Flight>> DeleteFlight(string FlightNo)
        {
            try
            {
                var flights =  await _flightService.DeleteFlight(FlightNo);
                return Ok(flights);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
