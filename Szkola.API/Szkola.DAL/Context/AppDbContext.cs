using Microsoft.EntityFrameworkCore;
using Szkola.DAL.Entities;

namespace Szkola.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<ClassEntity> Classes { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TeacherEntity>()
            .HasMany(t => t.Classes)
            .WithMany(c => c.Teachers)
            .UsingEntity(j => j.ToTable("TeacherClass"));

            builder.Entity<ClassEntity>()
                .HasMany(c => c.Students)
                .WithOne(s => s.Class);
        }
    }
}
