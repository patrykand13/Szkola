using Szkola.BLL.Interfaces.Teacher;
using Szkola.DAL.Entities;
using Szkola.DAL.Interfaces.Teacher;

namespace Szkola.BLL.Services.Teacher
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<List<TeacherEntity>> GetTeachers()
        {
            return await _teacherRepository.GetTeachers();
        }

        public async Task<TeacherEntity> GetTeacher(Guid id)
        {
            return await _teacherRepository.GetTeacher(id);
        }

        public async Task<List<TeacherEntity>> GetTeachersByMinYearsOfWork(int minYearsOfWork)
        {
            var startDate = DateTime.Now.Year - minYearsOfWork;
            return await _teacherRepository.GetTeachersByMinYearsOfWork(startDate);
        }

        public async Task<TeacherEntity> CreateTeacher(TeacherEntity teacher)
        {
            return await _teacherRepository.CreateTeacher(teacher);
        }

        public async Task UpdateTeacher(Guid id, TeacherEntity teacher)
        {
            await _teacherRepository.UpdateTeacher(id, teacher);
        }

        public async Task DeleteTeacher(Guid id)
        {
            await _teacherRepository.DeleteTeacher(id);
        }
    }

}
