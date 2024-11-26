using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _2FSemesterProjekt2024.Models;

[Table("Passenger")]
[Index("Email", Name = "UQ__Passenge__A9D10534B2F7A163", IsUnique = true)]
public partial class Passenger
{
    [Key]
    public int PassengerId { get; set; }

    [StringLength(30)]
    public string PassengerName { get; set; } = null!;

    [StringLength(256)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(256)]
    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    [InverseProperty("Passenger")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [ForeignKey("RoleId")]
    [InverseProperty("Passengers")]
    public virtual Role Role { get; set; } = null!;
}
