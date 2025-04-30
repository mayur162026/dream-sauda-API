using System.Collections.Generic;

namespace Dreamsauda.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal CurrentPrice { get; set; }

        // Navigation property for TeamStocks
        public ICollection<TeamStock> TeamStocks { get; set; } = new List<TeamStock>();
    }
}