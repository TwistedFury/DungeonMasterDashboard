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
            migrationBuilder.DropPrimaryKey(
                name: "PK_Enemies",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Enemies");

            migrationBuilder.RenameTable(
                name: "Enemies",
                newName: "FifthEditionMonsters");

            migrationBuilder.AlterColumn<int>(
                name: "Wisdom",
                table: "FifthEditionMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Strength",
                table: "FifthEditionMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Intelligence",
                table: "FifthEditionMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HitPoits",
                table: "FifthEditionMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Dexterity",
                table: "FifthEditionMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatureType",
                table: "FifthEditionMonsters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Constitution",
                table: "FifthEditionMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Charisma",
                table: "FifthEditionMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArmorClass",
                table: "FifthEditionMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Alignment",
                table: "FifthEditionMonsters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FifthEditionMonsters",
                table: "FifthEditionMonsters",
                column: "Id");

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
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    MaxHumanity = table.Column<int>(type: "int", nullable: false),
                    CurrentHumanity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    System = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CyberpunkEnemies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CyberpunkEnemies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FifthEditionMonsters",
                table: "FifthEditionMonsters");

            migrationBuilder.RenameTable(
                name: "FifthEditionMonsters",
                newName: "Enemies");

            migrationBuilder.AlterColumn<int>(
                name: "Wisdom",
                table: "Enemies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Strength",
                table: "Enemies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Intelligence",
                table: "Enemies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HitPoits",
                table: "Enemies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Dexterity",
                table: "Enemies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatureType",
                table: "Enemies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Constitution",
                table: "Enemies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Charisma",
                table: "Enemies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ArmorClass",
                table: "Enemies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Alignment",
                table: "Enemies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Enemies",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enemies",
                table: "Enemies",
                column: "Id");
        }
    }
}
