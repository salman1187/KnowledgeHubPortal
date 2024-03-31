using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirlineManagementWebApplication.Models.Domain.Entities
{
    public class Airline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AirlineId { get; set; }  
        public string AirlineCode { get; set; }
        public byte[] AirlineLogo { get; set; }
        public string AirlineName { get; set; }
        public string AirlineCountry { get; set; }
        public virtual List<Flight> TheFlights { get; set; } = new List<Flight>();
    }
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }   
        public string FlightName { get; set;}
        public int AirlineId { get; set; }
        public List<int> TheFlightCapacitiesId { get; set; }
        public virtual List<FlightCapacity> TheFlightCapacities { get; set; } = new List<FlightCapacity>(); 
        public virtual FlightRoute TheFlightRoute { get; set; }
    }
    public class FlightCapacity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightCapacityId { get; set; }
        public int FlightClassId { get; set; }
        public virtual FlightClass TheFlightClass { get; set; }
        public int Seats { get; set; }
    }
    public class FlightClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightClassId { get; set; }
        public string FlightClassType { get; set; }
        public virtual FlightCost TheFlightCost { get; set; }
    }
    public class FlightCost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightCostId { get; set; }
        public double CostPerSet { get; set; }
        public string CurrencyCode { get; set; }
        public int FlightClassId { get; set; }
        public int TheFlightRouteId { get; set; }   
        public virtual FlightRoute TheFlightRoute { get; set; } 
    }
    public class FlightRoute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightRouteId { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public double FlightDurationInMins { get; set; }
        public int FlightId { get; set; }
        public int RouteId { get; set; }
        public int FlightScheduleId { get; set; }
        public virtual List<FlightCost> TheFlightCosts { get; set; }
        public List<int> FlightCostIds { get; set; }
    }
    public class FlightSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightScheduleId { get; set; }
        public DateTime FlightDepartureDate { get; set; }
        public DateTime FlightArrivalDate { get; set; }
        public virtual List<FlightRoute> TheFlightRoutes { get; set; }
    }
    public class Route
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RouteId { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }   
        public virtual City FromCity { get; set; }
        public virtual City ToCity { get; set; }
        public double DistanceInKms { get; set; }
        public virtual List<FlightRoute> TheFlightRoutes { get; set; }
    }
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public virtual Country TheCountry { get; set; }
    }
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}