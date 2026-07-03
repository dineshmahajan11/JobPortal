using JobPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .Property(j => j.Salary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Recruiter)
                .WithMany()
                .HasForeignKey(j => j.RecruiterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobApplication>()
                .HasOne(a => a.Job)
                .WithMany(j => j.Applications)
                .HasForeignKey(a => a.JobId);

            modelBuilder.Entity<JobApplication>()
                .HasOne(a => a.User)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.UserId);
        }
    }
}