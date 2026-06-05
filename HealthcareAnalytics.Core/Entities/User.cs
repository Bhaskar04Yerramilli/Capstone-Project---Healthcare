namespace HealthcareAnalytics.Core.Entities
{
    // Represents application users such as Admin or Staff
    public class User
    {
        // Primary Key
        public int UserId { get; set; }

        // Stores full name of the user
        public string FullName { get; set; } = string.Empty;

        // User email used for login
        public string Email { get; set; } = string.Empty;

        // Stores hashed password for security
        public string PasswordHash { get; set; } = string.Empty;

        // User role for authorization
        // Example: Admin, Doctor
        public string Role { get; set; } = string.Empty;
    }
}