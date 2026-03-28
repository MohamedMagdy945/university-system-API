namespace UniversitySystem.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PersonalEmail { get; set; } = string.Empty;
        public string? UniversityEmail { get; set; } = null;
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public double GPA { get; set; }
        public int Level { get; set; }
    }
}
