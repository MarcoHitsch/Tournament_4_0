using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tournament40.Service.DAL
{
    public static class DataAccessServiceCollectionExtension
    {
        public static void AddDataAccessLayer(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
