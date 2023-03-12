namespace FlightProject.DTO
{
    public class FlightDTO
    {
        public string FlightNo { get; set; } = null!;

        public string? FromAirport { get; set; }

        public string? ToAirport { get; set; }

        public DateTime? DepTime { get; set; }

        public DateTime? ArrTime { get; set; }

        public int? RouteNo { get; set; }
    }
}
