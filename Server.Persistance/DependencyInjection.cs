using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Application.Interfaces;

namespace Server.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<NotesDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<INotesDbContext>(provider =>
                provider.GetService<NotesDbContext>());

            services.AddDbContext<AccountsDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IAccountsDbContext>(provider =>
                provider.GetService<AccountsDbContext>());



            return services;
        }

    }
}
