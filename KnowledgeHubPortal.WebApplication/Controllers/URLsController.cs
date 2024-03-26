using KnowledgeHubPortal.WebApplication.Models.Data;
using KnowledgeHubPortal.WebApplication.Models.Domain;
using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebApplication.Controllers
{
    public class URLsController : Controller
    {
        // GET: URLs
        public ActionResult Index()
        {
            KnowledgeHubDbContext db = new KnowledgeHubDbContext();
            return View(db.URLs.ToList());
        }
        public ActionResult SubmitURL()
        {
            KnowledgeHubDbContext db = new KnowledgeHubDbContext();
            List<Category> categories = db.Categories.ToList();
            var viewModel = new URLCategoryViewModel { CategoryModel = categories, URLModel = new URL() };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult SubmitURL(URLCategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // If model state is not valid, return the view with validation errors
                return View(viewModel);
            }

            viewModel.URLModel.DatePosted = DateTime.UtcNow;

            KnowledgeHubDbContext db = new KnowledgeHubDbContext();
            viewModel.URLModel.TheCategory = db.Categories.Find(viewModel.URLModel.CategoryID);
            db.URLs.Add(viewModel.URLModel);
            db.SaveChanges();

            string msg = $"{viewModel.URLModel.UrlTitle} has been created successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index", "URLs");
        }

    }
}