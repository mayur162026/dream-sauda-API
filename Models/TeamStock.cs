namespace Dreamsauda.Models
{
    public class TeamStock
    {
        public int Id { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }= null!;

        public int StockId { get; set; }
        public Stock Stock { get; set; }= null!;
    }
}