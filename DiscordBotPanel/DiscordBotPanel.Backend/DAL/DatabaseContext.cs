using DiscordBotPanel.Backend.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotPanel.Backend.DAL
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<BotModel> Bots { get; set; }
        public virtual DbSet<StatsModel> Stats { get; set; }

        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
