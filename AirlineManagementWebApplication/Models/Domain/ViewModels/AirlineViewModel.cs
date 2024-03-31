using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AirlineManagementWebApplication.Models.Domain.ViewModels
{
    public class AirlineViewModel
    {
        public int AirlineId { get; set; }

        [Required]
        public string AirlineCode { get; set; }

        public HttpPostedFileBase AirlineLogoFile { get; set; }

        [Required]
        public string AirlineName { get; set; }

        [Required]
        public string AirlineCountry { get; set; }
    }
    
}
