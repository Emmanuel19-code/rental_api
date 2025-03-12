using app.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace app.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tenants> Tenants { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RentApplication> RentApplications { get; set; }
        public DbSet<HighLight> HighLights { get; set; }
        public DbSet<Leases> Leases { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<PropertyPhotos> PropertyPhotos { get; set; }
        public DbSet<Property> Property { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ignore the entire Coordinates property if it's causing issues
            modelBuilder.Entity<Location>()
                .Ignore(l => l.Coordinates);

            // One-to-One Relationship: One Tenant has One Lease
            modelBuilder.Entity<Leases>()
                .HasOne(l => l.Tenants)
                .WithOne(t => t.Leases)
                .HasForeignKey<Leases>(l => l.TenantId)
                .OnDelete(DeleteBehavior.Cascade);
        }



    }
}
