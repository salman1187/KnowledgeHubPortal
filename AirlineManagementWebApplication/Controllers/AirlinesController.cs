using AirlineManagementWebApplication.Models.Data;
using AirlineManagementWebApplication.Models.Domain.Entities;
using AirlineManagementWebApplication.Models.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace AirlineManagementWebApplication.Controllers
{
    public class AirlinesController : Controller
    {
        AirlinePortalDbContext db = new AirlinePortalDbContext();
        public ActionResult Index()
        {
            var airlines = db.Airlines.ToList(); // Assuming 'db' is your DbContext instance
            return View(airlines);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(AirlineViewModel model)
        {
            
                if (model.AirlineLogoFile != null && model.AirlineLogoFile.ContentLength > 0)
                {
                    using (var binaryReader = new BinaryReader(model.AirlineLogoFile.InputStream))
                    {
                        var airline = new Airline
                        {
                            AirlineCode = model.AirlineCode,
                            AirlineLogo = binaryReader.ReadBytes(model.AirlineLogoFile.ContentLength),
                            AirlineName = model.AirlineName,
                            AirlineCountry = model.AirlineCountry
                        };
                        db.Airlines.Add(airline);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index", "Airlines");
            
        }
        public ActionResult Edit(int id)
        {
            Airline airline = db.Airlines.Find(id);
            if (airline == null)
            {
                return HttpNotFound();
            }
            ViewBag.Airline = airline;  
            return View();
        }
        [HttpPost]
        public ActionResult Edit(AirlineViewModel model)
        {
            if (model.AirlineLogoFile != null && model.AirlineLogoFile.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(model.AirlineLogoFile.InputStream))
                {
                    Airline airline = db.Airlines.Find(model.AirlineId);
                    airline.AirlineCode = model.AirlineCode;
                    airline.AirlineLogo = binaryReader.ReadBytes(model.AirlineLogoFile.ContentLength);
                    airline.AirlineName = model.AirlineName;
                    airline.AirlineCountry = model.AirlineCountry;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Airlines");
        }
        public ActionResult Delete(int id)
        {
            Airline airline = db.Airlines.Find(id);
            if (airline == null)
            {
                return HttpNotFound();
            }
            return View(airline);
        }
        [HttpPost]
        public ActionResult Delete(Airline airline)
        {
            string name = airline.AirlineName;
            Airline c = db.Airlines.Find(airline.AirlineId);
            db.Airlines.Remove(c);
            db.SaveChanges();
            string msg = $"{name} has been deleted successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
        }
    }
}