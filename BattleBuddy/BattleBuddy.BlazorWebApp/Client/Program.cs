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
builder.Services.AddSingleton<ISignalRService, SignalRService>();

var webAssemblyHost = builder.Build();

var signalRService = webAssemblyHost.Services.GetService<ISignalRService>();
if(signalRService != null){
    var signalRConfiguration = new SignalRConfiguration
    {
        Host = "localhost",
        Port = 5010,
        HubName = "battleBuddyHub"
    };

    await signalRService.StartUp(signalRConfiguration);
}


await webAssemblyHost.RunAsync();
