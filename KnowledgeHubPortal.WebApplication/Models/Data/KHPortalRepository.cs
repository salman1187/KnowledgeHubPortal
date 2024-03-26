using KnowledgeHubPortal.WebApplication.Models.Domain;
using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
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

        public void EditCategoryByID(int id, Category category)
        {
            var c = db.Categories.Find(id);
            c.CategoryName = category.CategoryName;
            c.CategoryDescription = category.CategoryDescription;
            db.SaveChanges();
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
    }
}