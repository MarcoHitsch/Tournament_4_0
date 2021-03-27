using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tournament40.Service.DAL;
using Tournament40.Service.DAL.Service;

namespace Tournament40.Service.Root
{
    public static class DbStartup
    {
        public static void EnsureDatabaseInitialization(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<TournamentContext>();

                    MigrationService.EnsureDatabaseMigration(context);
                    SeedingService.EnsureDataSeeding(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred creating the DB.\r\n{ex}");
                }
            }
        }
    }
}