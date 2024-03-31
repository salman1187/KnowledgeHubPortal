using AirlineManagementWebApplication.Models.Data;
using AirlineManagementWebApplication.Models.Domain.Entities;
using AirlineManagementWebApplication.Models.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.Mvc;

namespace AirlineManagementWebApplication.Controllers
{
    public class FlightCostsController : Controller
    {
        AirlinePortalDbContext db = new AirlinePortalDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            var fclasses = db.FlightClasses.ToList();   
            ViewBag.FlightClasses = fclasses;

            var flightRoutes = db.FlightRoutes.ToList();

            var flightRouteViewModels = flightRoutes.Select(fr => new FlightRouteViewModel
            {
                FlightRouteId = fr.FlightRouteId,
                DisplayInfo = $"{getFlightName(fr.FlightId)} {getFlightDepDate(fr.FlightScheduleId).ToString("MM/dd/yyyy")} {getFromCity(fr.RouteId)} to {getToCity(fr.RouteId)}"
            }).ToList();

            ViewBag.FlightRoutes = flightRouteViewModels;

            return View();
        }
        [HttpPost]
        public ActionResult Add(List<FlightCost> fcosts)
        {
            for(int i = 1; i<fcosts.Count; i++)
            {
                fcosts[i].CurrencyCode = fcosts[0].CurrencyCode;
                fcosts[i].TheFlightRouteId = fcosts[0].TheFlightRouteId;
            }
            foreach(var cost in fcosts)
            {
                var froute = db.FlightRoutes.Find(cost.TheFlightRouteId);
                cost.TheFlightRoute = froute;
                db.FlightCosts.Add(cost);
                db.SaveChanges();

                froute.TheFlightCosts.Add(cost);
                // Ensure FlightCostIds is initialized before adding elements
                if (froute.FlightCostIds == null)
                {
                    froute.FlightCostIds = new List<int>();
                }
                froute.FlightCostIds.Add(cost.FlightCostId);
                db.SaveChanges();
            }


            var fclasses = db.FlightClasses.ToList();
            ViewBag.FlightClasses = fclasses;

            var flightRoutes = db.FlightRoutes.ToList();

            var flightRouteViewModels = flightRoutes.Select(fr => new FlightRouteViewModel
            {
                FlightRouteId = fr.FlightRouteId,
                DisplayInfo = $"{getFlightName(fr.FlightId)} {getFlightDepDate(fr.FlightScheduleId).ToString("MM/dd/yyyy")} {getFromCity(fr.RouteId)} to {getToCity(fr.RouteId)}"
            }).ToList();

            ViewBag.FlightRoutes = flightRouteViewModels;

            return View();
        }
        private string getFlightName(int id)
        {
            var fname = (from f in db.Flights
                        where f.FlightId == id
                        select f.FlightName).FirstOrDefault();

            return fname;
        }
        private DateTime getFlightDepDate(int id)
        {
            var date = (from fs in db.FlightSchedules
                       where fs.FlightScheduleId == id
                       select fs.FlightDepartureDate).FirstOrDefault();
            return date;
        }
        private string getFromCity(int id)
        {
            var city = (from r in db.Routes
                       where r.RouteId == id
                       select r.FromCity.CityName).FirstOrDefault();
            return city;
        }
        private string getToCity(int id)
        {
            var city = (from r in db.Routes
                        where r.RouteId == id
                        select r.ToCity.CityName).FirstOrDefault();
            return city;
        }
    }
}