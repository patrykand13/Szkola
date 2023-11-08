using Szkola.DAL.Entities;

namespace Szkola.BLL.Interfaces.Student
{
    public interface IStudentService
    {
        Task<List<StudentEntity>> GetStudents();
        Task<StudentEntity> GetStudent(Guid id);
        Task<List<StudentEntity>> GetStudentsByFirstName(string firstName);
        Task<StudentEntity> CreateStudent(StudentEntity student);
        Task UpdateStudent(Guid id, StudentEntity student);
        Task DeleteStudent(Guid id);
    }

}
