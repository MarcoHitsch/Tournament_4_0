using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper mapper;

        public PlayerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task AddNewPlayer(PlayerDto inputPlayer)
        {
            var model = this.mapper.Map<Player>(inputPlayer);

            await this.unitOfWork.Players.AddAsync(model);
            await this.unitOfWork.CompleteAsync();
        }

        public async Task<List<PlayerDto>> GetAllPlayers()
        {
            var models = await this.unitOfWork.Players.GetAllAsync();

            return this.mapper.Map<List<PlayerDto>>(models);
        }

        public async Task<PlayerDto> GetPlayerById(Guid id)
        {
            var model = await this.unitOfWork.Players.GetAsync(id);

            return this.mapper.Map<PlayerDto>(model);
        }
    }
}
