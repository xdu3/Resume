using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xin.Models
{
    public class FullWE
    {
        public WorkExperience WorkExperience { get; set; }
        public List<WorkExperienceDetail> WorkExperienceDetail { get; set; }
        public FullWE()
        {
            this.WorkExperience = WorkExperience;
            this.WorkExperienceDetail = WorkExperienceDetail;
        }
    }
}
