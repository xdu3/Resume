using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Xin.Models
{
    public class Skill
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string SkillName { get; set; }

        public string LevelYear { get; set; }
        [Required]
        [Display(Name = "User")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
