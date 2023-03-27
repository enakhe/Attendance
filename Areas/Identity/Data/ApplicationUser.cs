#nullable disable

using Attendance.Models;
using Microsoft.AspNetCore.Identity;

namespace Attendance.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.SignIn = new HashSet<SignIn>();
        }

        public virtual ICollection<SignIn> SignIn { get; set; }
    }
}
