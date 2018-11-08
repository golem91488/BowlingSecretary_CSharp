using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingSecretary.Models
{
    public class League
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int NumberOfLanes { get; set; }
        public int PositionRounds { get; set; }
        public int BowlersPerTeam { get; set; }
    }
}
