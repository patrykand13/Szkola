using System.ComponentModel.DataAnnotations;

namespace Szkola.DAL.Entities
{
    public class ClassEntity
    {
        [Key]
        public Guid ClassId { get; set; }
        [Required]
        public string ClassName { get; set; }
        public List<StudentEntity> Students { get; set; }
        public List<TeacherEntity> Teachers { get; set; }
    }
}
