using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BowlingSecretary.Models;

namespace BowlingSecretary.Models
{
    public class BowlingSecretaryContext : DbContext
    {
        public BowlingSecretaryContext (DbContextOptions<BowlingSecretaryContext> options)
            : base(options)
        {
        }

        public DbSet<BowlingSecretary.Models.League> League { get; set; }

        public DbSet<BowlingSecretary.Models.Team> Team { get; set; }

        public DbSet<BowlingSecretary.Models.Bowler> Bowler { get; set; }

        public DbSet<BowlingSecretary.Models.Game> Game { get; set; }

        public DbSet<BowlingSecretary.Models.BowlerScore> BowlerScore { get; set; }
    }
}
