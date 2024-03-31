using AirlineManagementWebApplication.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineManagementWebApplication.Models.Domain.ViewModels
{
    public class FlightScheduleRouteViewModel
    {
        public FlightSchedule TheFlightSchedule { get; set; }
        public FlightRoute TheFlightRoute { get; set; }
        public List<Flight> Flights { get; set; }
    }
    public class FlightRouteViewModel
    {
        public int FlightRouteId { get; set; }
        public string DisplayInfo { get; set; }
    }

}