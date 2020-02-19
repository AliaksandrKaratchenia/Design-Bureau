using Design_Bureau.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Design_Bureau.Api.Configuration
{
    public static class DbContextConfig
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblyName = typeof(DesignBureauDbContext).Namespace;
            var connectionString = configuration["SqlConnectionConfig:ConnectionString"];
            services.AddDbContext<DesignBureauDbContext>(o =>
                o.UseSqlServer(connectionString, b =>
                {
                    b.MigrationsAssembly(assemblyName);
                    b.CommandTimeout(300);
                }));
        }
    }
}
