
using LifeOps.Application.Interface;
using LifeOps.Application.Service;
using LifeOps.Infrastructure.Persistence;

namespace LifeOps.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Services
            builder.Services.AddScoped<IReflectionService, ReflectionService>();
            builder.Services.AddScoped<IReflectionRepository, InMemoryReflectionRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
