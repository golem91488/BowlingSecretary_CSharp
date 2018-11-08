using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingSecretary.Models
{
    public class Bowler
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CurrentAverage { get; set; }
        public Team Team { get; set; }
        public League League { get; set; }
    }
}
