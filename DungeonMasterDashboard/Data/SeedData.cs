
// This is currently only for seeding 5e Monsters
using Microsoft.EntityFrameworkCore;
using DungeonMasterDashboard.Models;

namespace DungeonMasterDashboard.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new DMDbContext(serviceProvider.GetRequiredService<
                DbContextOptions<DMDbContext>>());

            if (context == null || context.FifthEditionMonsters == null)
            {
                throw new NullReferenceException(
                    "Null DMDbContext or FifthEditionMonsters DbSet");
            }

            if (context.FifthEditionMonsters.Any())
            {
                return;
            }

            context.FifthEditionMonsters.AddRange(
                new FifthEditionMonster
                {
                    CreatureType = "Seeded Monster",
                    Alignment = "Neutral",
                    Name = "Seeded Monster",
                    System = "D&D 5e"
                }
            );

            context.SaveChanges();

            // Campaign Seeding

            if (context.Campaigns == null || context.Campaigns.Any()) { return; }

            context.Campaigns.AddRange(
                new Campaign
                {
                    Name = "The Sunken Cathedral",
                    System = "D&D 5e",
                    LastPlayed = DateTime.Today.AddDays(-7),
                    Notes = "Party reached level 4. Next: boss in the crypt."
                },
                new Campaign
                {
                    Name = "Neon Wasteland",
                    System = "Cyberpunk RED",
                    LastPlayed = DateTime.Today.AddDays(-21),
                    Notes = "Fixer contact owes them a favor."
                }
            );

            context.SaveChanges();
        }
    }
}
