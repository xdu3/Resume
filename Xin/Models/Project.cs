using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Xin.Models
{
    public class Project
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string TechniqueUsed { get; set; }
        public string Description { get; set; }
        public string result { get; set; }
        public string Url { get; set; }
        [Required]
        [Display(Name = "User")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
