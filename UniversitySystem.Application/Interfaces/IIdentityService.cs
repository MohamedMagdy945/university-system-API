
using UniversitySystem.Application.Common.Models;

namespace UniversitySystem.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<string?> GetUserNameAsync(int userId);

        Task<AuthResult> CreateUserAsync(string userName, string password);

        Task<bool> DeleteUserAsync(int userId);

        Task<bool> IsInRoleAsync(int userId, string role);

        Task<bool> AuthorizeAsync(int userId, string policyName);
    }
}
