using Graduway.BL.Builders;
using Graduway.BL.Services;
using Graduway.BL.Services.Interfaces;
using Graduway.BL.UnitOfWork;
using Graduway.BL.UnitOfWork.Interfaces;
using Graduway.DAL;
using Graduway.DAL.Interfaces;
using Graduway.DAL.Repository;
using Graduway.Web.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Graduway.Web
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
            services.AddCors();

            string connection = Configuration[Constants.GraduwayConnectionString];
            services.AddDbContext<GraduwayDbContext>(option => option.UseSqlServer(connection));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddTransient(typeof(IEmployeeService), typeof(EmployeesService));
            services.AddTransient(typeof(ITasksService), typeof(TasksService));

            services.AddScoped(typeof(ITaskBuilder), typeof(TaskBuilder));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
