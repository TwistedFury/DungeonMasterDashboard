namespace DungeonMasterDashboard.Models;

public class Campaign
{
	// Guid instead of int so we an generate unique IDs before connecting to database
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public string System { get; set; } = "D&D 5e";
    public DateTime? LastPlayed { get; set; }
    public string Notes { get; set; } = "";
}