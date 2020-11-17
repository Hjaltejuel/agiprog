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

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<NewRoadmap> BewRoadmaps { get; set; }

        public DbSet<NewRoadmap> NewRoadmaps { get; set; }
        public DbSet<Step> Steps { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<RoadmapStep> RoadmapSteps { get; set; }

        public DbSet<StepDate> StepDates { get;set; }

        public DbSet<MessageBody> MessageBodies { get; set; }
        public agiprogContext(DbContextOptions<agiprogContext> options)
            : base(options)
        
        {
   
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RoadmapStep>()
                .HasKey(bc => new { bc.NewRoadmapId, bc.StepId });
            builder.Entity<RoadmapStep>()
                .HasOne(bc => bc.NewRoadmap)
                .WithMany(b => b.RoadmapSteps)
                .HasForeignKey(bc => bc.NewRoadmapId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<RoadmapStep>()
                .HasOne(bc => bc.Step)
                .WithMany(c => c.RoadmapSteps)
                .HasForeignKey(bc => bc.StepId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Message>()
                .HasKey(bc => new { bc.MeetingId,  bc.StepId });
            builder.Entity<Message>()
                .HasOne(bc => bc.Meeting)
                .WithMany(b => b.Messages)
                .HasForeignKey(bc => bc.MeetingId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Message>()
                .HasOne(bc => bc.Step)
                .WithMany(c => c.Messages)
                .HasForeignKey(bc => bc.StepId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<StepDate>()
                .HasKey(bc => new { bc.MeetingId,  bc.StepId });
            builder.Entity<StepDate>()
                .HasOne(bc => bc.Meeting)
                .WithMany(b => b.StepDates)
                .HasForeignKey(bc => bc.MeetingId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<StepDate>()
                .HasOne(bc => bc.Step)
                .WithMany(c => c.StepDates)
                .HasForeignKey(bc => bc.StepId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<MessageBody>()
                .HasOne(bc => bc.Message)
                .WithMany(b => b.MessageBodies)
                .HasForeignKey(bc => new { bc.MeetingId, bc.StepId }).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
