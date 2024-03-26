using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.WebApplication.Models.Domain
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Enter atleast 2 characters")]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        [Required]
        [MinLength(10,ErrorMessage = "Enter atleast 10 characters")]
        [MaxLength(500)]
        public string CategoryDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}