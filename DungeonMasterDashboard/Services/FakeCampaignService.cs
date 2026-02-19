using DungeonMasterDashboard.Models;

namespace DungeonMasterDashboard.Services;

public class FakeCampaignService : ICampaignService
{
	// NOTE: This service stores campaigns in memory only.
	// Since it is registered as a scoped service, the data will reset if it reloads.
	// This is fine for now while we build the UI, but later we can replace this with
	// an API/database or store campaigns in LocalStorage.
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