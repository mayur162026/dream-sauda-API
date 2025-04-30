using System.Collections.Generic;

namespace Dreamsauda.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int UserId { get; set; }

        // Navigation property for User
        public User? User { get; set; }

        // Navigation property for TeamStocks
        public ICollection<TeamStock> TeamStocks { get; set; } = new List<TeamStock>();

        // Navigation property for BattleEntries
        public ICollection<BattleEntry> BattleEntries { get; set; } = new List<BattleEntry>();
    }
}