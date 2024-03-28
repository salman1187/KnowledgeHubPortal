using KnowledgeHubPortal.WebApplication.Models.Data;
using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
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
        string GetUserEmailByID(int id);
        List<ApplicationUser> GetUsers();
        ApplicationUser GetUserByID(string id);
        void EditUserByID(string id, ApplicationUser user);  
        void DeleteUserByID(string id);
        List<string> GetUserRoles(string userId);
        IdentityResult AddUserToRole(string userId, string roleName);
        IdentityResult RemoveUserFromRole(string userId, string roleName);
        List<ApplicationUser> GetUsersInRole(string roleName);
    }
}
