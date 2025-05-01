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

            modelBuilder.Entity<Team>()
                .HasOne(t => t.User)
                .WithMany(u => u.Teams)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<TeamStock>()
                .HasOne(ts => ts.Team)
                .WithMany(t => t.TeamStocks)
                .HasForeignKey(ts => ts.TeamId);

            modelBuilder.Entity<TeamStock>()
                .HasOne(ts => ts.Stock)
                .WithMany(s => s.TeamStocks)
                .HasForeignKey(ts => ts.StockId);

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<BattleEntry>()
                .HasOne(be => be.User)
                .WithMany(u => u.BattleEntries)
                .HasForeignKey(be => be.UserId);

            modelBuilder.Entity<BattleEntry>()
                .HasOne(be => be.Match)
                .WithMany(m => m.BattleEntries)
                .HasForeignKey(be => be.MatchId);

            modelBuilder.Entity<BattleEntry>()
                .HasOne(be => be.Team)
                .WithMany(t => t.BattleEntries)
                .HasForeignKey(be => be.TeamId);

            modelBuilder.Entity<TeamStock>()
                .HasIndex(ts => new { ts.TeamId, ts.StockId })
                .IsUnique();

            modelBuilder.Entity<BattleEntry>()
                .Property(b => b.EntryFee).HasPrecision(18, 4);

            modelBuilder.Entity<BattleEntry>()
                .Property(b => b.Points).HasPrecision(18, 4);

            modelBuilder.Entity<Stock>()
                .Property(s => s.CurrentPrice).HasPrecision(18, 4);
        }
    }
}
