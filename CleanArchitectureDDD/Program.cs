using CleanArchitectureDDD.API.Extensions;
using CleanArchitectureDDD.Infrastructure;
using CleanArchitectureDDD.App;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureDDD.Infrastructure.Data;
using Serilog;
using Serilog.Extensions.Hosting;

namespace CleanArchitectureDDD.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .Enrich.FromLogContext()
                .WriteTo.File($"logs/CleanArchitectureLog-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Services.AddControllers();

            builder.Host.UseSerilog();

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddPersistenceInfrastructure(builder.Configuration);
            builder.Services.AddSharedInfrastructure(builder.Configuration);
            builder.Services.AddApplicationLayer();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger();
            builder.Services.AddHealthChecks();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseAppSwagger();

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseErrorHandlingMiddleware();

            app.UseHealthChecks("/health");

            app.MapControllers();

            app.Run();

        }
    }
}
