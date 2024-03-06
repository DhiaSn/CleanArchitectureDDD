using CleanArchitectureDDD.Core.Interfaces;
using CleanArchitectureDDD.Core.Repositories;
using CleanArchitectureDDD.Infrastructure.Data;
using CleanArchitectureDDD.Infrastructure.Interfaces;
using CleanArchitectureDDD.Infrastructure.Repositories;
using CleanArchitectureDDD.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureDDD.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            }
            
            #region Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IClientRepository, ClientRepository>();
            #endregion
        }

        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.AddSingleton<IDateTimeService, DateTimeService>();
        }
    }
}
