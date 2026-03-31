namespace UniversitySystem.Application.Common.Models
{
    public class AuthResult
    {
        public bool Succeeded { get; set; }
        public string? UserId { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
