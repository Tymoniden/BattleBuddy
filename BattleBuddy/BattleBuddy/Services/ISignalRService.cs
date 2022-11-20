using System;
using System.Threading.Tasks;

namespace BattleBuddy.Services
{
    public interface ISignalRService
    {
        void Connect(int port, string hub);
        void RegisterCallback(string method, Func<Task> callback);
        void RegisterCallback<T1, T2>(string method, Action<T1, T2> callback);
        void RegisterCallback<T1, T2>(string method, Func<T1, T2, Task> callback);
        void RegisterCallback<T1>(string method, Action<T1> callback);
        void RegisterCallback<T1>(string method, Func<T1, Task> callback);
    }
}