﻿using System;
using System.Collections.Generic;

namespace FlightProject.Models;

public partial class Flight
{
    public string FlightNo { get; set; } = null!;

    public string? FromAirport { get; set; }

    public string? ToAirport { get; set; }

    public DateTime? DepTime { get; set; }

    public DateTime? ArrTime { get; set; }

    public int? RouteNo { get; set; }
}