using Microsoft.EntityFrameworkCore;
using Tournament40.Service.DAL.Models;
using Tournament40.Service.DAL.Repository.Contract;

namespace Tournament40.Service.DAL.Repository
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbContext context)
            : base(context)
        {
        }
    }
}
