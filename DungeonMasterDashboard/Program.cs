using DungeonMasterDashboard;
using DungeonMasterDashboard.Components;
using DungeonMasterDashboard.Models;
using DungeonMasterDashboard.Services;
using Microsoft.AspNetCore.Components.Authorization;

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


var app = builder.Build();

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
