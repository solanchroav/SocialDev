namespace SocialDev.Models
{
    public class UpdateUserVm
    {
        public string Id { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }
        public string? Birthday { get; set; }
        public string? Gender { get; set; }
    }
}
