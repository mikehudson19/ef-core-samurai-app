using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Database.db"); // Connecting to the database
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
            modelBuilder.Entity<Horse>().ToTable("Horses");
        }

        // using the dotnet logger factory to build a specialised console logger
        //public static readonly ILoggerFactory ConsoleLoggerFactory =
        //    LoggerFactory.Create(builder =>
        //    {
        //        builder
        //            .AddFilter((category, level) =>
        //                category == DbLoggerCategory.Database.Command.Name
        //                && level == LogLevel.Information);
        //                .AddConsole();
        //    });
    }
}
