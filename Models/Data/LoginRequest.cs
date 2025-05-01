using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dreamsauda.Models
{
    public class LoginRequest
    {
        [Key] // Explicitly mark UserId as the primary key
        public int UserId { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }
         public string? Email { get; set; } // Added Email property

        // Navigation property for Teams
        public ICollection<Team> Teams { get; set; } = new List<Team>();

        // Navigation property for BattleEntries
        public ICollection<BattleEntry> BattleEntries { get; set; } = new List<BattleEntry>();
    }
}
