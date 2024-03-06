using CleanArchitectureDDD.API.Middlewares;

namespace CleanArchitectureDDD.API.Extensions
{
    public static class AppExtensions
    {
        public static void UseAppSwagger(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
