using System.ComponentModel.DataAnnotations;

namespace DungeonMasterDashboard.Services
{
    public class VTMEnemy : Enemy
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public string System { get; set; } = "";


        #region Attributes
        [Range(1, 5)] int Strength;
        [Range(1, 5)] int Dexterity;
        [Range(1, 5)] int Stamina;
        [Range(1, 5)] int Charisma;
        [Range(1, 5)] int Manipulation;
        [Range(1, 5)] int Composure;
        [Range(1, 5)] int Intelligence;
        [Range(1, 5)] int Wits;
        [Range(1, 5)] int Resolve;

        #endregion

        #region Skills
        [Range(1, 5)] int Athletics;
        [Range(1, 5)] int Brawl;
        [Range(1, 5)] int Craft;
        [Range(1, 5)] int Drive;
        [Range(1, 5)] int Firearms;
        [Range(1, 5)] int Larceny;
        [Range(1, 5)] int Melee;
        [Range(1, 5)] int Stealth;
        [Range(1, 5)] int Survival;

        [Range(1, 5)] int AnimalKen;
        [Range(1, 5)] int Etiquette;
        [Range(1, 5)] int Insight;
        [Range(1, 5)] int Intimidation;
        [Range(1, 5)] int Leadership;
        [Range(1, 5)] int Performance;
        [Range(1, 5)] int Persuasion;
        [Range(1, 5)] int Streetwise;
        [Range(1, 5)] int Subterfuge;
        [Range(1, 5)] int Academics;

        [Range(1, 5)] int Awarness;
        [Range(1, 5)] int Finance;
        [Range(1, 5)] int Investigation;
        [Range(1, 5)] int Medicine;
        [Range(1, 5)] int Occult;
        [Range(1, 5)] int Politics;
        [Range(1, 5)] int Science;
        [Range(1, 5)] int Technology;

        #endregion


    }
}
