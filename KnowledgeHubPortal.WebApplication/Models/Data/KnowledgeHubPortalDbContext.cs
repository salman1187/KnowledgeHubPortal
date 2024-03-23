using KnowledgeHubPortal.WebApplication.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.WebApplication.Models.Data
{
    public class KnowledgeHubDbContext : DbContext
    {
        public KnowledgeHubDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}