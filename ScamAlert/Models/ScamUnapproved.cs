using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScamAlert.Models
{
    public class ScamUnapproved
    {
        [Display(Name="Scam ID")]
        public int scamId;
        [Display(Name = "Name")]
        public String scamName;
        [Display(Name = "Description")]
        public String description;
        [Display(Name = "Date Posted")]
        public DateTime datePosted;
        [Display(Name = "Reported By")]
        public string userName;
    }
}