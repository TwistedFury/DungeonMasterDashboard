using DungeonMasterDashboard;
using DungeonMasterDashboard.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("name=DefaultConnection");
});

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
});

await builder.Build().RunAsync();
