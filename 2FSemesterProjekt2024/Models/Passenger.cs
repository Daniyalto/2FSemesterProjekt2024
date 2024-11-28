using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _2FSemesterProjekt2024.Models;

[Table("Passenger")]
public partial class Passenger
{
    [Key]
    public int PassengerId { get; set; }

    [StringLength(30)]
    public string PassengerName { get; set; } = null!;

    [StringLength(40)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(20)]
    public string Password { get; set; } = null!;

    [StringLength(100)]
    public string? ProfilePictureUrl { get; set; }

    [InverseProperty("Passenger")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
