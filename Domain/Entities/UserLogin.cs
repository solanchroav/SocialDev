using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
}
