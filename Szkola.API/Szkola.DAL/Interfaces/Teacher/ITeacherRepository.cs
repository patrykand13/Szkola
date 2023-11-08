using Szkola.DAL.Entities;

namespace Szkola.DAL.Interfaces.Teacher
{
    public interface ITeacherRepository
    {
        Task<List<TeacherEntity>> GetTeachers();
        Task<TeacherEntity> CreateTeacher(TeacherEntity teacher);
        Task<List<TeacherEntity>> GetTeachersByMinYearsOfWork(int startDate);
        Task<TeacherEntity> GetTeacher(Guid id);
        Task UpdateTeacher(Guid id, TeacherEntity teacher);
        Task DeleteTeacher(Guid id);
    }

}
