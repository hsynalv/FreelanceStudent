using FreelanceStudent.Core.UnitOfWork;
using FreelanceStudent.Data.Abstract;
using FreelanceStudent.Data.EntityFramework.Repositories;
using FreelanceStudent.Data.UnitOfWorks;
using FreelanceStudent.EntityFramework;
using FreelanceStudent.Service.Abstract;
using FreelanceStudent.Service.Mapper;
using FreelanceStudent.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BackgroundService = FreelanceStudent.Service.Services.BackgroundService;

namespace FreelanceStudent.API
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



            services.AddDbContext<AppDbContext>(sqloptions =>
            {
                sqloptions.UseSqlServer(Configuration.GetConnectionString("SqlConnection"), migrationOptions =>
                {
                    migrationOptions.MigrationsAssembly("FreelanceStudent.Data");
                });
            });

            services.AddAutoMapper(typeof(MapProfile));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAdvertDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfAdvertDal(context);
            });
            services.AddScoped<IBackgroundDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfBackgroundDal(context);
            });;
            services.AddScoped<ICategoryDal,EfCategoryDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfCategoryDal(context);
            });;

            services.AddScoped<IAdvertService,AdvertService>();
            services.AddScoped<IBackgroundService, BackgroundService>();
            services.AddScoped<ICategoryService, CategoryService>();





            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FreelanceStudent.API", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FreelanceStudent.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
