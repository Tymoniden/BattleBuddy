using BattleBuddy.WebApp;
using BattleBuddy.WebApp.Services;
using BattleBuddy.WebApp.Services.SignalR;
using BattleBuddy.WebApp.StateContainers;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

/* Auslagern, wenn zu viel */
builder.Services.AddSingleton<ScoreService>();
builder.Services.AddSingleton<Game>();
builder.Services.AddSingleton<GameScore>();
builder.Services.AddSingleton<ArmyListService>();
builder.Services.AddScoped<SignalRClientService>();
builder.Services.AddScoped<SignalRMessagingService>();
builder.Services.AddScoped<SessionConfiguration>();
builder.Services.AddSingleton<SignalRMessageFactory>();
/* Auslagern, wenn zu viel */

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] {"application/octet-stream"});
});

var app = builder.Build();
app.UseResponseCompression();
app.InitializeApplication();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapHub<GameHub>("GameHub");

app.MapFallbackToPage("/_Host");

app.Run();
