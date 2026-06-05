using HealthcareAnalytics.Core.Entities;
using HealthcareAnalytics.Core.Interfaces;
using HealthcareAnalytics.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace HealthcareAnalytics.Data.Repositories
{
    // Repository for authentication operations
    public class AuthRepository : IAuthRepository
    {
        private readonly HealthcareDbContext _context;

        // Constructor Injection
        public AuthRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        // Register new user
        public async Task RegisterUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        // Get user by email
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        // Save changes to database
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
