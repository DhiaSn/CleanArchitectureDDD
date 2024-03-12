using CleanArchitectureDDD.gRPC.Exentions;
using CleanArchitectureDDD.gRPC.Services;
using CleanArchitectureDDD.Infrastructure;
using CleanArchitectureDDD.App;

namespace CleanArchitectureDDD.gRPC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddGrpc().AddJsonTranscoding();
            builder.Services.AddSwagger(); 
            builder.Services.AddPersistenceInfrastructure(builder.Configuration);
            builder.Services.AddSharedInfrastructure(builder.Configuration);
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            app.UseAppSwagger(); 

            // Configure the HTTP request pipeline.
            app.AddGrpcServices();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}