using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _2FSemesterProjekt2024.Models;

[Table("Driver")]
[Index("Email", Name = "UQ__Driver__A9D105342202B79D", IsUnique = true)]
public partial class Driver
{
    [Key]
    public int DriverId { get; set; }

    [StringLength(30)]
    public string DriverName { get; set; } = null!;

    [StringLength(256)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(256)]
    public string Password { get; set; } = null!;

    [StringLength(200)]
    public string VehicleInfo { get; set; } = null!;

    [StringLength(20)]
    public string LicenseNumber { get; set; } = null!;

    [Column(TypeName = "decimal(2, 1)")]
    public decimal Rating { get; set; }

    public int Points { get; set; }

    public int RoleId { get; set; }

    [InverseProperty("Driver")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [ForeignKey("RoleId")]
    [InverseProperty("Drivers")]
    public virtual Role Role { get; set; } = null!;
}
