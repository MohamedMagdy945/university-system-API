using Microsoft.AspNetCore.Identity;

namespace UniversitySystem.Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? FullName { get; set; }
    }
}
