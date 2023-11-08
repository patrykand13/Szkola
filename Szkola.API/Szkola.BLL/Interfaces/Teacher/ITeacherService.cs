using Szkola.DAL.Entities;

namespace Szkola.BLL.Interfaces.Teacher
{
    public interface ITeacherService
    {
        Task<List<TeacherEntity>> GetTeachers();
        Task<TeacherEntity> GetTeacher(Guid id);
        Task<List<TeacherEntity>> GetTeachersByMinYearsOfWork(int minYearsOfWork);
        Task<TeacherEntity> CreateTeacher(TeacherEntity teacher);
        Task UpdateTeacher(Guid id, TeacherEntity teacher);
        Task DeleteTeacher(Guid id);
    }
}
