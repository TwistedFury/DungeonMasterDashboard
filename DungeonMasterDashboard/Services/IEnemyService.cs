using DungeonMasterDashboard.Models;

namespace DungeonMasterDashboard.Services
{
    public interface IEnemyService
    {
        Task<List<Enemy>> GetAllAsync();
        Task<Enemy?> GetByIdAsync(Guid id);
        Task SaveAsync(Enemy enemy);
    }
}
