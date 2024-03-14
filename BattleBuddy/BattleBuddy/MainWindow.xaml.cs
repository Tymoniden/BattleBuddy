using BattleBuddy.Services;
using BattleBuddy.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;

namespace BattleBuddy
{
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
            ServiceLocatorService.GetInstance<IWindowLayoutService>().WindowLayoutChanged += WindowLayoutChanged;
            
            DataContext = mainViewModel;
        }

        private void WindowLayoutChanged(object? sender, EventArgs e)
        {
            if(e is WindowLayoutEventArgs eventArgs)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    switch (eventArgs.NewLayout)
                    {
                        case WindowLayoutType.ExtendLeft:
                            LeftColumn.Width = new GridLength(2, GridUnitType.Star);
                            RightColumn.Width = new GridLength(1, GridUnitType.Star);
                            break;

                        case WindowLayoutType.ExtendRight:
                            LeftColumn.Width = new GridLength(1, GridUnitType.Star);
                            RightColumn.Width = new GridLength(2, GridUnitType.Star);
                            break;

                        case WindowLayoutType.Justify:
                            LeftColumn.Width = new GridLength(1, GridUnitType.Star);
                            RightColumn.Width = new GridLength(1, GridUnitType.Star);
                            break;
                    }
                });
            }
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
