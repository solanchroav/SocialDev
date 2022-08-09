using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Application.Common.Interfaces
{
    public interface IUserAuthenticationRepository
    {
        Task<IdentityResult> RegisterUserAsync(UserAuth userRegistration, string password);
        Task<bool> ValidateUserAsync(UserLogin login);
        Task<string> CreateTokenAsync();
    }
}
