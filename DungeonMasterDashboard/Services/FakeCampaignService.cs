using DungeonMasterDashboard.Models;

namespace DungeonMasterDashboard.Services;

public class FakeCampaignService : ICampaignService
{
    private readonly List<Campaign> _campaigns = new()
    {
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
    };

    public Task<List<Campaign>> GetAllAsync()
        => Task.FromResult(_campaigns.OrderByDescending(c => c.LastPlayed ?? DateTime.MinValue).ToList());

    public Task<Campaign?> GetByIdAsync(Guid id)
        => Task.FromResult(_campaigns.FirstOrDefault(c => c.Id == id));

    public Task SaveAsync(Campaign campaign)
    {
        var existing = _campaigns.FirstOrDefault(c => c.Id == campaign.Id);
        if (existing is null)
        {
            _campaigns.Add(campaign);
            return Task.CompletedTask;
        }

        existing.Name = campaign.Name;
        existing.System = campaign.System;
        existing.LastPlayed = campaign.LastPlayed;
        existing.Notes = campaign.Notes;

        return Task.CompletedTask;
    }
}