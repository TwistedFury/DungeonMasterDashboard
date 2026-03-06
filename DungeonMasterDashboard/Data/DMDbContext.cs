using DungeonMasterDashboard.Models;
using DungeonMasterDashboard.Services;
using Microsoft.EntityFrameworkCore;

namespace DungeonMasterDashboard.Data
{
    public class DMDbContext : DbContext
    {
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<FifthEditionMonster> FifthEditionMonsters { get; set; }
        public DbSet<CyberpunkEnemy> CyberpunkEnemies { get; set; }

        public DMDbContext(DbContextOptions<DMDbContext> options) : base(options) {}
    }
}
