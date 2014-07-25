using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoldenLMS.Models;
using System.ComponentModel.DataAnnotations;

namespace GoldenLMS.Models
{
    public class LeadUser
       
    {
        public LeadUser()
        { 
            UserTbls = new List<SelectListItem>();
        }
      
            public int Id { get; set; }
            [Required(ErrorMessage = "Title is required")]
            public string Title { get; set; }
            [Required(ErrorMessage = "Contact Person is required")]
            public string ContactPerson { get; set; }
            [Required(ErrorMessage = "Email is required")]
            [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
            public string EmailId { get; set; }

            public string ContactNo { get; set; }
            
            public int Value { get; set; }
            public string Status { get; set; }
            [DisplayName("UserName")]
            public int AssignUser { get; set; }
            public string Name { get; set; }
            public IEnumerable<SelectListItem> UserTbls { get; set; }
        }
    }
