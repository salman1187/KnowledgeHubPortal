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
        IKHPortalRepository repo = null;
        
        public CategoriesController(IKHPortalRepository repository)
        {
            repo = repository;
        }
        //[OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            return View(repo.GetCategories());
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

            repo.AddCategory(category);
            string msg = $"{category.CategoryName} has been created successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
            
        }
        public ActionResult EditCategory(int id)
        {
            Category category = repo.GetCategoryByID(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView("_EditCategory", category);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            repo.EditCategoryByID(category.CategoryID, category);

            string msg = $"{category.CategoryName} has been edited successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            Category category = repo.GetCategoryByID(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeleteCategory", category);
        }
        [HttpPost]
        public ActionResult DeleteCategory(Category category)
        {
            Category c = repo.GetCategoryByID(category.CategoryID);
            repo.DeleteCategoryByID(category.CategoryID);

            string msg = $"{c.CategoryName} has been deleted successfully!!";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
        }
    }
}