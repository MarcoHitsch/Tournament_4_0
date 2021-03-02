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
    }
}
