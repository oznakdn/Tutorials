using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseApp.Identity.Models
{
    public class ApplicationUserRefreshToken
    {
        [Key,ForeignKey(nameof(User))]
        public string UserId { get; set; } = default!;
        public ApplicationUser User { get; set; }
        public string Token { get; set; } = default!;
        public DateTime Expiration { get; set; }
    }
}
