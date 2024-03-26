using KnowledgeHubPortal.WebApplication.Models.Data;
using KnowledgeHubPortal.WebApplication.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            KnowledgeHubDbContext db = new KnowledgeHubDbContext();
            return View(db.Categories.ToList());
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            KnowledgeHubDbContext db = new KnowledgeHubDbContext();
            db.Categories.Add(category);
            db.SaveChanges();
            string msg = $"{category.CategoryName} has been created successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
            
        }
        public ActionResult EditCategory(int id)
        {
            KnowledgeHubDbContext db = new KnowledgeHubDbContext();
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            KnowledgeHubDbContext db = new KnowledgeHubDbContext();
            Category c = db.Categories.Find(category.CategoryID);
            // Update the category properties
            c.CategoryName = category.CategoryName;
            c.CategoryDescription = category.CategoryDescription;

            db.SaveChanges();

            string msg = $"{category.CategoryName} has been edited successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            KnowledgeHubDbContext db = new KnowledgeHubDbContext();
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        public ActionResult DeleteCategory(Category category)
        {
            KnowledgeHubDbContext db = new KnowledgeHubDbContext();
            Category c = db.Categories.Find(category.CategoryID);
            db.Categories.Remove(c);
            db.SaveChanges();

            string msg = $"{c.CategoryName} has been deleted successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
        }
    }
}