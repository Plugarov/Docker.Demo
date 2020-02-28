using Microsoft.EntityFrameworkCore;
using VehicleManagementAPI.Model;

namespace VehicleManagementAPI.DataAccess
{
    public class VehicleManagementDBContext : DbContext
    {
        public VehicleManagementDBContext(DbContextOptions<VehicleManagementDBContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vehicle>().Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Entity<Vehicle>().Property(s => s.VIN).IsRequired();
            builder.Entity<Vehicle>().Property(s => s.CustomerId).IsRequired();
            builder.Entity<Vehicle>().ToTable("Vehicle");
            base.OnModelCreating(builder);
        }
    }
}