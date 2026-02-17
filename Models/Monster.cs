namespace DungeonMasterDashboard.Models
{
    public class Monster
    {
        public int AC { get; set; }
        public int MaxHeatlh { get; set; }
        public Dictionary<string, int> Speed = new Dictionary<string, int>()
        {
            {"WalkSpeed", 0},
            {"SwimSpeed", 0},
            {"ClimbSpeed", 0},
            {"BurrowSpeed", 0},
            {"FlySpeed", 0},
            {"HoverSpeed", 0},
        };
        public byte STR { get; set; }
        public byte DEX { get; set; }
        public byte CON { get; set; }
        public byte INT { get; set; }
        public byte WIS { get; set; }
        public byte CHA { get; set; }

        public List<Saves>? SaveProficiency { get; set; }
        public List<Skills>? SkillProficiency { get; set; }
        public List<DamageTypes>? Vulnerabilities { get; set; }
        public List<DamageTypes>? Resistances { get; set; }
        public List<DamageTypes>? DamageImmunites { get; set; }
        public List<Conditions>? ConditionImmunities { get; set; }
        public Dictionary<string, int> Senses = new Dictionary<string, int>()
        {
            {"PassivePerception", 10},
            {"PassiveInsight", 10},
            {"Darkvision", 0},
            {"Tremorsense", 0},
            {"Blindsight", 0},
            {"Devil's Sight", 0},
            {"Truesight", 0},
        };
        public List<Languages> LanguageList { get; set; }
        public byte ProficiencyBonus { get; set; }
    }

    public enum Saves
    {
        STR, DEX, CON, INT, WIS, CHA,
    }

    public enum Skills
    {
        Athletics, Acrobatics, SleightOfHand, Stealth, Arcana, History, Investigation, Nature, Religion, AnimalHandling, 
        Insight, Medicine, Perception, Surival, Deception, Intimidation, Performance, Persuasion
    }

    public enum DamageTypes
    {
        Piercing, Slashing, Bludgeoning, Fire, Cold, Acid, Thunder, Lightning, Poison, Radiant, Necrotic, Psychic, Force
    }

    public enum Conditions
    {
        Bane, Banished, Blinded, Charmed, Cursed, Deafened, Diseased, Dehydrated, Exhaustion, Frightened, Grappled, Incapacitated, 
        Invisible, Malnurished, Paralyzed, Petrified, Poisoned, Restrained, Stunned, Suffocation, Unconcious
    }

    public enum Languages
    {
        Common, Draconic, Elvish, Dwarvish, Giant, Gnomish, Goblin, Orcish, Halfing, Abyssal, Celestial, DeepSpeech, Infernal,
        Primordial, Ignan, Aquan, Auran, Terran, Sylvan, Undercommon, Druidic, ThievesCant
    }
}
