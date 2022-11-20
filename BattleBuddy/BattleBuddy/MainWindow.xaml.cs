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
            ServiceLocatorService.GetInstance<IApplicationEnvironmentService>().SetupEnvironment();
            ServiceLocatorService.GetInstance<IWindowModeService>().StateChangeEvent += StateChangeEvent;
            DataContext = mainViewModel;
        }

        private void StateChangeEvent(object? sender, System.EventArgs e)
        {
            if (e is StateChangedEventArgs stateChangedEventArgs)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    switch (stateChangedEventArgs.State)
                    {
                        case Services.WindowState.Normal:
                            WindowStyle = WindowStyle.SingleBorderWindow;
                            WindowState = System.Windows.WindowState.Normal;
                            ResizeMode = ResizeMode.CanResize;
                            Topmost = false;
                            break;

                        case Services.WindowState.Maximized:
                            WindowStyle = WindowStyle.SingleBorderWindow;
                            WindowState = System.Windows.WindowState.Maximized;
                            ResizeMode = ResizeMode.CanResize;
                            Topmost = false;
                            break;

                        case Services.WindowState.Fullscreen:
                            Visibility = Visibility.Collapsed;
                            WindowStyle = WindowStyle.None;
                            ResizeMode = ResizeMode.NoResize;
                            WindowState = System.Windows.WindowState.Maximized;
                            Topmost = true;
                            Visibility = Visibility.Visible;
                            break;
                    }
                });
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ServiceLocatorService.GetInstance<IHotKeyService>().ExecuteHotkey(e.Key, Keyboard.Modifiers);
        }
    }
}
