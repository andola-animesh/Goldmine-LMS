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
    public class LeadNote
    {
        public LeadNote()
        { 
            LeadTbls = new List<SelectListItem>();
        }
        public int NoteId { get; set; }
        public int LeadId { get; set; }
        public string Attachment { get; set; }
        public string Comment { get; set; }
        public int CreatedBy{ get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ContactPerson { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public int Value { get; set; }
        public int AssignUser { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        
        public IEnumerable<SelectListItem> LeadTbls { get; set; }
    }
}