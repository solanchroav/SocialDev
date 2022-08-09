using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Password { get; set; } = default!;
        [Required]
        public string Email { get; set; } = default!;
        [Required]
        public string FirstName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        public DateTime? Birthday { get; set; }
        public string? Gender { get; set; }
    }
}
