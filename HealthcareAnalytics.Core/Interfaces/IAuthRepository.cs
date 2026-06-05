using HealthcareAnalytics.Core.Entities;

namespace HealthcareAnalytics.Core.Interfaces
{
    // Interface for authentication database operations
    public interface IAuthRepository
    {
        // Register new user
        Task RegisterUserAsync(User user);

        // Get user by email
        Task<User?> GetUserByEmailAsync(string email);

        // Save changes
        Task SaveAsync();
    }
}