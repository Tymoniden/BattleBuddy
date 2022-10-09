using System.Reflection.Metadata;
using System.Windows.Input;

namespace BattleBuddy.ViewModel
{
    public class HotKeyViewModel
    {
        public HotKeyViewModel()
        {
            
        }

        public string KeyDescription => Key.ToString();

        public Key Key { get; set; }

        public bool Shift { get; set; }

        public bool Control { get; set; }

        public bool Alt { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
