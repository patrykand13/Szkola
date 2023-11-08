using Szkola.BLL.Interfaces.Student;
using Szkola.DAL.Entities;
using Szkola.DAL.Interfaces.Student;

namespace Szkola.BLL.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentEntity>> GetStudents()
        {
            return await _studentRepository.GetStudents();
        }

        public async Task<StudentEntity> GetStudent(Guid id)
        {
            return await _studentRepository.GetStudent(id);
        }
        public async Task<List<StudentEntity>> GetStudentsByFirstName(string firstName)
        {
            return await _studentRepository.GetStudentsByFirstName(firstName);
        }


        public async Task<StudentEntity> CreateStudent(StudentEntity student)
        {
            return await _studentRepository.CreateStudent(student);
        }

        public async Task UpdateStudent(Guid id, StudentEntity student)
        {
            await _studentRepository.UpdateStudent(id, student);
        }

        public async Task DeleteStudent(Guid id)
        {
            await _studentRepository.DeleteStudent(id);
        }
    }

}
