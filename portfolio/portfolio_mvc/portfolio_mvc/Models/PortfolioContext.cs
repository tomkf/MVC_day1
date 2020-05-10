using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options)
            : base(options)
        { }

        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TechnologyProject> TechnologyProjects { get; set; }

        // override of parent DbContext's virtual method.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define bridge table's composite primary key.
            modelBuilder.Entity<TechnologyProject>()
                .HasKey(tp => new { tp.TechnologyName, tp.ProjectId });

            // Define bridge table's foreign keys.
            modelBuilder.Entity<TechnologyProject>()
              .HasOne(tp => tp.Technology)
              .WithMany(tp => tp.TechnologyProjects)
              .HasForeignKey(fk => new { fk.TechnologyName })
              .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<TechnologyProject>()
              .HasOne(tp => tp.Project)
              .WithMany(tp => tp.TechnologyProjects)
              .HasForeignKey(fk => new { fk.ProjectId })
              .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }

    }
}
