using DungeonMasterDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace DungeonMasterDashboard.Data
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var factory = serviceProvider.GetRequiredService<IDbContextFactory<DMDbContext>>();
            await using var context = await factory.CreateDbContextAsync();

            if (context.FifthEditionMonsters == null)
                throw new NullReferenceException("Null DbSet FifthEditionMonsters");

            if (!await context.FifthEditionMonsters.AnyAsync())
            {
                context.FifthEditionMonsters.Add(
                    new FifthEditionMonster
                    {
                        CreatureType = "Seeded Monster",
                        Alignment = "Neutral",
                        Name = "Seeded Monster",
                        System = "D&D 5e"
                    }
                );

                await context.SaveChangesAsync();
            }

            if (context.Campaigns == null)
                throw new NullReferenceException("Null DbSet Campaigns");

            if (!await context.Campaigns.AnyAsync())
            {
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

                await context.SaveChangesAsync();
            }
        }
    }
}