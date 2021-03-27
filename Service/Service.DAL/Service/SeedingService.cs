using System;
using System.Linq;
using Tournament40.Service.DAL.Models;

namespace Tournament40.Service.DAL.Service
{
    public static class SeedingService
    {
        public static void EnsureDataSeeding(TournamentContext context)
        {
            if (context.Tournaments.Any())
            {
                Console.WriteLine("Already found tournaments in the database");
            }
            else
            {
                SeedData(context);
            }
        }

        private static void SeedData(TournamentContext context)
        {
            var t1 = new Tournament()
            {
                Id = Guid.NewGuid(),
                Name = "Test-Tournament",
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date.AddDays(3),
            };

            var p1 = new Player()
            {
                Id = Guid.NewGuid(),
                Name = "Player 1",
                Firstname = "Player",
                Lastname = "One",
                TournamentId = t1.Id
            };

            var p2 = new Player()
            {
                Id = Guid.NewGuid(),
                Name = "Player 2",
                Firstname = "Player",
                Lastname = "Two",
                TournamentId = t1.Id
            };

            context.Tournaments.Add(t1);
            context.SaveChanges();

            context.Players.AddRange(p1, p2);
            context.SaveChanges();
        }
    }
}