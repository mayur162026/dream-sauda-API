using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dreamsauda.Models
{
    public class User
    {
        [Key]  // Primary key annotation
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Identity column (auto-increment)
        public int UserId { get; set; }  // Primary key

        public string? Username { get; set; }
        public string? Password { get; set; }

         public string? Email { get; set; } // Added Email property

        // Navigation property for Teams
        public ICollection<Team> Teams { get; set; } = new List<Team>();

        // Navigation property for BattleEntries
        public ICollection<BattleEntry> BattleEntries { get; set; } = new List<BattleEntry>();
    }
}
