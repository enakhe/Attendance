#nullable disable

using Attendance.Areas.Identity.Data;
using Attendance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Attendance.Data;

public class AttendanceContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<SignIn> SignIn { get; set; }
    public AttendanceContext(DbContextOptions<AttendanceContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
