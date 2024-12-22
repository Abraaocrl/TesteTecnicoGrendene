using Microsoft.EntityFrameworkCore;
using TesteTecnicoGrendene.Data;

namespace TesteTecnicoGrendene.Configuration
{
    public static class ContextConfig
    {
        public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            var connectionString = configuration.GetConnectionString("SQLiteConnection");

            builder.Services.AddDbContext<AppDbContext>((options) =>
            {
                options.UseSqlite(connectionString);
            });

            return builder;
        }
    }
}
