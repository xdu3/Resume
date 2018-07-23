using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Xin.Models
{
    public class DesDetails
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Detail { get; set; }
        [Required]
        [Display(Name = "Description")]
        public int DescriptionId { get; set; }

        [ForeignKey("DescriptionId")]
        public virtual Description Description { get; set; }
    }
}

