using KnowledgeHubPortal.WebApplication.Models.Domain;
using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace KnowledgeHubPortal.WebApplication.Models.Data
{
    public class KnowledgeHubDbContext : DbContext
    {
        public KnowledgeHubDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<URL> URLs { get; set; }
    }
}