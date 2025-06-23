namespace Application.Models.Identity.Dtos
{
    public class UpdateUserInfoDto
    {
        public string? Email { get; set; } 
        public string? DisplayName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string CurrentPassword { get; set; } = null!;
    }
}
