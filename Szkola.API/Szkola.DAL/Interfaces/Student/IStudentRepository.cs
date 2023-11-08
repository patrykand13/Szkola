using Szkola.DAL.Entities;

namespace Szkola.DAL.Interfaces.Student
{
    public interface IStudentRepository
    {
        Task<List<StudentEntity>> GetStudents();
        Task<StudentEntity> GetStudent(Guid id);
        Task<List<StudentEntity>> GetStudentsByFirstName(string firstName);
        Task<StudentEntity> CreateStudent(StudentEntity student);
        Task UpdateStudent(Guid id, StudentEntity student);
        Task DeleteStudent(Guid id);
    }

}
