﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _2FSemesterProjekt2024.Models;

public partial class DriverDBContext : DbContext
{
   

    public DriverDBContext(DbContextOptions<DriverDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

        // Configuration is now handled in Program.cs
        if (!optionsBuilder.IsConfigured)
        {
            // Optional: You may log a warning or throw an exception if configuration is missing.
            throw new InvalidOperationException("DbContextOptions must be configured.");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__tmp_ms_x__73951AED33951DC6");

            entity.Property(e => e.BookingTime).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Driver).WithMany(p => p.Bookings).HasConstraintName("FK__Booking__DriverI__6B24EA82");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Bookings).HasConstraintName("FK__Booking__Passeng__6A30C649");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__tmp_ms_x__F1B1CD041BB02DEF");

            entity.Property(e => e.DriverName).IsFixedLength();
            entity.Property(e => e.Email).IsFixedLength();
            entity.Property(e => e.LicenseNumber).IsFixedLength();
            entity.Property(e => e.Password).IsFixedLength();
            entity.Property(e => e.PhoneNumber).IsFixedLength();
            entity.Property(e => e.VehicleInfo).IsFixedLength();
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.PassengerId).HasName("PK__Passenge__88915FB075C23B1D");

            entity.Property(e => e.Email).IsFixedLength();
            entity.Property(e => e.PassengerName).IsFixedLength();
            entity.Property(e => e.Password).IsFixedLength();
            entity.Property(e => e.PhoneNumber).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
