namespace DungeonMasterDashboard.Services
{
    public class Enemy
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public string System { get; set; } = "";
    }
}
