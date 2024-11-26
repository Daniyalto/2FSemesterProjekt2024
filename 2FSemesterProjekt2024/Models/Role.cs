using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _2FSemesterProjekt2024.Models;

[Index("RoleName", Name = "UQ__Roles__8A2B616055B7EDB3", IsUnique = true)]
public partial class Role
{
    [Key]
    public int RoleId { get; set; }

    [StringLength(50)]
    public string RoleName { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    [InverseProperty("Role")]
    public virtual ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
}
