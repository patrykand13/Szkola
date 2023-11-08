using System.ComponentModel.DataAnnotations;

namespace Szkola.DAL.Entities
{
    public class TeacherEntity
    {
        [Key]
        public Guid TeacherId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public double EmploymentRate { get; set; }
        [Required]
        public DateTime EmploymentStartDate { get; set; }
        public List<ClassEntity> Classes { get; set; }
    }
}
