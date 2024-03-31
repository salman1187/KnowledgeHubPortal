using AirlineManagementWebApplication.Models.Data;
using AirlineManagementWebApplication.Models.Domain.Entities;
using AirlineManagementWebApplication.Models.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace AirlineManagementWebApplication.Controllers
{
    public class FlightSchedulesController : Controller
    {
        AirlinePortalDbContext db = new AirlinePortalDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            var routes = db.Routes.ToList().Select(r => new
            {
                RouteId = r.RouteId,
                RouteDescription = $"{r.FromCity.CityName} to {r.ToCity.CityName}"
            }).ToList();

            ViewBag.Routes = new SelectList(routes, "RouteId", "RouteDescription");
            var flights = db.Flights.ToList();

            return View(new FlightScheduleRouteViewModel
            {
                TheFlightSchedule = new FlightSchedule(),
                TheFlightRoute = new FlightRoute(),
                Flights = flights
            });
        }

        [HttpPost]
        public ActionResult Add(FlightScheduleRouteViewModel viewModel)
        {
            
                db.FlightSchedules.Add(viewModel.TheFlightSchedule);
                db.SaveChanges();

                int flightScheduleId = viewModel.TheFlightSchedule.FlightScheduleId;

                viewModel.TheFlightRoute.FlightScheduleId = flightScheduleId;

                // Assign the FlightId to the FlightRoute
                viewModel.TheFlightRoute.FlightId = viewModel.TheFlightRoute.FlightId; // Ensure FlightId is properly assigned

                db.FlightRoutes.Add(viewModel.TheFlightRoute);
                db.SaveChanges();

            var routes = db.Routes.ToList().Select(r => new
            {
                RouteId = r.RouteId,
                RouteDescription = $"{r.FromCity.CityName} to {r.ToCity.CityName}"
            }).ToList();

            ViewBag.Routes = new SelectList(routes, "RouteId", "RouteDescription");

            var flights = db.Flights.ToList();
            return RedirectToAction("Add", "FlightCosts");
        }

    }
}