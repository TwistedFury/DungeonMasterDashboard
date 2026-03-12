# Dungeon Master Dashboard

A full-featured campaign management dashboard for tabletop RPG game masters. Built with ASP.NET Core Blazor Server, it allows dungeon masters to organise campaigns, manage NPC/monster stat blocks across multiple RPG systems, and control user access through JWT authentication.

## Features

- **Campaign Management** – Create, view, and edit campaigns. Track the game system, last played date, and session notes.
- **Monster & Enemy Database** – Manage stat blocks for multiple RPG systems:
  - **D&D 5th Edition** – Full stat block support including ability scores, saving throws, skill proficiencies, damage types (vulnerabilities, resistances, immunities), condition immunities, senses, languages, challenge rating, and more.
  - **Cyberpunk RED** – Character stats including ability scores, skills, humanity/empathy tracking, and cyberware lists.
  - **Vampire: The Masquerade** – Basic character model included.
- **Authentication & Authorisation** – User registration and login with JWT-based authentication stored in an HttpOnly cookie.
- **Responsive UI** – Bootstrap 5 design with interactive Blazor Server components and QuickGrid-powered data tables.

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Framework | ASP.NET Core / Blazor Server (.NET 10) |
| Language | C# |
| UI | Blazor components + Bootstrap 5 |
| Database | SQL Server / Azure SQL |
| ORM | Entity Framework Core 10 |
| Authentication | JWT + HttpOnly Cookies |
| Data Grid | `Microsoft.AspNetCore.Components.QuickGrid` |

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- SQL Server instance **or** an Azure SQL database
- (Optional) Visual Studio 2022+ or VS Code with the C# extension

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/TwistedFury/DungeonMasterDashboard.git
cd DungeonMasterDashboard
```

### 2. Configure the database connection

Add a `ConnectionStrings:DefaultConnection` entry to `appsettings.Development.json` (or use User Secrets):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<your-server>;Database=DungeonMasterDashboard;..."
  }
}
```

Update the JWT settings in `appsettings.json` with a strong secret key before deploying to production:

```json
{
  "Jwt": {
    "Issuer": "YourIssuer",
    "Audience": "YourAudience",
    "Key": "your-secure-secret-key"
  }
}
```

### 3. Apply database migrations

```bash
cd DungeonMasterDashboard
dotnet ef database update
```

### 4. (Optional) Seed the database

After the application is running, send a POST request to the `/seed` endpoint to populate the database with sample data:

```bash
curl -X POST https://localhost:7169/seed
```

### 5. Run the application

```bash
dotnet run --project DungeonMasterDashboard
```

The application will be available at `https://localhost:7169`.

Alternatively, open `DungeonMasterDashboard.slnx` in Visual Studio and press **F5**.

## Project Structure

```
DungeonMasterDashboard/
├── Components/
│   ├── Layout/          # MainLayout, NavMenu, ReconnectModal
│   └── Pages/
│       ├── Authentication/  # Login, Register, Logout pages
│       ├── Campaigns.razor  # Campaign list (QuickGrid)
│       ├── CampaignEdit.razor
│       ├── Monsters.razor   # D&D 5e monster list (QuickGrid)
│       └── MonstersCRUD.razor
├── Data/
│   ├── DMDbContext.cs              # EF Core DbContext
│   ├── CampaignDbService.cs
│   ├── FifthEditionMonsterDbService.cs
│   ├── CyberpunkEnemyDbService.cs
│   └── SeedData.cs
├── Models/
│   ├── Campaign.cs
│   ├── FifthEditionMonster.cs
│   ├── CyberpunkEnemy.cs
│   ├── VTMEnemy.cs
│   └── CustomAuthStateProvider.cs
├── Services/
│   ├── UserService.cs
│   ├── MonsterService.cs
│   └── FakeCampaignService.cs     # In-memory implementation for testing
├── Migrations/                    # EF Core migration history
├── Program.cs                     # App entry point & DI configuration
└── appsettings.json
```

## Authentication

The application uses JWT tokens stored in an HttpOnly cookie named `DMDAuth`.

- **Register** at `/register` to create a new account.
- **Login** at `/login` — on success a signed JWT (30-minute expiry) is issued and stored in the cookie.
- **Logout** at `/logout` to clear the session.

Authenticated state is managed by a custom `CustomAuthStateProvider` that reads the cookie on each Blazor circuit start.

## Database Schema

| Table | Key Columns |
|-------|-------------|
| `Campaigns` | `Id` (Guid), `Name`, `System`, `LastPlayed`, `Notes` |
| `FifthEditionMonsters` | Full D&D 5e stat block; complex properties (dictionaries, lists) stored as JSON columns |
| `CyberpunkEnemies` | Cyberpunk RED stats; complex properties stored as JSON columns |
