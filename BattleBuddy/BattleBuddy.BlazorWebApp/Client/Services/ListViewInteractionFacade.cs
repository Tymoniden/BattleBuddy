using BattleBuddy.BlazorWebApp.Shared.Enums;

namespace BattleBuddy.BlazorWebApp.Client.Services
{
    public class ListViewInteractionFacade : IListViewInteractionFacade
    {
        private readonly ISignalRService _signalRService;

        public ListViewInteractionFacade(ISignalRService signalRService)
        {
            _signalRService = signalRService ?? throw new ArgumentNullException(nameof(signalRService));
        }

        public async Task ExpandLeft()
        {
            await _signalRService.Send(nameof(SignalRMessages.RequestFocus), LayoutValue.Left);
        }

        public async Task ExpandRight()
        {
            await _signalRService.Send(nameof(SignalRMessages.RequestFocus), LayoutValue.Right);
        }

        public async Task JustifyBoth()
        {
            await _signalRService.Send(nameof(SignalRMessages.RequestFocus), LayoutValue.Justify);
        }

        public async Task ReloadLists()
        {
            await _signalRService.Send(nameof(SignalRMessages.RequestReload));
        }

        public async Task ScrollToEntry(ListViewIdentifier listViewIdentifier, int index)
        {
            //await _hubConnection.SendAsync("RequestReload");
        }

        public async Task ScrollToPercentage(ListViewIdentifier listViewIdentifier, int percentage)
        {
            //await _hubConnection.SendAsync("RequestReload");
        }
    }
}
