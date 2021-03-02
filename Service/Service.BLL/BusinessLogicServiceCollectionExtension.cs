using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tournament40.Service.BLL.Tournaments;

namespace Tournament40.Service.BLL
{
    public static class BusinessLogicServiceCollectionExtension
    {
        public static void AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddScoped<ITournamentService, TournamentService>();
        }
    }
}
