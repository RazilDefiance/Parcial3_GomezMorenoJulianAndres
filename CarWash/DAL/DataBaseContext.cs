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
        public DbSet<Vehicle> Vechiles { get; set; }
        public DbSet<VechicleDetail> VechicleDetails { get; set; }
        public DbSet<Service> Services { get; set; }


        // Creación indice para las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vehicle>().HasIndex(c => c.Plate).IsUnique();
            modelBuilder.Entity<VechicleDetail>().HasIndex("VehicleDetailId").IsUnique();
            modelBuilder.Entity<Service>().HasIndex("ServiceId").IsUnique();
        }
    }

}
