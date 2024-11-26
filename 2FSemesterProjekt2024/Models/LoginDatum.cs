using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _2FSemesterProjekt2024.Models;

[Index("Email", Name = "UQ__LoginDat__A9D105340E39DAED", IsUnique = true)]
public partial class LoginDatum
{
    [Key]
    public int UserId { get; set; }

    [StringLength(256)]
    public string Email { get; set; } = null!;

    [StringLength(256)]
    public string Password { get; set; } = null!;
}
