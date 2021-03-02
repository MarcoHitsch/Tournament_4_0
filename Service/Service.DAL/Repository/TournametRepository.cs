using Microsoft.EntityFrameworkCore;
using Tournament40.Service.DAL.Models;
using Tournament40.Service.DAL.Repository.Contract;

namespace Tournament40.Service.DAL.Repository
{
    public class TournametRepository : BaseRepository<Tournament>, ITournametRepository
    {
        public TournametRepository(DbContext context)
            : base(context)
        {
        }
    }
}