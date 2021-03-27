using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Tournament40.Service.DAL;
using Tournament40.Service.DAL.Models;
using Tournament40.Shared.DTO;

namespace Tournament40.Service.BLL.Tournaments
{
    public interface ITournamentService
    {
        Task<List<TournamentDto>> GetAllTournaments();

        Task<TournamentDto> GetTournamentById(Guid id);

        Task AddNewTournament(TournamentDto inputTournament);
    }

    public class TournamentService : ITournamentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TournamentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task AddNewTournament(TournamentDto inputTournament)
        {
            var model = this.mapper.Map<Tournament>(inputTournament);

            await this.unitOfWork.Tournaments.AddAsync(model);
            await this.unitOfWork.CompleteAsync();
        }

        public async Task<List<TournamentDto>> GetAllTournaments()
        {
            var models = await this.unitOfWork.Tournaments.GetAllAsync();

            return this.mapper.Map<List<TournamentDto>>(models);
        }

        public async Task<TournamentDto> GetTournamentById(Guid id)
        {
            var model = await this.unitOfWork.Tournaments.GetTournamentWithPlayers(id);

            return this.mapper.Map<TournamentDto>(model);
        }
    }
}
