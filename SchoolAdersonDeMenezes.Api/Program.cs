using SchoolAdersonDeMenezes.Application;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using SchoolAdersonDeMenezes.Infraestructure;

namespace SchoolAdersonDeMenezes.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHandlers();
            builder.Services.AddMongo();
            builder.Services.AddRepository();
            builder.Services.AddConsulConfig();
            builder.Services.AddNotificationServiceIntegration();
            builder.Services.AddHttpClient();
            builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            builder.Services.AddSwaggerGen(x =>
            {
                x.ExampleFilters();
            });
            builder.Services.AddMessageBus();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseConsul();

            app.MapControllers();

            app.Run();
        }
    }
}