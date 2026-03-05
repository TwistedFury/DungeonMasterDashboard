using DungeonMasterDashboard;
using DungeonMasterDashboard.Components;
using DungeonMasterDashboard.Data;
using DungeonMasterDashboard.Models;
using DungeonMasterDashboard.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<UserService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<ICampaignService, FakeCampaignService>();
builder.Services.AddSingleton<IEnemyService, MonsterService>();

builder.Services.AddDbContextFactory<DMDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddQuickGridEntityFrameworkAdapter();

var app = builder.Build();

// Seed data if none exists
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/auth/signin", (HttpContext ctx, string token) =>
{
    ctx.Response.Cookies.Append(
        BlazorConstants.AuthCookieName,
        token,
        new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTimeOffset.UtcNow.AddMinutes(30),
            SameSite = SameSiteMode.Lax,
            Secure = true // HTTPS only
        });

    return Results.Redirect("/");
});

app.Run();
