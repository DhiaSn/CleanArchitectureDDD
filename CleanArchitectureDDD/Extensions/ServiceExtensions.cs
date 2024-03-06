using Microsoft.OpenApi.Models;

namespace CleanArchitectureDDD.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(); 
        }
    }
}
