using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using Server.Application;
using Server.Application.Common.Mappings;
using Server.Application.Interfaces;
using Server.Persistance;
using System.Reflection;

namespace Server.WebApiNet7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
                config.AddProfile(new AssemblyMappingProfile(typeof(IAccountsDbContext).Assembly));
            });

            services.AddApplication();
            services.AddPersistance(builder.Configuration);
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var contextNotes = serviceProvider.GetRequiredService<NotesDbContext>();
                    DbInitializer.Initialize(contextNotes);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.MapControllers();
            app.Run();
        }
    }
}