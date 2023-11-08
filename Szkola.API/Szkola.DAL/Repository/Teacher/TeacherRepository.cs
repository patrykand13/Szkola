using Microsoft.EntityFrameworkCore;
using Szkola.DAL.Entities;
using Szkola.DAL.Interfaces.Teacher;

namespace Szkola.DAL.Repository.Teacher
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TeacherEntity>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<TeacherEntity> GetTeacher(Guid id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<List<TeacherEntity>> GetTeachersByMinYearsOfWork(int startDate)
        {
            var teachers = await (from u in _context.Teachers
                                  where u.EmploymentStartDate.Year <= startDate
                                  select u).ToListAsync();
            return teachers;
        }

        public async Task<TeacherEntity> CreateTeacher(TeacherEntity teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task UpdateTeacher(Guid id, TeacherEntity teacher)
        {
            if (id != teacher.TeacherId)
            {
                throw new ArgumentException("Invalid teacher ID");
            }
            _context.Entry(teacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacher(Guid id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                throw new KeyNotFoundException("Teacher not found");
            }
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }

}
