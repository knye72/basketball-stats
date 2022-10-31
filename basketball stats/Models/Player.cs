using System;
using System.Collections.Generic;
using System.Text;

namespace basketball_stats.Models
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int Age { get; set; }
        public int Rank { get; set; }

        public string Team { get; set; }
        public decimal FieldGoalPct { get; set; }
        public decimal ThreePointPct { get; set; }
        public int Points { get; set; }

    }
}
