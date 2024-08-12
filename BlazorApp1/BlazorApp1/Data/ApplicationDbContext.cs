using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Models;

namespace BlazorApp1.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Stand> Stand { get; set; } = default!;
        public DbSet<Scheduler> Schedulers { get; set; } = default!;
        public DbSet<ScheduledStand> ScheduledStands { get; set; } = default!;
        public DbSet<StudentGroup> StudentGroups { get; set; } = default!;
        public DbSet<Organization> Organizations { get; set; } = default!;
        public DbSet<OrganizationStand> OrganizationStands { get; set; } = default!;
        public DbSet<Service> Services { get; set; } = default!;
        public DbSet<ServiceType> ServiceTypes { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.Name)
                .HasMaxLength(250);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.Surname)
                .HasMaxLength(250);

            modelBuilder.Entity<ApplicationUser>()
               .Property(e => e.Patronymic)
               .HasMaxLength(250);

            modelBuilder.Entity<ApplicationUser>()
               .Property(e => e.StudentGroup)
               .HasMaxLength(250);
        }
    }
}
