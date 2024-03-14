using BattleBuddy.BlazorWebApp.Server.Services;
using BattleBuddy.BlazorWebApp.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddBattleBuddyServices();

var app = builder.Build();

var port = new CommandLineArgumentService().GetPort(args);
if (port != null)
{
    app.Urls.Add($"http://localhost:{port}");
    app.Urls.Add($"http://0.0.0.0:{port}");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
