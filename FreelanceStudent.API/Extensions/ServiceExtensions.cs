using System;
using FreelanceStudent.Core.UnitOfWork;
using FreelanceStudent.Data.Abstract;
using FreelanceStudent.Data.EntityFramework.Repositories;
using FreelanceStudent.Data.UnitOfWorks;
using FreelanceStudent.EntityFramework;
using FreelanceStudent.Service.Abstract;
using FreelanceStudent.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<ICategoryDal,EfCategoryDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfCategoryDal(context);
            });;

            services.AddScoped<IForeignLanguageDal, EfForeignLanguageDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfForeignLanguageDal(context);
            }); ;

            services.AddScoped<IProgrammingLanguageDal, EfProgrammingLanguageDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfProgrammingLanguageDal(context);
            });

            services.AddScoped<IJobExperienceDal, EfJobExperienceDal>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                return new EfJobExperienceDal(context);
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
    }
}
