using KnowledgeHubPortal.WebApplication.Models.Domain;
using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace KnowledgeHubPortal.WebApplication.Models.Data
{
    public class KHPortalRepository : IKHPortalRepository
    {
        KnowledgeHubDbContext db = new KnowledgeHubDbContext();
        ApplicationDbContext userdb = new ApplicationDbContext();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void AddUrl(URL url)
        {
            db.URLs.Add(url);
            db.SaveChanges();
        }

        public void ApproveUrlByID(int id)
        {
            var urlToApprove = db.URLs.Find(id);
            urlToApprove.IsApproved = true;
            db.SaveChanges();
        }

        public void DeleteCategoryByID(int id)
        {
            var cat = db.Categories.Find(id);   
            db.Categories.Remove(cat);
            db.SaveChanges();
        }

        public void DeleteUrlByID(int id)
        {
            var cat = db.URLs.Find(id);
            db.URLs.Remove(cat);
            db.SaveChanges();
        }

        public void DeleteUserByID(string id)
        {
            ApplicationUser u = userdb.Users.Find(id);
            userdb.Users.Remove(u);
            userdb.SaveChanges();
        }

        public void EditCategoryByID(int id, Category category)
        {
            var c = db.Categories.Find(id);
            c.CategoryName = category.CategoryName;
            c.CategoryDescription = category.CategoryDescription;
            db.SaveChanges();
        }

        public void EditUserByID(string id, ApplicationUser user)
        {
            ApplicationUser u = userdb.Users.Find(id);
            u.Email = user.Email;
            u.PhoneNumber = user.PhoneNumber;
            userdb.SaveChanges();
        }

        public List<URL> GetApprovedUrls()
        {
            return db.URLs.Where(a => a.IsApproved == true).ToList();
        }

        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryByID(int id)
        {
            return db.Categories.Find(id);
        }

        public List<URL> GetUrlsToReview()
        {
            return db.URLs.Include("TheCategory").Where(a => a.IsApproved == false).ToList();
        }

        public ApplicationUser GetUserByID(string id)
        {
            ApplicationUser user = userdb.Users.Find(id);
            return user;
        }

        public string GetUserEmailByID(int id)
        {
            var email = (from urls in db.URLs
                         where urls.UrlID == id
                         select urls.PostedBy).FirstOrDefault(); // Execute the query and retrieve the first result

            return email; // Return the retrieved email address
        }

        public List<ApplicationUser> GetUsers()
        {
            return userdb.Users.ToList();
        }
        public List<string> GetUserRoles(string userId)
        {
            var user = _userManager.FindById(userId);
            if (user != null)
            {
                return _userManager.GetRoles(userId).ToList();
            }
            return new List<string>();
        }

        // Add a user to a role
        public IdentityResult AddUserToRole(string userId, string roleName)
        {
            return _userManager.AddToRole(userId, roleName);
        }

        // Remove a user from a role
        public IdentityResult RemoveUserFromRole(string userId, string roleName)
        {
            return _userManager.RemoveFromRole(userId, roleName);
        }

        // Get all users in a role
        public List<ApplicationUser> GetUsersInRole(string roleName)
        {
            var role = _roleManager.FindByName(roleName);
            if (role != null)
            {
                var usersInRole = _userManager.Users.Where(u => u.Roles.Any(r => r.RoleId == role.Id)).ToList();
                return usersInRole;
            }
            return new List<ApplicationUser>();
        }
    }
}