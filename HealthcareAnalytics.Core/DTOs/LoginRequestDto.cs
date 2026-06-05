using System.ComponentModel.DataAnnotations;

namespace HealthcareAnalytics.Core.DTOs
{
    // DTO for user login request
    public class LoginRequestDto
    {
        // User email
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // User password
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}