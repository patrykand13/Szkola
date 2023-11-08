using Microsoft.EntityFrameworkCore;
using Szkola.BLL.Interfaces.Class;
using Szkola.BLL.Interfaces.Student;
using Szkola.BLL.Interfaces.Teacher;
using Szkola.BLL.Services.Class;
using Szkola.BLL.Services.Student;
using Szkola.BLL.Services.Teacher;
using Szkola.DAL;
using Szkola.DAL.Interfaces.Class;
using Szkola.DAL.Interfaces.Student;
using Szkola.DAL.Interfaces.Teacher;
using Szkola.DAL.Repository.Class;
using Szkola.DAL.Repository.Student;
using Szkola.DAL.Repository.Teacher;

namespace Szkola.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // For Entity Framework  
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));

            //Initialize Services DI
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IStudentService, StudentService>();

            //Initialize Repositories DI
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
