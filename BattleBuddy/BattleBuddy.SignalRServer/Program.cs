using BattleBuddy.SignalRServer.Hubs;
using BattleBuddy.SignalRServer.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.VisualBasic;

const string CorsPolicy = nameof(CorsPolicy);

var builder = WebApplication.CreateBuilder(args);

var port = new CommandLineArgumentService().GetPort(args);

// Add services to the container.
builder.Services.AddSignalR(options => options.EnableDetailedErrors = true);


builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: CorsPolicy,
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
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
    app.Urls.Add($"http://0.0.0.0:{port}");
}

app.UseCors(CorsPolicy);

// Configure the HTTP request pipeline.
app.UseResponseCompression();

app.MapHub<BattleBuddyHub>("/battleBuddyHub");

app.Run();
