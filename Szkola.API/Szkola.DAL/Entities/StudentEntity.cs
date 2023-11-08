using System.ComponentModel.DataAnnotations;

namespace Szkola.DAL.Entities
{
    public class StudentEntity
    {
        [Key]
        public Guid StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public double PreviousYearAverage { get; set; }
        public Guid ClassId { get; set; }
        public ClassEntity Class { get; set; }
    }
}
