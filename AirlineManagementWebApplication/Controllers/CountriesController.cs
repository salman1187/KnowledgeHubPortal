using AirlineManagementWebApplication.Models.Data;
using AirlineManagementWebApplication.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineManagementWebApplication.Controllers
{
    public class CountriesController : Controller
    {
        AirlinePortalDbContext db = new AirlinePortalDbContext();   
        // GET: Countries
        public ActionResult Index()
        {
            return View(db.Countries.ToList());
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Country country)
        {
            db.Countries.Add(country);
            db.SaveChanges();
            string msg = $"{country.CountryName} has been created successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }
        [HttpPost]
        public ActionResult Edit(Country country)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Country c = db.Countries.Find(country.CountryId);
            c.CountryName = country.CountryName;
            db.SaveChanges();
            string msg = $"{country.CountryName} has been edited successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }
        [HttpPost]
        public ActionResult Delete(Country country)
        {
            string name = country.CountryName;
            Country c = db.Countries.Find(country.CountryId);
            db.Countries.Remove(c);
            db.SaveChanges();
            string msg = $"{name} has been deleted successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
        }
    }
}