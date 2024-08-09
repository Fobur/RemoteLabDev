using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Models;

namespace BlazorApp1.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Stand> Stand { get; set; } = default!;

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

            //modelBuilder.Entity<ApplicationUser>()
            //   .Property(e => e.StudyGroup)
            //   .HasMaxLength(250);

        }
    }
}
