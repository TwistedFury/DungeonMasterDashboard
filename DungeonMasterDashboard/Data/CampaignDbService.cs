using DungeonMasterDashboard.Components.Pages;
using DungeonMasterDashboard.Data;
using DungeonMasterDashboard.Models;
using DungeonMasterDashboard.Services;
using Microsoft.EntityFrameworkCore;
using DbFactory = Microsoft.EntityFrameworkCore.IDbContextFactory<DungeonMasterDashboard.Data.DMDbContext>;

namespace DungeonMasterDashboard.Data
{
    public class CampaignDbService : ICampaignService
    {
        private readonly DbFactory _dbFactory;
        private DMDbContext _context;

        public CampaignDbService(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _context = _dbFactory.CreateDbContext();
        }

        public async Task SaveAsync(Campaign campaign)
        {
            var existing = await _context.Campaigns.FindAsync(campaign.Id);
            if (existing == null)
            {
                await _context.Campaigns.AddAsync(campaign);
            }
            else
            {
                _context.Campaigns.Update(campaign);
            }
            await _context.SaveChangesAsync();
        }

        public Task<List<Campaign>> GetAllAsync() => Task.FromResult(_context.Campaigns.OrderByDescending(c => c.LastPlayed ?? DateTime.MinValue).ToList());

        public async Task<Campaign?> GetByIdAsync(Guid id)
        {
            return await _context.Campaigns.FindAsync(id);
        }
    }
}
