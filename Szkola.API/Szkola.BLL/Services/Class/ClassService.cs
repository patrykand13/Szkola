using Szkola.BLL.Interfaces.Class;
using Szkola.DAL.Entities;
using Szkola.DAL.Interfaces.Class;

namespace Szkola.BLL.Services.Class
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<List<ClassEntity>> GetClasses()
        {
            return await _classRepository.GetClasses();
        }
        public async Task<ClassEntity> GetClass(Guid id)
        {
            return await _classRepository.GetClass(id);
        }

        public async Task<ClassEntity> CreateClass(ClassEntity @class)
        {
            return await _classRepository.CreateClass(@class);
        }

        public async Task UpdateClass(Guid id, ClassEntity @class)
        {
            await _classRepository.UpdateClass(id, @class);
        }

        public async Task DeleteClass(Guid id)
        {
            await _classRepository.DeleteClass(id);
        }
    }

}
