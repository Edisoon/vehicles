using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vehicle.API.Data.Entities;

namespace Vehicle.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<DocumentTypes> DocumentTypes { get; set; }
        public DbSet<History> Histories { get; set; }

        public DbSet<MotorVehicle> Vehicles { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<VehiclePhoto> VehiclePhotos { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<DocumentTypes>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<MotorVehicle>().HasIndex(x => x.Plaque).IsUnique();
            modelBuilder.Entity<Procedure>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<VehicleType>().HasIndex(x => x.Description).IsUnique();

        }

    }
}
