using Microsoft.EntityFrameworkCore;
using Personas.Infra.Data.PostgreSQL.Context;

namespace Personas.Service.Api.Configurtions
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddDbContext<PersonasContext>(options => options.UseNpgsql(configuration.GetConnectionString("PersonasConnection")));
            services.AddDbContext<EventStoreSqlContext>(options => options.UseNpgsql(configuration.GetConnectionString("PersonasConnection")));
        }

    }
}
