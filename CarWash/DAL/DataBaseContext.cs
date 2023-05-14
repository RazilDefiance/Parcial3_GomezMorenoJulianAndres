using CarWash.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace CarWash.DAL
{
        public class DataBaseContext : IdentityDbContext<User>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        // Mapeando identidad
        public DbSet<Service> Services { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDetail> VehicleDetails { get; set; }


        // Creación indice para las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Service>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(c => c.Plate).IsUnique();
            modelBuilder.Entity<VehicleDetail>().HasIndex(d => d.Id).IsUnique();
        }
    }

}
