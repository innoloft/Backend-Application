using Backend_Application.WebAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Application.WebAPI
{
    public static class DatabaseConfig
    {
        public static void MigrateAndSeedDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var databaseContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
                databaseContext.Database.Migrate();

                var softwareType = databaseContext.Types.FirstOrDefault(t => t.Name == "Software");
                if(softwareType is null)
                {
                    databaseContext.Types.Add(new Entities.Type("Software", "Software image Url"));
                    databaseContext.SaveChanges();
                }
                var hardwareType = databaseContext.Types.FirstOrDefault(t => t.Name == "Hardware");
                if(hardwareType is null)
                {
                    databaseContext.Types.Add(new Entities.Type("Hardware", "Hardware image Url"));
                    databaseContext.SaveChanges();
                }
                
            }
        }
    }
}
