using Microsoft.EntityFrameworkCore;

namespace Tournament40.Service.DAL.Service
{
    public static class MigrationService
    {
        public static void EnsureDatabaseMigration(TournamentContext context)
        {
            context.Database.Migrate();
        }
    }
}
