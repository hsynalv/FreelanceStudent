using FreelanceStudent.Core.UnitOfWork;
using FreelanceStudent.Data.Abstract;
using FreelanceStudent.Data.EntityFramework.Repositories;
using FreelanceStudent.Data.UnitOfWorks;
using FreelanceStudent.EntityFramework;
using FreelanceStudent.Service.Abstract;
using FreelanceStudent.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FreelanceStudent.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDalLayer(this IServiceCollection services)
        {

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
            services.AddScoped<ICategoryDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfCategoryDal(context);
            });;

            services.AddScoped<IForeignLanguageDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfForeignLanguageDal(context);
            }); ;

            services.AddScoped<IProgrammingLanguageDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfProgrammingLanguageDal(context);
            });

            services.AddScoped<IJobExperienceDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfJobExperienceDal(context);
            });

            services.AddScoped<IUserDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfUserDal(context);
            });

            services.AddScoped<IEmployerDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfEmployerDal(context);
            });

            services.AddScoped<IStudentDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfStudentDal(context);
            });
        }

        public static void ConfigureServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IAdvertService,AdvertService>();
            services.AddScoped<IBackgroundService, BackgroundService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IForeignLanguageService, ForeignLanguageService>();
            services.AddScoped<IProgrammingLanguageService, ProgrammingLanguageService>();
            services.AddScoped<IJobExperienceService, JobExperienceService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IEmployerService, EmployerService>();

        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(sqloptions =>
            {
                sqloptions.UseSqlServer(configuration.GetConnectionString("SqlConnection"), migrationOptions =>
                {
                    migrationOptions.MigrationsAssembly("FreelanceStudent.Data");
                });
            });
        }

        public static void ConfigureAuthentice(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://localhost:5001";
                options.Audience = "resource_API";
                options.RequireHttpsMetadata = false;
            });
        }
    }
}
