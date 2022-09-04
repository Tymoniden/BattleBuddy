using System.Windows;
using System.Windows.Controls;

namespace BattleBuddy.Ui
{
    /// <summary>
    /// Interaction logic for Key.xaml
    /// </summary>
    public partial class Key : UserControl
    {
        public Key()
        {
            InitializeComponent();
        }

        public string KeyName
        {
            get { return (string)GetValue(KeyNameProperty); }
            set { SetValue(KeyNameProperty, value); }
        }

        public static readonly DependencyProperty KeyNameProperty =
            DependencyProperty.Register(nameof(KeyName), typeof(string), typeof(Key), new PropertyMetadata(string.Empty));
    }
}
