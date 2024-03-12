using CleanArchitectureDDD.gRPC.Services;

namespace CleanArchitectureDDD.gRPC.Exentions
{
    public static class AppExtensions
    {
        public static void AddGrpcServices(this WebApplication? app)
        {
            app?.MapGrpcService<GreeterService>(); 
            app?.MapGrpcService<ClientService>(); 
        }

        public static void UseAppSwagger(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
