using AirlineManagementWebApplication.Models.Data;
using AirlineManagementWebApplication.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineManagementWebApplication.Controllers
{
    public class FlightClassesController : Controller
    {
        AirlinePortalDbContext db = new AirlinePortalDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            // Check if there's a success message in TempData and pass it to the view
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Add(FlightClass fclass)
        {
            if (ModelState.IsValid)
            {
                db.FlightClasses.Add(fclass);
                db.SaveChanges();

                // Add success message to TempData
                TempData["SuccessMessage"] = $"{fclass.FlightClassType} has been added successfully!";

                return RedirectToAction("Add");
            }

            return View(fclass);
        }

    }
}