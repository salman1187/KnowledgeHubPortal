using AirlineManagementWebApplication.Models.Data;
using AirlineManagementWebApplication.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineManagementWebApplication.Controllers
{
    public class CitiesController : Controller
    {
        AirlinePortalDbContext db = new AirlinePortalDbContext();
        // GET: Cities
        public ActionResult Index()
        {
            return View(db.Cities.ToList());
        }
        public ActionResult Add()
        {
            var countryList = db.Countries.ToList();
            if (countryList != null)
                ViewBag.CountryList = countryList;
            return View();
        }
        [HttpPost]
        public ActionResult Add(City city)
        {
            
                // Retrieve the selected country from the database based on the selected CountryId
                var selectedCountry = db.Countries.FirstOrDefault(c => c.CountryId == city.TheCountry.CountryId);

                // Assign the selected country to the city's TheCountry property
                city.TheCountry = selectedCountry;

                // Add the city to the database and save changes
                db.Cities.Add(city);
                db.SaveChanges();

                // Repopulate ViewBag with the list of countries
                ViewBag.CountryList = db.Countries.ToList();
            string msg = $"{city.CityName} has been added successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
                        
        }
        public ActionResult Edit(int id)
        {
            City city = db.Cities.Find(id);
            var countryList = db.Countries.ToList();
            ViewBag.CountryList = countryList;

            return View(city);
        }

        [HttpPost]
        public ActionResult Edit(City city)
        {
            City c = db.Cities.Find(city.CityId);
            c.CityName = city.CityName;
            c.CityCode = city.CityCode;
            c.TheCountry = db.Countries.Find(city.TheCountry.CountryId); // Find the selected country from the database
            db.SaveChanges();

            string msg = $"{city.CityName} has been edited successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }
        [HttpPost]
        public ActionResult Delete(City city)
        {
            string name = city.CityName;
            City c = db.Cities.Find(city.CityId);
            db.Cities.Remove(c);
            db.SaveChanges();
            string msg = $"{name} has been deleted successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
        }
    }
}