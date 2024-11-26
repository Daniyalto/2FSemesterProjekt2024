using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _2FSemesterProjekt2024.Models;

public partial class DriverDBContext : DbContext
{
    public DriverDBContext()
    {
    }

    public DriverDBContext(DbContextOptions<DriverDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<LoginDatum> LoginData { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951AED702D99AE");

            entity.Property(e => e.BookingTime).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Driver).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__DriverI__48CFD27E");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__Passeng__47DBAE45");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__Driver__F1B1CD042450D8D0");

            entity.HasOne(d => d.Role).WithMany(p => p.Drivers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Driver__RoleId__440B1D61");
        });

        modelBuilder.Entity<LoginDatum>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__LoginDat__1788CC4C720DC9EC");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.PassengerId).HasName("PK__Passenge__88915FB01029CB11");

            entity.HasOne(d => d.Role).WithMany(p => p.Passengers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Passenger__RoleI__3E52440B");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A805A77D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
