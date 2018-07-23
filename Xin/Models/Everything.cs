using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xin.Models
{
    public class Everything
    {
        public ApplicationUser ApplicationUser { get; set; }

        public List<FullDes> FullDes { get; set; }
        public List<Eduction> Eductions { get; set; }
        public Profile Profiles { get; set; }
        public List<Project> Projects { get; set; }
        public List<Skill> Skills { get; set; }
        public List<FullWE> FullWE { get; set; }
        public Everything()
        {
            this.ApplicationUser = new ApplicationUser();
            this.Profiles = new Profile();

            this.FullDes = new List<FullDes>();
            this.Eductions = new List<Eduction>();
            this.Projects = new List<Project>();
            this.FullWE = new List<FullWE>();
            this.Skills = new List<Skill>();
        }

    }
}
