
using System;
using System.Collections.Generic;

namespace Dreamsauda.Models
{
    public class Match
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Status { get; set; } = null!;// Upcoming, Ongoing, Completed
        public List<BattleEntry> BattleEntries { get; set; } = new(); // ✅ Recommended
    }
}