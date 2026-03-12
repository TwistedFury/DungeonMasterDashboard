# DungeonMasterDashboard

A web-based dashboard for Dungeons & Dragons Dungeon Masters, built with Blazor WebAssembly and hosted on GitHub Pages.

## Features

- 🔐 **Authentication** – Secure sign-in via OpenID Connect (Azure AD / Auth0)
- 🏠 **Home Page** – Personalized welcome screen for authenticated users
- 🔢 **Counter** – Interactive counter component (protected route)
- 🌤️ **Weather** – Sample data-fetching component
- 📱 **Responsive UI** – Bootstrap 5 for mobile-friendly layouts
- ⚡ **PWA Support** – Service worker for offline capability
- 🚀 **GitHub Pages Deployment** – Automated CI/CD via GitHub Actions

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Framework | [.NET 10 Blazor WebAssembly](https://learn.microsoft.com/aspnet/core/blazor/) |
| Language | C# / Razor |
| UI | [Bootstrap 5](https://getbootstrap.com/) |
| Authentication | OIDC via `Microsoft.AspNetCore.Components.WebAssembly.Authentication` |
| ORM | Entity Framework Core 10 |
| Hosting | GitHub Pages |
| CI/CD | GitHub Actions |

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- An Azure AD (or compatible OIDC provider) application registration for authentication

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/TwistedFury/DungeonMasterDashboard.git
cd DungeonMasterDashboard
```

### 2. Configure authentication

Update `wwwroot/appsettings.json` with your OIDC provider details:

```json
{
  "AzureAd": {
    "Authority": "https://login.microsoftonline.com/<your-tenant-id>",
    "ClientId": "<your-client-id>",
    "ValidateAuthority": true
  }
}
```

### 3. Run locally

```bash
dotnet run
```

The application will be available at:
- **HTTPS:** `https://localhost:7277`
- **HTTP:** `http://localhost:5095`

## Building for Production

```bash
dotnet publish DungeonMasterDashboard.csproj -c Release -o public
```

## Deployment

The project is automatically deployed to GitHub Pages on every push to the `master` branch via the workflow defined in `.github/workflows/gh-pages.yml`.

The pipeline:
1. Builds and publishes the Blazor WASM app in Release mode
2. Adds a `.nojekyll` file so GitHub Pages does not skip the `_framework` folder
3. Copies `index.html` to `404.html` to enable client-side routing fallbacks
4. Rewrites the `<base href>` tag for the GitHub Pages subdirectory path
5. Deploys the output to the `gh-pages` branch

## Project Structure

```
DungeonMasterDashboard/
├── Layout/                 # Blazor layout components (MainLayout, NavMenu, etc.)
├── Pages/                  # Routable Razor pages
│   ├── Home.razor
│   ├── Counter.razor
│   ├── Weather.razor
│   └── Authentication.razor
├── wwwroot/                # Static web assets (CSS, JS, images, appsettings)
├── App.razor               # Root component and router
├── Program.cs              # Application entry point and DI configuration
└── .github/workflows/      # CI/CD pipeline definitions
```

## Contributing

Contributions are welcome! Feel free to open an issue or submit a pull request.

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/your-feature`)
3. Commit your changes (`git commit -m 'Add your feature'`)
4. Push to the branch (`git push origin feature/your-feature`)
5. Open a Pull Request