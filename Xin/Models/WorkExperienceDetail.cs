using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Xin.Models
{
    public class WorkExperienceDetail
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string WEDescription { get; set; }

        [Display(Name = "WorkExperience")]
        public int WorkExperienceId { get; set; }
        [ForeignKey("WorkExperienceId")]
        public virtual WorkExperience WorkExperience { get; set; }
    }
}
