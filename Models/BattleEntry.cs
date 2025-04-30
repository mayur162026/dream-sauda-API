namespace Dreamsauda.Models
{
    public class BattleEntry
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }= null!;

        public int MatchId { get; set; }
        public Match Match { get; set; }= null!;

        public int TeamId { get; set; }
        public Team Team { get; set; }= null!;

        public decimal EntryFee { get; set; }
        public decimal Points { get; set; } // Calculated after match ends
        public bool IsWinner { get; set; }
    }
}
