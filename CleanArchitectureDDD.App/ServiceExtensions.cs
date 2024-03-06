using CleanArchitectureDDD.App.Interfaces;
using CleanArchitectureDDD.App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureDDD.App
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
