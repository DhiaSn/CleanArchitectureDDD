using CleanArchitectureDDD.API.Extensions;
using CleanArchitectureDDD.Infrastructure;
using CleanArchitectureDDD.App;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureDDD.Infrastructure.Data;
using Serilog;

namespace CleanArchitectureDDD.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            try
            {
                Log.Information("Starting web application");

                var builder = WebApplication.CreateBuilder(args);

                builder.Host.UseSerilog();

                // Add services to the container.
                builder.Services.AddControllers();
                builder.Services.AddPersistenceInfrastructure(builder.Configuration);
                builder.Services.AddSharedInfrastructure(builder.Configuration);
                builder.Services.AddApplicationLayer(); ;

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwagger();
                builder.Services.AddHealthChecks();

                var app = builder.Build();

                app.UseSerilogRequestLogging();
                // Configure the HTTP request pipeline.
                app.UseAppSwagger();

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.UseErrorHandlingMiddleware();

                app.UseHealthChecks("/health");

                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }
    }
}
