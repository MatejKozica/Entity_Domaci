using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Data.Models;

namespace Manager.Data
{
    public class MatchContext : DbContext
    {
        public MatchContext() : base("MatchDB")
        {
            Database.SetInitializer(new MatchDbIniatializer());
        }


        public DbSet<Player> Players { get; set; } 
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matchs { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
    }
}
