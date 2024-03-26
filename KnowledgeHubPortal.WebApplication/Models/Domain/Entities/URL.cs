using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.WebApplication.Models.Domain.Entities
{
    public class URL
    {
        public int UrlID { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Enter atleast 2 characters")]
        [MaxLength(100)]
        public string UrlTitle { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Enter atleast 2 characters")]
        [Url]
        public string Url { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Enter atleast 2 characters")]
        [MaxLength(100)]
        public string UrlDescription { get; set; }
        public int CategoryID { get; set; }
        public virtual Category TheCategory { get; set; } 
        public string PostedBy { get; set; }   
        public DateTime DatePosted { get; set; }
        public bool IsApproved { get; set; }

    }
    public class URLCategoryViewModel
    {
        public URL URLModel { get; set; }
        public List<Category> CategoryModel { get; set; }
    }
    public class URLCategoryListViewModel
    {
        public List<URL> URLList { get; set; }
        public List<Category> CategoryList { get; set; }
    }

}

