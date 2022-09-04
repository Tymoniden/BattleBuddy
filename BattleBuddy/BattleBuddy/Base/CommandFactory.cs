using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBuddy.Base
{
    public sealed class CommandFactory
    {
        public Command Create(Action action, Func<bool> canExecuteAction)
        {
            return new Command(action, canExecuteAction);
        }
    }
}
