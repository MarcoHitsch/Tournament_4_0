using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament40.Service.DAL;
using Tournament40.Service.DAL.Models;
using Tournament40.Shared.DTO;

namespace Tournament40.Service.BLL.Players
{
    public interface IPlayerService
    {
        Task<List<PlayerDto>> GetAllPlayers();

        Task<PlayerDto> GetPlayerById(Guid id);

        Task AddNewPlayer(PlayerDto inputPlayer);
    }

    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork unitOfWork;

        public PlayerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddNewPlayer(PlayerDto inputPlayer)
        {
            var model = new Player()
            {
                Id = inputPlayer.Id,
                Name = inputPlayer.Name,
                Firstname = inputPlayer.Firstname,
                Lastname = inputPlayer.Lastname,
                AssignedPartnerId = inputPlayer.AssignedPartnerId,
                TournamentId = inputPlayer.TournamentId
            };

            await this.unitOfWork.Players.AddAsync(model);
            await this.unitOfWork.CompleteAsync();
        }

        public async Task<List<PlayerDto>> GetAllPlayers()
        {
            var models = await this.unitOfWork.Players.GetAllAsync();
            return models.Select(m => new PlayerDto()
            {
                Id = m.Id,
                Name = m.Name,
                Firstname = m.Firstname,
                Lastname = m.Lastname,
                AssignedPartnerId = m.AssignedPartnerId,
                TournamentId = m.TournamentId 
            }).ToList();
        }

        public async Task<PlayerDto> GetPlayerById(Guid id)
        {
            var model = await this.unitOfWork.Players.GetAsync(id);
            return new PlayerDto()
            {
                Id = model.Id,
                Name = model.Name,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                AssignedPartnerId = model.AssignedPartnerId,
                TournamentId = model.TournamentId
            };
        }
    }
}
