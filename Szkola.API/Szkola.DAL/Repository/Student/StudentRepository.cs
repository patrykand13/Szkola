using Microsoft.EntityFrameworkCore;
using Szkola.DAL.Entities;
using Szkola.DAL.Interfaces.Student;

namespace Szkola.DAL.Repository.Student
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentEntity>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<StudentEntity> GetStudent(Guid id)
        {
            return await _context.Students.FindAsync(id);
        }
        public async Task<List<StudentEntity>> GetStudentsByFirstName(string firstName)
        {
            var students = await (from u in _context.Students
                                  where u.FirstName.Equals(firstName)
                                  select u).ToListAsync();
            return students;
        }

        public async Task<StudentEntity> CreateStudent(StudentEntity student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task UpdateStudent(Guid id, StudentEntity student)
        {
            if (id != student.StudentId)
            {
                throw new ArgumentException("Invalid student ID");
            }
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }

}
