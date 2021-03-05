using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tournament40.Service.DAL.Models;
using Tournament40.Service.DAL.Repository.Contract;

namespace Tournament40.Service.DAL.Repository
{
    public class TournametRepository : BaseRepository<Tournament>, ITournametRepository
    {
        private readonly TournamentContext context;

        public TournametRepository(TournamentContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<Tournament> GetTournamentWithPlayers(Guid tournamentId)
        {
            return await context.Tournaments.Include(x => x.Players).SingleOrDefaultAsync(x => x.Id == tournamentId);
        }
    }
}