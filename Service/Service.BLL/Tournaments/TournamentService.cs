using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public TournamentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddNewTournament(TournamentDto inputTournament)
        {
            var model = new Tournament()
            {
                Id = inputTournament.Id,
                Name = inputTournament.Name,
                StartDate = inputTournament.StartDate,
                EndDate = inputTournament.EndDate
            };

            await this.unitOfWork.Tournaments.AddAsync(model);
            await this.unitOfWork.CompleteAsync();
        }

        public async Task<List<TournamentDto>> GetAllTournaments()
        {
            var models = await this.unitOfWork.Tournaments.GetAllAsync();
            return models.Select(m => new TournamentDto()
            {
                Id = m.Id,
                Name = m.Name,
                StartDate = m.StartDate,
                EndDate = m.EndDate
            }).ToList();
        }

        public async Task<TournamentDto> GetTournamentById(Guid id)
        {
            var model = await this.unitOfWork.Tournaments.GetAsync(id);
            return new TournamentDto()
            {
                Id = model.Id,
                Name = model.Name,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };
        }
    }
}
