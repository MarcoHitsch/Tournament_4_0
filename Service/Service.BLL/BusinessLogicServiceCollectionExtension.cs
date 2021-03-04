using Microsoft.Extensions.DependencyInjection;
using Tournament40.Service.BLL.Players;
using Tournament40.Service.BLL.Tournaments;

namespace Tournament40.Service.BLL
{
    public static class BusinessLogicServiceCollectionExtension
    {
        public static void AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddScoped<ITournamentService, TournamentService>();
            services.AddScoped<IPlayerService, PlayerService>();
        }
    }
}
