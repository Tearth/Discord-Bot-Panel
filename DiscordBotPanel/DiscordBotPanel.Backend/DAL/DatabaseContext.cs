using DiscordBotPanel.Backend.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotPanel.Backend.DAL
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<BotModel> Bots { get; set; }
        public virtual DbSet<StatsModel> Stats { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BotModel>()
                .HasMany(p => p.Stats)
                .WithOne(p => p.Bot)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
