﻿using BattleBuddy.WebApp.Services.SignalR.Messages;

namespace BattleBuddy.WebApp.Services.SignalR;

public class RequestListUpdateMessage : ISignalRMessage
{
    public string Name => nameof(GameHub.RequestListUpdateMessage);

    public object[] Params => Array.Empty<object>();
}