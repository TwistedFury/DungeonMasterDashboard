using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Calculated property - not mapped to database
        [NotMapped]
        public int HitPoints => hitPointForumla((float)Willpower, (float)Body);

        public int MaxHumanity { get; set; }
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
        #region Skill Ranks
        #region Awareness-Skills

        [Range(2, 10)] public int ConcentrationSkill { get; set; }
        [Range(0, 10)] public int ConcealRevealObjectSkill { get; set; }
        [Range(0, 10)] public int LipReadingSkill { get; set; }
        [Range(2, 10)] public int PerceptionSkill { get; set; }
        [Range(0, 10)] public int TrackingSkill { get; set; }

        #endregion
        #region Body-Skills

        [Range(2, 10)] public int AthleticsSkill { get; set; }
        [Range(0, 10)] public int ContortionistSkill { get; set; }
        [Range(0, 10)] public int DanceSkill { get; set; }
        [Range(0, 10)] public int EnduranceSkill { get; set; }
        [Range(0, 10)] public int ResistTortureDrugsSkill { get; set; }
        [Range(2, 10)] public int StealthSkill { get; set; }

        #endregion
        #region Control-Skills

        [Range(0, 10)] public int DriveLandVehicleSkill { get; set; }
        [Range(0, 10)] public int PilotAirVehicleSkill { get; set; }
        [Range(0, 10)] public int PilotSeaVehicleSkill { get; set; }
        [Range(0, 10)] public int RidingSkill { get; set; }

        #endregion
        #region Education-Skills

        [Range(0, 10)] public int AccountingSkill { get; set; }
        [Range(0, 10)] public int AnimalHandlingSkill { get; set; }
        [Range(0, 10)] public int BeaurecracySkill { get; set; }
        [Range(0, 10)] public int BusinessSkill { get; set; }
        [Range(0, 10)] public int CompositionSkill { get; set; }
        [Range(0, 10)] public int CriminologySkill { get; set; }
        [Range(0, 10)] public int CryptographySkill { get; set; }
        [Range(0, 10)] public int DeductionSkill { get; set; }
        [Range(2, 10)] public int EducationSkill { get; set; }
        [Range(0, 10)] public int GambleSkill { get; set; }

        [Range(4, 10)] public int NativeLanguageSkill { get; set; }
        [Range(2, 10)] public int StreetSlangSkill { get; set; }

        // Stored as JSON in database
        public Dictionary<string, int> LanguageList { get; set; } = new Dictionary<string, int>();

        [Range(0, 10)] public int LibrarySearchSkill { get; set; }

        public Dictionary<string, int> ScienceList { get; set; } = new Dictionary<string, int>();

        [Range(0, 10)] public int TacticsSkill { get; set; }
        [Range(0, 10)] public int WildernessSurvivalSkill { get; set; }

        #endregion
        #region Fighting-Skills
        [Range(2, 10)] public int BrawlingSkill { get; set; }
        [Range(2, 10)] public int EvasionSkill { get; set; }

        public Dictionary<string, int> MartialArtsList { get; set; } = new Dictionary<string, int>();

        [Range(0, 10)] public int MeleeWeaponsSkill { get; set; }

        #endregion
        #region Performance-Skills

        [Range(0, 10)] public int ActingSkill { get; set; }
        
        public Dictionary<string, int> InstrumentList { get; set; } = new Dictionary<string, int>();

        #endregion
        #region Ranged-Weapon-Skills

        [Range(0, 10)] public int ArcherySkill { get; set; }
        [Range(0, 10)] public int AutofireSkill { get; set; }
        [Range(0, 10)] public int HandgunsSkill { get; set; }
        [Range(0, 10)] public int HeavyWeaponsSkill { get; set; }
        [Range(0, 10)] public int ShoulderArmsSkill { get; set; }

        #endregion
        #region Social-Skills

        [Range(0, 10)] public int BriberySkill { get; set; }
        [Range(2, 10)] public int ConversationSkill { get; set; }
        [Range(0, 10)] public int HumanPerceptionSkill { get; set; }
        [Range(2, 10)] public int InterogationSkill { get; set; }
        [Range(2, 10)] public int PersuasionSkill { get; set; }
        [Range(0, 10)] public int PersonalGroomingSkill { get; set; }
        [Range(0, 10)] public int StreetwiseSkill { get; set; }
        [Range(0, 10)] public int TradingSkill { get; set; }
        [Range(0, 10)] public int WardrobeAndStyleSkill { get; set; }

        #endregion
        #region Technique-Skills

        [Range(0, 10)] public int AirVehicleTechSkill { get; set; }
        [Range(0, 10)] public int BasicTechSkill { get; set; }
        [Range(0, 10)] public int CybertechSkill { get; set; }
        [Range(0, 10)] public int DemolitionsSkill { get; set; }
        [Range(0, 10)] public int ElectronicsSecurityTechSkill { get; set; }
        [Range(2, 10)] public int FirstAidSkill { get; set; }
        [Range(0, 10)] public int ForgerySkill { get; set; }
        [Range(0, 10)] public int LandVehicleTechSkill { get; set; }
        [Range(0, 10)] public int ParamedicSkill { get; set; }
        [Range(0, 10)] public int PhotographyFilmSkill { get; set; }
        [Range(0, 10)] public int PickLockSkill { get; set; }
        [Range(0, 10)] public int PickPocketSkill { get; set; }
        [Range(0, 10)] public int SeaVehicleTechSkill { get; set; }
        [Range(0, 10)] public int WeaponstechSkill { get; set; }

        #endregion
        #endregion

        // Stored as JSON in database
        public List<string> Cyberware { get; set; } = new List<string>();
    }
}
