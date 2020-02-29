using Microsoft.EntityFrameworkCore;
using VehicleManagementAPI.Model;
using System;
using Polly;

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

        public void MigrateDB()
        {
            Policy
                .Handle<Exception>()
                .WaitAndRetry(1, r => TimeSpan.FromSeconds(1))
                .Execute(() => Database.Migrate());
        }
    }
}