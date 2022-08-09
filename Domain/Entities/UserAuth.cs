using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class UserAuth : IdentityUser
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime? Birthday { get; set; }
        public string? Gender { get; set; }
    }
}
