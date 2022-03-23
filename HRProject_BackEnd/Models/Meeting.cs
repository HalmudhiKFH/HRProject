using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRProject_BackEnd.Models
{
    public class Meeting
    {
        [Key]
        public int MeetingID { get; set; }
        [Required]
        public string MeetingTitle { get; set; }
        [Required]
        public DateTime MeetingStartTime { get; set; }
        public DateTime MeetingEndTime { get; set; }

        public string Location { get; set; }

        // Foreign key 
        [Display(Name = "Committee")]
        public int CommitteeID { get; set; }

        [ForeignKey("CommitteeID")]
        public virtual Committee Committee { get; set; }
    }
}
