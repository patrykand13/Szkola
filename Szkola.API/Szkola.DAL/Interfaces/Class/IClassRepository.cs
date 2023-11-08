using Szkola.DAL.Entities;

namespace Szkola.DAL.Interfaces.Class
{
    public interface IClassRepository
    {
        Task<List<ClassEntity>> GetClasses();
        Task<ClassEntity> CreateClass(ClassEntity @class);
        Task<ClassEntity> GetClass(Guid id);
        Task UpdateClass(Guid id, ClassEntity @class);
        Task DeleteClass(Guid id);
    }

}
