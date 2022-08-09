using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class UserAuthRegistrationDto
    {
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; init; }
        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; init; }
        [Required(ErrorMessage = "Username is required")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
}
