using UniversitySystem.Application.Common.Models;
using UniversitySystem.Domain.Identity;

namespace UniversitySystem.Application.Interfaces
{
    public interface ITokenGenerator
    {
        TokenPair GenerateTokenPair(AppUser user, IEnumerable<string> roles, string ip, string device);
        string GenerateAccessToken(AppUser user, IEnumerable<string> roles);
        string GenerateRefreshToken();
        string HashToken(string token);
    }
}
