using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BMITrackerApp.Models.Entities;

namespace BMITrackerApp.Models.DbContexts
{
    public partial class HealthProfileDbContext : DbContext
    {
        public virtual DbSet<HealthProfile> HealthProfile { get; set; }

		//Inject DBContext options
		public HealthProfileDbContext(DbContextOptions options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HealthProfile>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });
        }
    }
}