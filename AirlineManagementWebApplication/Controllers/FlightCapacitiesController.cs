using AirlineManagementWebApplication.Models.Data;
using AirlineManagementWebApplication.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineManagementWebApplication.Controllers
{
    public class FlightCapacitiesController : Controller
    {
        AirlinePortalDbContext db = new AirlinePortalDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            var fclasses = db.FlightClasses.ToList();
            ViewBag.FlightClasses = fclasses;   
            return View();
        }
        [HttpPost]
        public ActionResult Add(FlightCapacity fcapacity)
        {
            fcapacity.TheFlightClass = db.FlightClasses.Find(fcapacity.FlightClassId);
            db.FlightCapacities.Add(fcapacity);
            db.SaveChanges();
            var fclasses = db.FlightClasses.ToList();
            ViewBag.FlightClasses = fclasses;
            TempData["SuccessMessage"] = $"Capacity with {fcapacity.Seats} in {fcapacity.TheFlightClass.FlightClassType} class have been added successfully!";

            return RedirectToAction("Add");
        }
    }
}