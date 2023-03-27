#nullable disable

using Attendance.Areas.Identity.Data;

namespace Attendance.Models
{
    public class SignIn
    {
        public int Id { get; set; }
        public DateTime TimeIn { get; set; } = DateTime.Now;
        public DateTime TimeOut { get; set; } = DateTime.Now;
        public string StudentId { get; set; }
        public bool IsSignOut { get; set; } = false;
        public virtual ApplicationUser Student { get; set; }
    }
}
