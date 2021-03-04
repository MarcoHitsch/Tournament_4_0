using System.Threading.Tasks;
using Tournament40.Service.DAL.Repository.Contract;

namespace Tournament40.Service.DAL
{
    public interface IUnitOfWork
    {
        ITournametRepository Tournaments { get; }

        IPlayerRepository Players { get; }

        Task<int> CompleteAsync();
    }
}