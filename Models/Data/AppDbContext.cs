using Microsoft.EntityFrameworkCore;
using Dreamsauda.Models;

namespace Dreamsauda.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> LoginUser { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamStock> TeamStocks { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<BattleEntry> BattleEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User ↔ Team (1:N)
            modelBuilder.Entity<Team>()
                .HasOne(t => t.User)
                .WithMany(u => u.Teams) // Ensure User has a Teams navigation property
                .HasForeignKey(t => t.UserId);

            // Team ↔ TeamStock (1:N)
            modelBuilder.Entity<TeamStock>()
                .HasOne(ts => ts.Team)
                .WithMany(t => t.TeamStocks)
                .HasForeignKey(ts => ts.TeamId);

            // Stock ↔ TeamStock (1:N)
            modelBuilder.Entity<TeamStock>()
                .HasOne(ts => ts.Stock)
                .WithMany(s => s.TeamStocks)
                .HasForeignKey(ts => ts.StockId);

            // Explicitly configure UserId as the primary key for the User entity
            modelBuilder.Entity<LoginRequest>()
                .HasKey(u => u.UserId);
            // User ↔ BattleEntry (1:N)
            modelBuilder.Entity<BattleEntry>()
                .HasOne(be => be.User)
                .WithMany(u => u.BattleEntries)
                .HasForeignKey(be => be.UserId);

            // Match ↔ BattleEntry (1:N)
            modelBuilder.Entity<BattleEntry>()
                .HasOne(be => be.Match)
                .WithMany(m => m.BattleEntries)
                .HasForeignKey(be => be.MatchId);

            // Team ↔ BattleEntry (1:N)
            modelBuilder.Entity<BattleEntry>()
                .HasOne(be => be.Team)
                .WithMany(t => t.BattleEntries)
                .HasForeignKey(be => be.TeamId);

            // Unique constraint for TeamStock: (TeamId + StockId)
            modelBuilder.Entity<TeamStock>()
                .HasIndex(ts => new { ts.TeamId, ts.StockId })
                .IsUnique();

            // Decimal precision for financial fields
            modelBuilder.Entity<BattleEntry>()
                .Property(b => b.EntryFee)
                .HasPrecision(18, 4);

            modelBuilder.Entity<BattleEntry>()
                .Property(b => b.Points)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Stock>()
                .Property(s => s.CurrentPrice)
                .HasPrecision(18, 4);

            /*modelBuilder.Entity<User>()
                .Property(u => u.WalletBalance)
                .HasPrecision(18, 4);*/
        }
    }
}
