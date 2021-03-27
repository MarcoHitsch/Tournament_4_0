using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Tournament40.Service.BLL.Players;
using Tournament40.Service.BLL.Tournaments;
using Tournament40.Service.DAL.Models;
using Tournament40.Shared.DTO;

namespace Tournament40.Service.BLL
{
    public static class BusinessLogicServiceCollectionExtension
    {
        public static void AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddScoped<ITournamentService, TournamentService>();
            services.AddScoped<IPlayerService, PlayerService>();
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Player, PlayerDto>().ReverseMap();
                cfg.CreateMap<Tournament, TournamentDto>().ReverseMap();
            });
            services.AddScoped<IMapper>(s => new Mapper(config));
        }
    }
}
