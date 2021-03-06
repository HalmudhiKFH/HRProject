using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRProject_BackEnd.Models
{
    public class Committee
    {
        [Key]
        [Required]
        public int CommitteeID { get; set; }
        [Required]
        [StringLength(255)]
        public string CommitteeTitle { get; set; }
        public int ChairmanID { get; set; }
        public int SecretaryID { get; set; }
        public DateTime CommitteeStartDate { get; set; }
        public DateTime CommitteeEndDate { get; set; }
        public ICollection<UserInfo> UserInfoes { get; set; }
        public ICollection<Meeting> Meetings { get; set; }
    }
}
