using FlightManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Infrastructure.Database
{
    public class FlightManagementContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public FlightManagementContext(DbContextOptions<FlightManagementContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Flight>()
                .Property(f => f.Version)
                .IsRowVersion();

            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Passengers)
                .WithOne()
                .HasForeignKey(p => p.FlightId);

            modelBuilder.Entity<Passenger>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Passenger>()
                .Property(p => p.BaggageWeight)
                .IsRequired();
        
            var flight1 = new Flight(1, "FN123", 150, 23);
            var flight2 = new Flight(2, "FN456", 100, 17);

            modelBuilder.Entity<Flight>().HasData(flight1, flight2);
        }
    }
}
