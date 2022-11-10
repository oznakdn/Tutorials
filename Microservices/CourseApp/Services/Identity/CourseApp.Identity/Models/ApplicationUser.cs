using Microsoft.AspNetCore.Identity;

namespace CourseApp.Identity.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string City { get; set; }
    }
}
