using Microsoft.OpenApi.Models;

namespace CleanArchitectureDDD.gRPC.Exentions
{
    public static class ServiceExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddGrpcSwagger();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "gRPC transcoding", Version = "v1" });
            });
        }
    }
}
