using KnowledgeHubPortal.WebApplication.Models;
using KnowledgeHubPortal.WebApplication.Models.Data;
using KnowledgeHubPortal.WebApplication.Models.Domain;
using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {

        IKHPortalRepository repo = null;

        public UsersController(IKHPortalRepository repository)
        {
            repo = repository;
        }
        //[OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            List<ApplicationUser> users = repo.GetUsers();
            return View(users);
        }
        public ActionResult Edit(string id)
        {
            ApplicationUser user = repo.GetUserByID(id);
            return View(user);  
        }
        [HttpPost]
        public ActionResult Edit(ApplicationUser user)
        {
            repo.EditUserByID(user.Id, user);
            string msg = $"{user.Email} has been edited successfully!!";
            TempData["Message"] = msg;

            return RedirectToAction("Index", "Users");   
        }
        public ActionResult Delete(string id)
        {
            ApplicationUser user = repo.GetUserByID(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Delete(ApplicationUser user)
        {
            repo.DeleteUserByID(user.Id);
            string msg = $"{user.Email} has been deleted successfully!!";
            TempData["Message"] = msg;

            return RedirectToAction("Index", "Users");
        }
    }
}