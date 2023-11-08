using Szkola.DAL.Entities;

namespace Szkola.BLL.Interfaces.Class
{
    public interface IClassService
    {
        Task<List<ClassEntity>> GetClasses();
        Task<ClassEntity> GetClass(Guid id);
        Task<ClassEntity> CreateClass(ClassEntity @class);
        Task UpdateClass(Guid id, ClassEntity @class);
        Task DeleteClass(Guid id);
    }

}
