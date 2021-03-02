using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tournament40.Service.BLL;
using Tournament40.Service.DAL;

namespace Tournament40.Service.Root
{
    public static class DependencyInjection
    {
        public static void InjectDependencies(
            IServiceCollection serviceCollection,
            string environmentName,
            IConfiguration configuration)
        {
            serviceCollection.AddDatabaseServices(environmentName, configuration);
            serviceCollection.AddDataAccessLayer();
            serviceCollection.AddBusinessLogicLayer();
        }

        private static void AddDatabaseServices(
            this IServiceCollection services,
            string environmentName,
            IConfiguration configuration)
        {
            services.AddDbContextPool<TournamentContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Database"));
            });
        }
    }
}
