using AirlineManagementWebApplication.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirlineManagementWebApplication.Models.Data
{
    public class AirlinePortalDbContext : DbContext
    {
        public AirlinePortalDbContext() : base("DefaultConnection")
        {
            
        }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightCapacity> FlightCapacities { get; set; }
        public DbSet<FlightClass> FlightClasses { get; set; }
        public DbSet<FlightCost> FlightCosts { get; set; }
        public DbSet<FlightRoute> FlightRoutes { get; set; }
        public DbSet<FlightSchedule> FlightSchedules { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }   
    }
}