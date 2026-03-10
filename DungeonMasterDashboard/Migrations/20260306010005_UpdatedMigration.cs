using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeonMasterDashboard.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    System = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastPlayed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CyberpunkEnemies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Reflexes = table.Column<int>(type: "int", nullable: false),
                    Tech = table.Column<int>(type: "int", nullable: false),
                    Cool = table.Column<int>(type: "int", nullable: false),
                    Willpower = table.Column<int>(type: "int", nullable: false),
                    Move = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<int>(type: "int", nullable: false),
                    MaxEmpathy = table.Column<int>(type: "int", nullable: false),
                    CurrentEmpathy = table.Column<int>(type: "int", nullable: false),
                    MaxHumanity = table.Column<int>(type: "int", nullable: false),
                    CurrentHumanity = table.Column<int>(type: "int", nullable: false),
                    ConcentrationSkill = table.Column<int>(type: "int", nullable: false),
                    ConcealRevealObjectSkill = table.Column<int>(type: "int", nullable: false),
                    LipReadingSkill = table.Column<int>(type: "int", nullable: false),
                    PerceptionSkill = table.Column<int>(type: "int", nullable: false),
                    TrackingSkill = table.Column<int>(type: "int", nullable: false),
                    AthleticsSkill = table.Column<int>(type: "int", nullable: false),
                    ContortionistSkill = table.Column<int>(type: "int", nullable: false),
                    DanceSkill = table.Column<int>(type: "int", nullable: false),
                    EnduranceSkill = table.Column<int>(type: "int", nullable: false),
                    ResistTortureDrugsSkill = table.Column<int>(type: "int", nullable: false),
                    StealthSkill = table.Column<int>(type: "int", nullable: false),
                    DriveLandVehicleSkill = table.Column<int>(type: "int", nullable: false),
                    PilotAirVehicleSkill = table.Column<int>(type: "int", nullable: false),
                    PilotSeaVehicleSkill = table.Column<int>(type: "int", nullable: false),
                    RidingSkill = table.Column<int>(type: "int", nullable: false),
                    AccountingSkill = table.Column<int>(type: "int", nullable: false),
                    AnimalHandlingSkill = table.Column<int>(type: "int", nullable: false),
                    BeaurecracySkill = table.Column<int>(type: "int", nullable: false),
                    BusinessSkill = table.Column<int>(type: "int", nullable: false),
                    CompositionSkill = table.Column<int>(type: "int", nullable: false),
                    CriminologySkill = table.Column<int>(type: "int", nullable: false),
                    CryptographySkill = table.Column<int>(type: "int", nullable: false),
                    DeductionSkill = table.Column<int>(type: "int", nullable: false),
                    EducationSkill = table.Column<int>(type: "int", nullable: false),
                    GambleSkill = table.Column<int>(type: "int", nullable: false),
                    NativeLanguageSkill = table.Column<int>(type: "int", nullable: false),
                    StreetSlangSkill = table.Column<int>(type: "int", nullable: false),
                    LanguageList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibrarySearchSkill = table.Column<int>(type: "int", nullable: false),
                    ScienceList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TacticsSkill = table.Column<int>(type: "int", nullable: false),
                    WildernessSurvivalSkill = table.Column<int>(type: "int", nullable: false),
                    BrawlingSkill = table.Column<int>(type: "int", nullable: false),
                    EvasionSkill = table.Column<int>(type: "int", nullable: false),
                    MartialArtsList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeleeWeaponsSkill = table.Column<int>(type: "int", nullable: false),
                    ActingSkill = table.Column<int>(type: "int", nullable: false),
                    InstrumentList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArcherySkill = table.Column<int>(type: "int", nullable: false),
                    AutofireSkill = table.Column<int>(type: "int", nullable: false),
                    HandgunsSkill = table.Column<int>(type: "int", nullable: false),
                    HeavyWeaponsSkill = table.Column<int>(type: "int", nullable: false),
                    ShoulderArmsSkill = table.Column<int>(type: "int", nullable: false),
                    BriberySkill = table.Column<int>(type: "int", nullable: false),
                    ConversationSkill = table.Column<int>(type: "int", nullable: false),
                    HumanPerceptionSkill = table.Column<int>(type: "int", nullable: false),
                    InterogationSkill = table.Column<int>(type: "int", nullable: false),
                    PersuasionSkill = table.Column<int>(type: "int", nullable: false),
                    PersonalGroomingSkill = table.Column<int>(type: "int", nullable: false),
                    StreetwiseSkill = table.Column<int>(type: "int", nullable: false),
                    TradingSkill = table.Column<int>(type: "int", nullable: false),
                    WardrobeAndStyleSkill = table.Column<int>(type: "int", nullable: false),
                    AirVehicleTechSkill = table.Column<int>(type: "int", nullable: false),
                    BasicTechSkill = table.Column<int>(type: "int", nullable: false),
                    CybertechSkill = table.Column<int>(type: "int", nullable: false),
                    DemolitionsSkill = table.Column<int>(type: "int", nullable: false),
                    ElectronicsSecurityTechSkill = table.Column<int>(type: "int", nullable: false),
                    FirstAidSkill = table.Column<int>(type: "int", nullable: false),
                    ForgerySkill = table.Column<int>(type: "int", nullable: false),
                    LandVehicleTechSkill = table.Column<int>(type: "int", nullable: false),
                    ParamedicSkill = table.Column<int>(type: "int", nullable: false),
                    PhotographyFilmSkill = table.Column<int>(type: "int", nullable: false),
                    PickLockSkill = table.Column<int>(type: "int", nullable: false),
                    PickPocketSkill = table.Column<int>(type: "int", nullable: false),
                    SeaVehicleTechSkill = table.Column<int>(type: "int", nullable: false),
                    WeaponstechSkill = table.Column<int>(type: "int", nullable: false),
                    Cyberware = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    System = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CyberpunkEnemies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FifthEditionMonsters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatureType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alignment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmorClass = table.Column<int>(type: "int", nullable: false),
                    HitPoits = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    System = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FifthEditionMonsters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "CyberpunkEnemies");

            migrationBuilder.DropTable(
                name: "FifthEditionMonsters");
        }
    }
}
