using Microsoft.EntityFrameworkCore;
using OnlineGameSaleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGameSaleApp.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> dbContext) : base(dbContext) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<UserApp> UserApps { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAppsGames>()
                .HasKey(b=> new { b.GameId,b.UserAppId});

            modelBuilder.Entity<UserAppsGames>()
                .HasOne(x => x.Game)
                    .WithMany(x => x.UserAppsGames)
                        .HasForeignKey(x=>x.GameId);

            modelBuilder.Entity<UserAppsGames>()
                .HasOne(x => x.UserApp)
                    .WithMany(x => x.UserAppsGames)
                        .HasForeignKey(x=>x.UserAppId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
