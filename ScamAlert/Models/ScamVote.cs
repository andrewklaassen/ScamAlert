using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScamAlert.Models
{
    public class ScamVote
    {
        public int scamId;
        public String scamName;
        public String description;
        public DateTime datePosted;
        public int firstReportedBy;
        public int votes;
        public int vote;
    }
}