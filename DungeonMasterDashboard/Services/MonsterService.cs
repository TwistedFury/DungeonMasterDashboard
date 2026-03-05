using DungeonMasterDashboard.Models;

namespace DungeonMasterDashboard.Services
{
    public class MonsterService : IEnemyService
    {
        public Task<List<FifthEditionMonster>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FifthEditionMonster?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(FifthEditionMonster monster)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        Task<List<Enemy>> IEnemyService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Enemy?> IEnemyService.GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
