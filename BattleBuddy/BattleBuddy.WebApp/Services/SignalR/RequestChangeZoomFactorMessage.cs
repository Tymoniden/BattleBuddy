using BattleBuddy.Shared;
using BattleBuddy.WebApp.Services.SignalR.Messages;

namespace BattleBuddy.WebApp.Services.SignalR
{
    public class RequestChangeZoomFactorMessage : ISignalRMessage
    {
        readonly SideIdentifier _sideIdentifier;
        readonly double _zoomFactor;

        public RequestChangeZoomFactorMessage(SideIdentifier sideIdentifier, int zoomFactor)
        {
            _sideIdentifier = sideIdentifier;
            _zoomFactor = zoomFactor;
        }

        public string Name => nameof(RequestChangeZoomFactorMessage);

        public object[] Params => [_sideIdentifier, _zoomFactor];
    }
}