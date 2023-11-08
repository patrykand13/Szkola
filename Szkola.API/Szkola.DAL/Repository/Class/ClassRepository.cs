using Microsoft.EntityFrameworkCore;
using Szkola.DAL.Entities;
using Szkola.DAL.Interfaces.Class;

namespace Szkola.DAL.Repository.Class
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _context;

        public ClassRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClassEntity>> GetClasses()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<ClassEntity> GetClass(Guid id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task<ClassEntity> CreateClass(ClassEntity @class)
        {
            _context.Classes.Add(@class);
            await _context.SaveChangesAsync();
            return @class;
        }

        public async Task UpdateClass(Guid id, ClassEntity @class)
        {
            if (id != @class.ClassId)
            {
                throw new ArgumentException("Invalid class ID");
            }
            _context.Entry(@class).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClass(Guid id)
        {
            var @class = await _context.Classes.FindAsync(id);
            if (@class == null)
            {
                throw new KeyNotFoundException("Class not found");
            }
            _context.Classes.Remove(@class);
            await _context.SaveChangesAsync();
        }
    }

}
