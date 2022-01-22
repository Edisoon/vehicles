using Microsoft.EntityFrameworkCore;
using vehicles.API.Data.Entities;

namespace vehicles.API.Data
{
    public class DataContext : DbContext
    {
      
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<VehicleType> VehicleTypes  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VehicleType>().HasIndex(x => x.Description).IsUnique();

        }

    }

}
