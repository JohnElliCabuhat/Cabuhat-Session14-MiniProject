using System.Runtime.CompilerServices;
using Moq;
using FlightProject.Services;
using FlightProject.DTO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.AspNetCore.Mvc;
using FlightProject.Models;

namespace FlightTestProject
{
    public class UnitTest1
    {
        private Mock<IFlightService> flightService;
        public UnitTest1()
        {
            flightService = new Mock<IFlightService>();
        }

        [Fact]
        public void GetFlight_Success_ReturnsNotNull()
        {
            DateTime odate = DateTime.Now;
            var flights = new List<FlightDTO>()
            {
                new FlightDTO()
                {
                    FlightNo= "TestFlt",
                    FromAirport= "TestFrom",
                    ToAirport= "TestTo",
                    DepTime=odate,
                    ArrTime=odate,
                    RouteNo=123467
                }
            };
            flightService.Setup(fl => fl.GetFlights()).Returns(Task.Run(() => flights));
            var FlightController = new FlightProject.Controllers.FlightController(flightService.Object);

            
            var okObjectResult = FlightController.GetFlights().Result.Result as OkObjectResult;
            var flightListResult = okObjectResult.Value as List<FlightDTO>;

            
            Assert.NotNull(flightListResult);
        }

        [Fact]
        public void GetFlights_Success_ReturnsIsType()
        {
            DateTime odate = DateTime.Now;
            var flights = new List<FlightDTO>()
            {
                new FlightDTO()
                {
                    FlightNo= "TestFlt",
                    FromAirport= "TestFrom",
                    ToAirport= "TestTo",
                    DepTime=odate,
                    ArrTime=odate,
                    RouteNo=123467
                }
            };
            flightService.Setup(fl => fl.GetFlights()).Returns(Task.Run(() => flights));
            var FlightController = new FlightProject.Controllers.FlightController(flightService.Object);

            
            var okObjectResult = FlightController.GetFlights().Result.Result as OkObjectResult;
            var infoListResult = okObjectResult.Value as List<FlightDTO>;

            
            Assert.IsType<List<FlightDTO>>(infoListResult);
        }

        
    }
}