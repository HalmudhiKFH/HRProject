using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRProject_BackEnd.Models
{
    public class UserInfoes
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }
        [Required]
        public string EmployeeID { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }
        [Required]
        public bool IsEmployee { get; set; }
        public ICollection<Committees> Committees { get; set; }
    }
}
