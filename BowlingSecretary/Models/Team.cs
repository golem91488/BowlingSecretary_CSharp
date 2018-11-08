using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingSecretary.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public League League { get; set; }
    }
}
