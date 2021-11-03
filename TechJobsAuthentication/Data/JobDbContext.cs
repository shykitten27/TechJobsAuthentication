using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechJobsAuthentication.Models;

namespace TechJobsAuthentication.Data
{
    public class JobDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Job> Jobs { get; set; }

        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options)
        {
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Job>().HasKey(j => new { j.Id });

             base.OnModelCreating(modelBuilder);
         }
    }
}
