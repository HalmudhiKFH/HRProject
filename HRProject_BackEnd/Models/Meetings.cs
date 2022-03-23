using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRProject_BackEnd.Models
{
    public class Meetings
    {
        [Key]
        public int MeetingID { get; set; }
        [Required]
        public string MeetingTitle { get; set; }
        [Required]
        public DateTime MeetingStartTime { get; set; }
        public DateTime MeetingEndTime { get; set; }

        public string Location { get; set; }
        public Committees CommitteeID { get; set; }
        public ICollection<Committees> Committees { get; set; }
        public Meetings()
        {
            Committees = new Collection<Committees>();
        }
    }
}
