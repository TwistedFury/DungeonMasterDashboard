using DungeonMasterDashboard.Services;

namespace DungeonMasterDashboard.Models
{
    public class FifthEditionMonster : Enemy
    {
        //stats for 5th Edition Monster
        #region Top_Stats
        public string CreatureType { get; set; } = "";
        public string Alignment { get; set; } = "";
        public int ArmorClass { get; set; } = 10;
        public int HitPoits { get; set; } = 0;

        public Dictionary<string, int > MoveSpeeds = new Dictionary<string, int>()
        {
            {"Walk Speed", 0 },
            {"Fly Speed", 0 },
            {"Swim Speed", 0 },
            {"Climb Speed", 0 },
            {"Burrow Speed", 0 },
        };
        public int Strength { get; set; } = 10;
        public int Dexterity { get; set; } = 10;
        public int Constitution { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public int Wisdom { get; set; } = 10;
        public int Charisma { get; set; } = 10;
        #endregion

        #region Proficiencies
        public Dictionary<string, bool> SavingThrowProficiency = new Dictionary<string, bool>()
        {
            {"Strength", false},
            {"Dexterity", false},
            {"Constitution", false},
            {"Intelligence", false},
            {"Wisdom", false},
            {"Charisma", false},
        };

        public Dictionary<string, bool> SkillProficiency = new Dictionary<string, bool>()
        {
            {"Athletics", false},
            {"Acrobatics", false},
            {"Sleight of Hand", false},
            {"Stealth", false},
            {"Arcana", false},
            {"History", false},
            {"Investigation", false},
            {"Nature", false},
            {"Religion", false},
            {"Animal Handling", false},
            {"Insight", false},
            {"Medicine", false},
            {"Perception", false},
            {"Survival", false},
            {"Deception", false},
            {"Intimidation", false},
            {"Performance", false},
            {"Persuasion", false},
        };
        #endregion

        #region Vunerabilities_Resistances_and_Immunities
        public Dictionary<string, bool> DamageVulnerabilities = new Dictionary<string, bool>()
        {
            {"Bludgeoning", false},
            {"Piercing", false},
            {"Slashing", false},
            {"Fire", false},
            {"Cold", false},
            {"Acid", false},
            {"Lightning", false},
            {"Poison", false},
            {"Thunder", false},
            {"Radiant", false},
            {"Necrotic", false},
            {"Psychic", false},
            {"Force", false},
        };

        public Dictionary<string, bool> DamageResistances = new Dictionary<string, bool>()
        {
            {"Bludgeoning", false},
            {"Piercing", false},
            {"Slashing", false},
            {"Fire", false},
            {"Cold", false},
            {"Acid", false},
            {"Lightning", false},
            {"Poison", false},
            {"Thunder", false},
            {"Radiant", false},
            {"Necrotic", false},
            {"Psychic", false},
            {"Force", false},

            // Overrides for physical damage
            {"Magical", false},
            {"Silvered", false},
            {"Adamantine", false},
        };

        public Dictionary<string, bool> DamageImmunities = new Dictionary<string, bool>()
        {
            {"Bludgeoning", false},
            {"Piercing", false},
            {"Slashing", false},
            {"Fire", false},
            {"Cold", false},
            {"Acid", false},
            {"Lightning", false},
            {"Poison", false},
            {"Thunder", false},
            {"Radiant", false},
            {"Necrotic", false},
            {"Psychic", false},
            {"Force", false},

            // Overrides for physical damage
            {"Magical", false},
            {"Silvered", false},
            {"Adamantine", false},
        };

        public Dictionary<string, bool> ConditionImmunities = new Dictionary<string, bool>()
        {
            {"Blinded", false },
            {"Charmed", false },
            {"Deafened", false },
            {"Dehydration", false },
            {"Exhaustion", false },
            {"Frightened", false },
            {"Grappled", false },
            {"Incapacitated", false },
            {"Invisible", false },
            {"Magical Sleep", false },
            {"Malnutrition", false },
            {"Paralyzed", false },
            {"Petrified", false },
            {"Poisoned", false },
            {"Prone", false },
            {"Restrained", false },
            {"Stunned", false },
            {"Unconcious", false },
        };
        #endregion

        #region Extras
        public Dictionary<string, int> Senses = new Dictionary<string, int>()
        {
            {"Passive Perception", 10},
            {"Darkvision", 0},
            {"Devil's Sight", 0},
            {"Blindsight", 0},
            {"Tremorsense", 0},
            {"Truesight", 0},
        };

        public Dictionary<string, bool> Languages = new Dictionary<string, bool>()
        {
            {"Common", false},
            {"Elvish", false},
            {"Dwarvish", false},
            {"Halfing", false},
            {"Orcish", false},
            {"Gnomish", false},
            {"Goblin", false},
            {"Draconic", false},
            {"Giant", false},
            {"Abyssal", false},
            {"Celestial", false},
            {"Deep Speech", false},
            {"Infernal", false},
            {"Primordial", false},
            {"Sylvan", false},
            {"undercommon", false},
        };

        public int ProficiencyBonus = 2;

        public int ChallengeRating = 0;
        #endregion
    }
}
