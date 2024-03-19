using System;
using System.Threading.Tasks;

namespace BattleBuddy.Services.SignalR
{
    public interface ISignalRService
    {
        Task Connect(int port, string hub);
        void RegisterCallback(string method, Func<Task> callback);
        void RegisterCallback<T1, T2>(string method, Action<T1, T2> callback);
        void RegisterCallback<T1, T2>(string method, Func<T1, T2, Task> callback);
        void RegisterCallback<T1>(string method, Action<T1> callback);
        void RegisterCallback<T1>(string method, Func<T1, Task> callback);
        void RegisterCallback(string method, Action callback);
        Task SendMessage(string message);
        Task SendMessage<T>(string message, T param);
        Task SendMessage<T1, T2>(string message, T1 param1, T2 param2);
    }
}