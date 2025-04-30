using System.Collections.Generic;

namespace Dreamsauda.Models
{
    public class User
    {
        public int UserId { get; set; } // Primary key
        public string? Username { get; set; }
        public string? Password { get; set; }

        // Navigation property for Teams
        public ICollection<Team> Teams { get; set; } = new List<Team>();

        // Navigation property for BattleEntries
        public ICollection<BattleEntry> BattleEntries { get; set; } = new List<BattleEntry>();
    }
}