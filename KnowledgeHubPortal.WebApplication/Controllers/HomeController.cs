using KnowledgeHubPortal.WebApplication.Models;
using KnowledgeHubPortal.WebApplication.Models.Domain;
using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        IKHPortalRepository repo = null;
        public HomeController(IKHPortalRepository repository)
        {
            repo = repository;
        }
        public ActionResult Index()
        {
            // Populate your lists here
            var usersList = repo.GetUsers();
            var urlsList = repo.GetApprovedUrls();
            var categoriesList = repo.GetCategories();

            // Populate lists (usersList, urlsList, categoriesList) with appropriate data

            // Pass lists to ViewBag only if they are not null
            if (usersList != null)
                ViewBag.UsersList = usersList;
            if (urlsList != null)
                ViewBag.UrlsList = urlsList;
            if (categoriesList != null)
                ViewBag.CategoriesList = categoriesList;

            // Return your View
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}