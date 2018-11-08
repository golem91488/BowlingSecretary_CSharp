using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingSecretary.Models
{
    public class Game
    {
        public int ID { get; set; }
        public int Round { get; set; }
        public int GameNumber { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int LaneSet { get; set; }
        public bool IsProcessed { get; set; }
        public bool IsPositionRound { get; set; }
    }
}
