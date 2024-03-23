using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.WebApplication.Models.Domain
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}