using Microsoft.AspNetCore.Authentication.Cookies;
using FootballApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using BCrypt.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FootballLeagueContext>(options =>
    options.UseSqlite("Data Source=footballleague.db"));

// Cookie authentication + access denied
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseMiddleware<ApiKeyAuthMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seeding
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FootballLeagueContext>();

    context.Database.EnsureCreated();

    // Admin user seed
    if (!context.Users.Any())
    {
        var adminUser = new User
        {
            Username = "admin",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"),
            Role = "Admin"
        };
        context.Users.Add(adminUser);
        context.SaveChanges();
    }

    if (!context.Druzyny.Any())
    {
        var json = File.ReadAllText("Data/seed_druzyny.json");
        var druzyny = System.Text.Json.JsonSerializer.Deserialize<List<Druzyna>>(json);
        context.Druzyny.AddRange(druzyny);
        context.SaveChanges();
    }

    if (!context.Zawodnicy.Any())
    {
        var json = File.ReadAllText("Data/seed_zawodnicy.json");
        var zawodnicy = System.Text.Json.JsonSerializer.Deserialize<List<Zawodnik>>(json);
        context.Zawodnicy.AddRange(zawodnicy);
        context.SaveChanges();
    }

    if (!context.Mecze.Any())
    {
        var json = File.ReadAllText("Data/seed_mecze.json");
        var mecze = System.Text.Json.JsonSerializer.Deserialize<List<Mecz>>(json);
        context.Mecze.AddRange(mecze);
        context.SaveChanges();
    }

    if (!context.StatystykiZawodnikow.Any())
    {
        var json = File.ReadAllText("Data/seed_statystyki.json");
        var statystyki = System.Text.Json.JsonSerializer.Deserialize<List<StatystykiZawodnika>>(json);
        context.StatystykiZawodnikow.AddRange(statystyki);
        context.SaveChanges();
    }
}

app.Run();
