using AirlineManagementWebApplication.Models.Data;
using AirlineManagementWebApplication.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace AirlineManagementWebApplication.Controllers
{
    public class RoutesController : Controller
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
            var cities = db.Cities.ToList();
            ViewBag.Cities = cities;    
            return View();
        }
        [HttpPost]
        public ActionResult Add(Route route)
        {
            db.Routes.Add(route);
            route.FromCity = db.Cities.Find(route.FromCityId);
            route.ToCity = db.Cities.Find(route.ToCityId);
            db.SaveChanges();
            ViewBag.SuccessMessage = $"Route from {route.FromCity.CityName} to {route.ToCity.CityName} has been added successfully!";
            var cities = db.Cities.ToList();
            ViewBag.Cities = cities;
            return View();
        }
    }
}