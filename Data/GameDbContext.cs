using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using RPGGame.Models.Models;
using System.Reflection;

namespace RPGGame.Data
{
    public class GameDbContext : DbContext
    {
        public DbSet<GameModel> Games { get; set; }
        public DbSet<HeroModel> Heroes { get; set; }
        public DbSet<MonsterModel> Monsters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=IVANLAPTOP\\SQLEXPRESS01;Database=RPGGameDb3;Trusted_Connection=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}