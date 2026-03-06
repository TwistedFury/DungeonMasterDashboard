using System.ComponentModel.DataAnnotations;

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

        // skills list
        // all skills rank 0-10 except certain skills which a character MUST have 2 ranks in
        #region Skills
        #region Awareness-Skills

        [Range(2, 10)] int Concentration;
        [Range(0, 10)] int ConcealRevealObject;
        [Range(0, 10)] int LipReading;
        [Range(2, 10)] int Perception;
        [Range(0, 10)] int Tracking;

        #endregion
        #region Body-Skills

        [Range(2, 10)] int Athletics;
        [Range(0, 10)] int Contortionist;
        [Range(0, 10)] int Dance;
        [Range(0, 10)] int Endurance;
        [Range(0, 10)] int ResistTortureDrugs;
        [Range(2, 10)] int Stealth;

        #endregion
        #region Control-Skills

        [Range(0, 10)] int DriveLandVehicle;
        [Range(0, 10)] int PilotAirVehicle;
        [Range(0, 10)] int PilotSeaVehicle;
        [Range(0, 10)] int Riding;

        #endregion
        #region Education-Skills

        [Range(0, 10)] int Accounting;
        [Range(0, 10)] int AnimalHandling;
        [Range(0, 10)] int Beaurecracy;
        [Range(0, 10)] int Business;
        [Range(0, 10)] int Composition;
        [Range(0, 10)] int Criminology;
        [Range(0, 10)] int Cryptography;
        [Range(0, 10)] int Deduction;
        [Range(2, 10)] int Education;
        [Range(0, 10)] int Gamble;

        [Range(4, 10)] int NativeLanguage;
        [Range(2, 10)] int StreetSlang;
        Dictionary<string, int> LanguageList = new Dictionary<string, int>()
        {

        };

        [Range(0, 10)] int LibrarySearch;

        Dictionary<string, int> ScienceList = new Dictionary<string, int>()
        {

        };

        [Range(0, 10)] int Tactics;
        [Range(0, 10)] int WildernessSurvival;

        #endregion
        #region Fighting-Skills
        [Range(2, 10)] int Brawling;
        [Range(2, 10)] int Evasion;

        Dictionary<string, int> MartialArtsList = new Dictionary<string, int>()
        {

        };

        [Range(0, 10)] int MeleeWeapons;

        #endregion
        #region Performance-Skills

        [Range(0, 10)] int Acting;
        Dictionary<string, int> InstrumentList = new Dictionary<string, int>()
        {

        };

        #endregion
        #region Ranged-Weapon-Skills

        [Range(0, 10)] int Archery;
        [Range(0, 10)] int Autofire;
        [Range(0, 10)] int Handguns;
        [Range(0, 10)] int HeavyWeapons;
        [Range(0, 10)] int ShoulderArms;

        #endregion
        #region Social-Skills

        [Range(0, 10)] int Bribery;
        [Range(2, 10)] int Conversation;
        [Range(0, 10)] int HumanPerception;
        [Range(2, 10)] int Interogation;
        [Range(2, 10)] int Persuasion;
        [Range(0, 10)] int PersonalGrooming;
        [Range(0, 10)] int Streetwise;
        [Range(0, 10)] int Trading;
        [Range(0, 10)] int WardrobeAndStyle;

        #endregion
        #region Technique-Skills

        [Range(0, 10)] int AirVehicleTech;
        [Range(0, 10)] int BasicTech;
        [Range(0, 10)] int Cybertech;
        [Range(0, 10)] int Demolitions;
        [Range(0, 10)] int ElectronicsSecurityTech;
        [Range(2, 10)] int FirstAid;
        [Range(0, 10)] int Forgery;
        [Range(0, 10)] int LandVehicleTech;
        [Range(0, 10)] int Paramedic;
        [Range(0, 10)] int PhotographyFilm;
        [Range(0, 10)] int PickLock;
        [Range(0, 10)] int PickPocket;
        [Range(0, 10)] int SeaVehicleTech;
        [Range(0, 10)] int Weaponstech;

        #endregion
        #endregion

        List<string> Cyberware = new List<string>();
    }
}
