using AirlineManagementWebApplication.Models.Data;
using AirlineManagementWebApplication.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineManagementWebApplication.Controllers
{
    public class FlightsController : Controller
    {
        AirlinePortalDbContext db = new AirlinePortalDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            var airlines = db.Airlines.ToList();
            ViewBag.Airlines = airlines;    
            var flightCapacities = db.FlightCapacities.ToList();
            ViewBag.FlightCapacities = flightCapacities;    
            return View();
        }
        [HttpPost]
        public ActionResult Add(Flight flight)
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            flight.TheFlightCapacities = new List<FlightCapacity>();
            foreach (var fcap in flight.TheFlightCapacitiesId)
            {
                flight.TheFlightCapacities.Add(db.FlightCapacities.Find(fcap));
            }
            db.Flights.Add(flight);
            db.SaveChanges();

            var airlines = db.Airlines.ToList();
            ViewBag.Airlines = airlines;
            var flightCapacities = db.FlightCapacities.ToList();
            ViewBag.FlightCapacities = flightCapacities;
            TempData["SuccessMessage"] = $"Capacity with {flight.FlightName} has been added successfully!";
            return View();
        }
    }
}