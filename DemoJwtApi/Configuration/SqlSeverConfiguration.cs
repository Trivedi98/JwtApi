using DemoJwtApi.Infra.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoJwtApi.Configuration
{
    public static class SqlSeverConfiguration
    {

        public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:default"];

            services.AddDbContext<EmployeeContext>(option =>
            {
                option.UseSqlServer(connectionString, x =>
                {

                    x.MigrationsAssembly("DemoJwtApi.Infra.Domain");

                });
            }, ServiceLifetime.Singleton);

        }
    }
}
