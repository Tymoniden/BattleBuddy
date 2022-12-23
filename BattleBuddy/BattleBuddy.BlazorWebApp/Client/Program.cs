using BattleBuddy.BlazorWebApp.Client;
using BattleBuddy.BlazorWebApp.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<IListViewInteractionFacade, ListViewInteractionFacade>();
builder.Services.AddSingleton<IListViewEntryProvider, ListViewEntryProvider>();

await builder.Build().RunAsync();
