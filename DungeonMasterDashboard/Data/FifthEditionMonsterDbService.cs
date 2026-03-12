using DungeonMasterDashboard.Models;
using DungeonMasterDashboard.Services;
using Microsoft.EntityFrameworkCore;

namespace DungeonMasterDashboard.Data
{
    public class FifthEditionMonsterDbService
    {
        private DMDbContext _context;

        public FifthEditionMonsterDbService(DMDbContext context)
        {
            _context = context;
        }

        public Task<List<FifthEditionMonster>> GetAllAsync() => _context.FifthEditionMonsters.ToListAsync();

        public async Task<FifthEditionMonster?> GetByIdAsync(Guid id)
        {
            return await _context.FifthEditionMonsters.FindAsync(id);
        }

        public async Task SaveAsync(FifthEditionMonster enemy)
        {
            var existing = await _context.FifthEditionMonsters.FindAsync(enemy.Id);
            if (existing == null)
            {
                await _context.FifthEditionMonsters.AddAsync(enemy);
            }
            else
            {
                _context.FifthEditionMonsters.Update(enemy);
            }
            await _context.SaveChangesAsync();
        }
    }
}
