using Design_Bureau.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Design_Bureau.DbExtensions
{
    public static class DbExtensions
    {
        public static void MigrateDb(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DesignBureauDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
