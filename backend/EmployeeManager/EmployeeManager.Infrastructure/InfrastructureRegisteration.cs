
using System.Runtime.CompilerServices;
using EmployeeManager.Core.Interfaces;
using EmployeeManager.Infrastructure.Data;
using EmployeeManager.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using EmployeeManager.Core.Services;
using EmployeeManager.Infrastructure.Repository.Service;
using Microsoft.Extensions.FileProviders;

namespace EmployeeManager.Infrastructure
{
    public static class InfrastructureRegisteration
    {
        public static IServiceCollection infrastructureConfiguration(this IServiceCollection services, IConfiguration confinguration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IImageManagementService , ImageManagementService>();
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")));
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(confinguration.GetConnectionString("EmployeeManagerDB"));
            });


            return services;
        }
    }
}
