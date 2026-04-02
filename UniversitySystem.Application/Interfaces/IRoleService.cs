using Microsoft.AspNetCore.Identity;

namespace UniversitySystem.Application.Interfaces
{
    public interface IRoleService
    {
        Task<IdentityResult> CreateRoleAsync(string roleName);

        Task<List<IdentityRole<int>>> GetAllRolesAsync();

        Task<IdentityRole<int>?> GetByNameAsync(string roleName);

        Task<IdentityResult> DeleteRoleAsync(string roleName);
    }
}