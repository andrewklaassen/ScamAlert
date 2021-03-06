//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScamAlert.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ScamReport
    {
        public int scamReportId { get; set; }
        public int scamId { get; set; }
        public int byUserId { get; set; }
        [Required(ErrorMessage = "Please enter in a report")]
        public string report { get; set; }
        public System.DateTime timePosted { get; set; }
    
        public virtual Scam Scam { get; set; }
        public virtual User User { get; set; }
    }
}
