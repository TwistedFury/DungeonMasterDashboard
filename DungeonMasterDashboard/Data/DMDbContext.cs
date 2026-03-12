using Microsoft.EntityFrameworkCore;
using DungeonMasterDashboard.Models;
using DungeonMasterDashboard.Services;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DungeonMasterDashboard.Data
{
    public class DMDbContext : DbContext
    {
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<FifthEditionMonster> FifthEditionMonsters { get; set; }
        public DbSet<CyberpunkEnemy> CyberpunkEnemies { get; set; }

        public DMDbContext(DbContextOptions<DMDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure CyberpunkEnemy
            var cyberpunkEntity = modelBuilder.Entity<CyberpunkEnemy>();

            // Primitive collection for List<string>
            cyberpunkEntity.Property(e => e.Cyberware)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>(),
                    new ValueComparer<List<string>>(
                        (c1, c2) => c1!.SequenceEqual(c2!),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()))
                .HasColumnType("nvarchar(max)");

            // Dictionary converters
            var dictionaryConverter = new ValueConverter<Dictionary<string, int>, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<Dictionary<string, int>>(v, (JsonSerializerOptions?)null) ?? new Dictionary<string, int>());

            var dictionaryComparer = new ValueComparer<Dictionary<string, int>>(
                (c1, c2) => c1!.SequenceEqual(c2!),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToDictionary(e => e.Key, e => e.Value));

            cyberpunkEntity.Property(e => e.LanguageList)
                .HasConversion(dictionaryConverter, dictionaryComparer)
                .HasColumnType("nvarchar(max)");

            cyberpunkEntity.Property(e => e.ScienceList)
                .HasConversion(dictionaryConverter, dictionaryComparer)
                .HasColumnType("nvarchar(max)");

            cyberpunkEntity.Property(e => e.MartialArtsList)
                .HasConversion(dictionaryConverter, dictionaryComparer)
                .HasColumnType("nvarchar(max)");

            cyberpunkEntity.Property(e => e.InstrumentList)
                .HasConversion(dictionaryConverter, dictionaryComparer)
                .HasColumnType("nvarchar(max)");
        }
    }
}
