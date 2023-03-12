using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Models;

public partial class FlightDbContext : DbContext
{
    public FlightDbContext()
    {
    }

    public FlightDbContext(DbContextOptions<FlightDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Flight> Flights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        /*if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("FlightDBConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }*/
    }
        //optionsBuilder.UseSqlServer("TrustServerCertificate=True;Server=DESKTOP-OHI07Q7;Database=FlightDB;Trusted_Connection=True");
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightNo).HasName("PK__Flights__8A9E3D454312A97B");

            entity.Property(e => e.FlightNo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ArrTime).HasColumnType("smalldatetime");
            entity.Property(e => e.DepTime).HasColumnType("smalldatetime");
            entity.Property(e => e.FromAirport)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ToAirport)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
