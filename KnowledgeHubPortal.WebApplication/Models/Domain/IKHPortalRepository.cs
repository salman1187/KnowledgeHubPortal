using KnowledgeHubPortal.WebApplication.Models.Data;
using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.WebApplication.Models.Domain
{
    public interface IKHPortalRepository
    {
        List<Category> GetCategories();
        void AddCategory(Category category);
        Category GetCategoryByID(int id);
        void EditCategoryByID(int id, Category category);
        void DeleteCategoryByID(int id);
        List<URL> GetApprovedUrls();
        List<URL> GetUrlsToReview();
        void AddUrl(URL url);
        void ApproveUrlByID(int id);
        void DeleteUrlByID(int id); 
    }
}
