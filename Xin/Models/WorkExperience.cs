using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Xin.Models
{
    public class WorkExperience
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Position { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string JobType { get; set; }
        [Required]
        [Display(Name = "User")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
