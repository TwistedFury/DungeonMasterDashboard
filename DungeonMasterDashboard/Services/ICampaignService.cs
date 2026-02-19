using DungeonMasterDashboard.Models;

namespace DungeonMasterDashboard.Services;

public interface ICampaignService
{
    Task<List<Campaign>> GetAllAsync();
    Task<Campaign?> GetByIdAsync(Guid id);
    Task SaveAsync(Campaign campaign);
}