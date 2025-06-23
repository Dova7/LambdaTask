using LambdaTask.Extensions;
using LambdaTask.MiddleWare;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace LambdaTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.AddSerilog();
            builder.AddControllers();
            builder.AddEndpointsApiExplorer();
            builder.AddSwaggerGen();
            builder.AddIdentity();
            builder.AddDatabaseContext();
            builder.ConfigureJwtOptions();
            builder.AddAuthentication();
            builder.AddScopedServices();
            builder.AddHttpContextAccessor();
            builder.AddAutomapper();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSerilogRequestLogging();
            app.UseMiddleware<ExceptionHandler>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
