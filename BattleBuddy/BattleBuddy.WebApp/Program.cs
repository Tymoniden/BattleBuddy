using BattleBuddy.WebApp.Data;
using BattleBuddy.WebApp.Services;
using BattleBuddy.WebApp.Services.SignalR;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

/* Auslagern, wenn zu viel */
builder.Services.AddSingleton<ScoreService>();
builder.Services.AddSingleton<Score>();
builder.Services.AddSingleton<ArmyListService>();
builder.Services.AddScoped<SignalRClientService>();
builder.Services.AddScoped<SignalRMessagingService>();
/* Auslagern, wenn zu viel */

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] {"application/octet-stream"});
});

var app = builder.Build();
app.UseResponseCompression();

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
app.MapHub<BbHub>("GameHub");

app.MapFallbackToPage("/_Host");

app.Run();
