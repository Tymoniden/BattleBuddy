using BattleBuddy.SignalRServer.Hubs;
using BattleBuddy.SignalRServer.Services;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

var port = new CommandLineArgumentService().GetPort(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
});

builder.Services.AddSingleton<IEntryValueStore, EntryValueStore>();
builder.Services.AddSingleton<ICommandLineArgumentService, CommandLineArgumentService>();

var app = builder.Build();

if (port != null)
{
    app.Urls.Add($"http://localhost:{port}");
}

// Configure the HTTP request pipeline.
app.UseResponseCompression();

app.MapHub<BattleBuddyHub>("/battleBuddyHub");

app.Run();
