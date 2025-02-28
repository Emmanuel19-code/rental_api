using app.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace app.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Tenants> Tenants {get;set;}
        public DbSet<Amenities> Amenities {get;set;}
        public DbSet<RentApplication> RentApplications {get;set;}
        public DbSet<HighLight> HighLights {get;set;}
        public DbSet<Leases> Leases {get;set;}
        public DbSet<Location> Locations {get;set;}
        public DbSet<Manager> Managers {get;set;}
        public DbSet<PropertyPhotos> PropertyPhotos {get;set;}
        public DbSet<Property> Property {get;set;}

    }
}