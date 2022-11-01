using BattleBuddy.Services;
using BattleBuddy.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace BattleBuddy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            var mainViewModel = ServiceLocatorService.GetInstance<MainViewModel>();
            mainViewModel.Setup();
            DataContext = mainViewModel;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ServiceLocatorService.GetInstance<IHotKeyService>().ExecuteHotkey(e.Key, Keyboard.Modifiers);
        }
    }
}
