using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingSecretary.Models
{
    public class BowlerScore
    {
        public int ID { get; set; }
        public Bowler Bowler { get; set; }
        public Team Team { get; set; }
        public int Score { get; set; }
        public int Handicap { get; set; }
        public Game Game { get; set; }
    }
}
