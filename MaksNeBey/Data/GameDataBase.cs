using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaksNeBey.Data
{
    public class GameDataBase : DbContext
    {
        public GameDataBase(DbContextOptions<GameDataBase> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                var game = new Game
                {
                    GameID = 1,
                    Title = "Slay the spire",
                    Price = 123
                };
                Games.Add(game);
                SaveChanges();
            }

        }
        public DbSet<Game> Games { get; set; }

        public void GameAdd(string title,decimal price) 
        {
            int id = 0;
            foreach (var ID in Games.ToList()) { id = ID.GameID; }
            var game = new Game
            {
                GameID = id + 1,
                Price = price,
                Title = title
            };
            Games.Add(game);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new NpgsqlConnectionStringBuilder()
            {
                Host = "ec2-52-50-171-4.eu-west-1.compute.amazonaws.com",
                Port = 5432,
                Username = "tqduzolxnhoevk",
                Password = "f6192adfdf7edcd7d35650115f4427b06a7cc43f004d7ece2fe58d732cebd750",
                Database = "d3jm3ri2tv2l6c",
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
            optionsBuilder.UseNpgsql(builder.ToString());
        }

        public async Task<IEnumerable<Game>> GetGames() => await Games.ToListAsync();
    }
}
