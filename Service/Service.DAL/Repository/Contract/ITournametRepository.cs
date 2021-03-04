using System;
using System.Threading.Tasks;
using Tournament40.Service.DAL.Models;

namespace Tournament40.Service.DAL.Repository.Contract
{
    public interface ITournametRepository : IBaseRepository<Tournament>
    {
        Task<Tournament> GetTournamentWithPlayers(Guid tournamentId);
    }

}
