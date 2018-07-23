using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Xin.Models;

namespace Xin.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Description> Description { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Eduction> Eduction { get; set; }
        public DbSet<WorkExperience> WorkExperience { get; set; }
        public DbSet<WorkExperienceDetail> WorkExperienceDetail { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<DesDetails> DesDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
