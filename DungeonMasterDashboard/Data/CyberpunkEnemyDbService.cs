using DungeonMasterDashboard.Services;
using Microsoft.EntityFrameworkCore;

namespace DungeonMasterDashboard.Data
{
    public class CyberpunkEnemyDbService
    {
        private DMDbContext _context;

        public CyberpunkEnemyDbService(DMDbContext context)
        {
            _context = context;
        }

        public Task<List<CyberpunkEnemy>> GetAllAsync() => _context.CyberpunkEnemies.ToListAsync();

        public async Task<CyberpunkEnemy?> GetByIdAsync(Guid id)
        {
            return await _context.CyberpunkEnemies.FindAsync(id);
        }

        public async Task SaveAsync(CyberpunkEnemy enemy)
        {
            var existing = await _context.CyberpunkEnemies.FindAsync(enemy.Id);
            if (existing == null)
            {
                await _context.CyberpunkEnemies.AddAsync(enemy);
            }
            else
            {
                _context.CyberpunkEnemies.Update(enemy);
            }
            await _context.SaveChangesAsync();
        }
    }
}
