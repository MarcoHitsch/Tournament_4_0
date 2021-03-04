using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tournament40.Service.DAL.Models;

namespace Tournament40.Service.DAL
{
    public class TournamentContext : DbContext
    {
        public TournamentContext(DbContextOptions<TournamentContext> options) 
            : base(options)
        { }

        public DbSet<Tournament> Tournaments { get; set; }
        
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>().HasOne(x => x.Tournament).WithMany(x => x.Players).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
