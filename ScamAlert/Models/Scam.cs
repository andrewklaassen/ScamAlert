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
    
    public partial class Scam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Scam()
        {
            this.ScamReports = new HashSet<ScamReport>();
            this.Votes = new HashSet<Vote>();
        }
    
        public int scamId { get; set; }
        public string scamName { get; set; }
        public string description { get; set; }
        public System.DateTime datePosted { get; set; }
        public int firstReportedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScamReport> ScamReports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vote> Votes { get; set; }
        public virtual User User { get; set; }
    }
}