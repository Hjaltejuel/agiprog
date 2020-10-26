using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agiprog.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace agiprog.Data
{
    public class agiprogContext : IdentityDbContext<agiprogUser>
    {

        public DbSet<Meeting> meetings { get; set; }
        public DbSet<Roadmap> roadmaps { get; set; }
        public DbSet<Step> steps { get; set; }

        public DbSet<RoadmapStep> RoadmapSteps { get; set; }
        public agiprogContext(DbContextOptions<agiprogContext> options)
            : base(options)
        
        {
   
        }
 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RoadmapStep>()
                .HasKey(bc => new { bc.RoadmapId, bc.StepId });
            builder.Entity<RoadmapStep>()
                .HasOne(bc => bc.Roadmap)
                .WithMany(b => b.RoadmapSteps)
                .HasForeignKey(bc => bc.RoadmapId);
            builder.Entity<RoadmapStep>()
                .HasOne(bc => bc.Step)
                .WithMany(c => c.RoadmapSteps)
                .HasForeignKey(bc => bc.StepId);
        }
    }
}
