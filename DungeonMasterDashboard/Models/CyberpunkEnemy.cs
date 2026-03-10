using DungeonMasterDashboard.Services;
using System.ComponentModel.DataAnnotations;

namespace DungeonMasterDashboard.Models
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
        #region Skill Ranks
        #region Awareness-Skills

        [Range(2, 10)] public int ConcentrationSkill;
        [Range(0, 10)] public int ConcealRevealObjectSkill;
        [Range(0, 10)] public int LipReadingSkill;
        [Range(2, 10)] public int PerceptionSkill;
        [Range(0, 10)] public int TrackingSkill;

        #endregion
        #region Body-Skills

        [Range(2, 10)] public int AthleticsSkill;
        [Range(0, 10)] public int ContortionistSkill;
        [Range(0, 10)] public int DanceSkill;
        [Range(0, 10)] public int EnduranceSkill;
        [Range(0, 10)] public int ResistTortureDrugsSkill;
        [Range(2, 10)] public int StealthSkill;

        #endregion
        #region Control-Skills

        [Range(0, 10)] public int DriveLandVehicleSkill;
        [Range(0, 10)] public int PilotAirVehicleSkill;
        [Range(0, 10)] public int PilotSeaVehicleSkill;
        [Range(0, 10)] public int RidingSkill;

        #endregion
        #region Education-Skills

        [Range(0, 10)] public int AccountingSkill;
        [Range(0, 10)] public int AnimalHandlingSkill;
        [Range(0, 10)] public int BeaurecracySkill;
        [Range(0, 10)] public int BusinessSkill;
        [Range(0, 10)] public int CompositionSkill;
        [Range(0, 10)] public int CriminologySkill;
        [Range(0, 10)] public int CryptographySkill;
        [Range(0, 10)] public int DeductionSkill;
        [Range(2, 10)] public int EducationSkill;
        [Range(0, 10)] public int GambleSkill;

        [Range(4, 10)] public int NativeLanguageSkill;
        [Range(2, 10)] public int StreetSlangSkill;
        Dictionary<string, int> LanguageList = new Dictionary<string, int>()
        {

        };

        [Range(0, 10)] public int LibrarySearchSkill;

        Dictionary<string, int> ScienceList = new Dictionary<string, int>()
        {

        };

        [Range(0, 10)] public int TacticsSkill;
        [Range(0, 10)] public int WildernessSurvivalSkill;

        #endregion
        #region Fighting-Skills
        [Range(2, 10)] public int BrawlingSkill;
        [Range(2, 10)] public int EvasionSkill;

        Dictionary<string, int> MartialArtsList = new Dictionary<string, int>()
        {

        };

        [Range(0, 10)] public int MeleeWeaponsSkill;

        #endregion
        #region Performance-Skills

        [Range(0, 10)] public int ActingSkill;
        Dictionary<string, int> InstrumentList = new Dictionary<string, int>()
        {

        };

        #endregion
        #region Ranged-Weapon-Skills

        [Range(0, 10)] public int ArcherySkill;
        [Range(0, 10)] public int AutofireSkill;
        [Range(0, 10)] public int HandgunsSkill;
        [Range(0, 10)] public int HeavyWeaponsSkill;
        [Range(0, 10)] public int ShoulderArmsSkill;

        #endregion
        #region Social-Skills

        [Range(0, 10)] public int BriberySkill;
        [Range(2, 10)] public int ConversationSkill;
        [Range(0, 10)] public int HumanPerceptionSkill;
        [Range(2, 10)] public int InterogationSkill;
        [Range(2, 10)] public int PersuasionSkill;
        [Range(0, 10)] public int PersonalGroomingSkill;
        [Range(0, 10)] public int StreetwiseSkill;
        [Range(0, 10)] public int TradingSkill;
        [Range(0, 10)] public int WardrobeAndStyleSkill;

        #endregion
        #region Technique-Skills

        [Range(0, 10)] public int AirVehicleTechSkill;
        [Range(0, 10)] public int BasicTechSkill;
        [Range(0, 10)] public int CybertechSkill;
        [Range(0, 10)] public int DemolitionsSkill;
        [Range(0, 10)] public int ElectronicsSecurityTechSkill;
        [Range(2, 10)] public int FirstAidSkill;
        [Range(0, 10)] public int ForgerySkill;
        [Range(0, 10)] public int LandVehicleTechSkill;
        [Range(0, 10)] public int ParamedicSkill;
        [Range(0, 10)] public int PhotographyFilmSkill;
        [Range(0, 10)] public int PickLockSkill;
        [Range(0, 10)] public int PickPocketSkill;
        [Range(0, 10)] public int SeaVehicleTechSkill;
        [Range(0, 10)] public int WeaponstechSkill;

        #endregion
        #endregion

        List<string> Cyberware = new List<string>();
    }
}
