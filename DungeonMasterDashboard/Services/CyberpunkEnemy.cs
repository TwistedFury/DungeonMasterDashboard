namespace DungeonMasterDashboard.Services
{
    public class CyberpunkEnemy : Enemy
    {
        #region Stats
        public int Intelligence { get; set; } = 2;
        public int Dexterity { get; set; } = 2;
        public int Reflexes { get; set; } = 2;
        public int Tech { get; set; } = 2;
        public int Cool { get; set; } = 2;
        public int Willpower { get; set; } = 2;
        public int Move { get; set; } = 2;
        public int Body { get; set; } = 2;
        public int MaxEmpathy { get; set; } = 2;
        public int CurrentEmpathy { get; set; } = 2;

        
        public int HitPoints 
        { 
            get; 
            private set => hitPointForumla((float)Willpower, (float)Body);
        }

        public int MaxHumanity
        {
            get;
            private set;
        }
        public int CurrentHumanity { get; set; }

        #endregion

        //10 + round((Willpower + Body) / 2) * 5
        public int hitPointForumla(float willpower, float body)
        {
            return (10 + (int)Math.Round((willpower + body)/2) * 5);
        }

        // max humanity is max empathy * 10 minus 2 for every piece of cyberware (not including borgware which is -4)
        // haven't thought of a way to deal with borgware yet
        public int humanityFormula(int maxEmpathy, List<string> cyberware)
        {
            return (MaxEmpathy * 10) - (cyberware.Count * 2);
        }
    }
}
