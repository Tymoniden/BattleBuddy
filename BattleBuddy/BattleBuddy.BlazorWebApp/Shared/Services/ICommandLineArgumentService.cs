﻿namespace BattleBuddy.BlazorWebApp.Shared.Services
{
    public interface ICommandLineArgumentService
    {
        public int? GetPort(string[] arguments);
        int? GetSignalRPort(string[] arguments);
    }
}
