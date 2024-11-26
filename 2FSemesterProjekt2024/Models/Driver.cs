using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _2FSemesterProjekt2024.Models;

[Table("Driver")]
public partial class Driver
{
    [Key]
    public int DriverId { get; set; }

    [StringLength(30)]
    public string DriverName { get; set; } = null!;

    [StringLength(30)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(20)]
    public string Password { get; set; } = null!;

    [StringLength(200)]
    public string VehicleInfo { get; set; } = null!;

    [StringLength(10)]
    public string LicenseNumber { get; set; } = null!;

    [Column(TypeName = "decimal(2, 1)")]
    public decimal Rating { get; set; }

    public int Points { get; set; }

    [StringLength(100)]
    public string? ProfilePictureUrl { get; set; }

    [InverseProperty("Driver")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
