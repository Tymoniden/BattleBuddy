using BattleBuddy.Services;
using BattleBuddy.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using BattleBuddy.Services.SignalR;
using BattleBuddy.Services.Container;
using BattleBuddy.Services.Messaging;
using System.Linq;
using System.Threading.Tasks;

namespace BattleBuddy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ArmyListEntryDto> _entries = new();

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


            ServiceLocatorService.GetInstance<ISignalRService>().RegisterCallback("ExtendLeftColumn" , () => ServiceLocatorService.GetInstance<IWindowLayoutService>().ExtendLeftColumn());
            ServiceLocatorService.GetInstance<ISignalRService>().RegisterCallback("ExtendRightColumn" , () => ServiceLocatorService.GetInstance<IWindowLayoutService>().ExtendRightColumn());
            ServiceLocatorService.GetInstance<ISignalRService>().RegisterCallback("JustifyColumns" , () => ServiceLocatorService.GetInstance<IWindowLayoutService>().JustifyColumns());

            Dispatcher.InvokeAsync(async () =>
            {
                await LeftWebView.EnsureCoreWebView2Async();
                await RightWebView.EnsureCoreWebView2Async();

                LeftWebView.CoreWebView2.DOMContentLoaded += (o, args) =>
                {
                    Dispatcher.InvokeAsync(async () =>
                    {
                        await LeftWebView.ExecuteScriptAsync(ServiceLocatorService.GetInstance<JsInteractionService>().GetSetupScript());
                    });
                };
                
                RightWebView.CoreWebView2.DOMContentLoaded += (o, args) =>
                {
                    Dispatcher.InvokeAsync(async () =>
                    {
                        await RightWebView.ExecuteScriptAsync(ServiceLocatorService.GetInstance<JsInteractionService>().GetSetupScript());
                    });
                };
            });
            
            ServiceLocatorService.GetInstance<ISignalRService>().RegisterCallback("RequestListUpdateMessage" , () =>
            {
                Dispatcher.InvokeAsync(async () => await UpdateEntries());
            });

            ServiceLocatorService.GetInstance<ISignalRService>().RegisterCallback("ScrollDisplayToArmyList",
            (Guid uid) =>
            {
                Dispatcher.InvokeAsync(async () =>
                {
                    var entry = _entries.FirstOrDefault(entry => entry.Uid == uid);
                    if (entry != null)
                    {
                        var methodCall = ServiceLocatorService.GetInstance<JsInteractionService>()
                            .ExecuteScrollToEntry(uid);
                        if (entry.Origin.ToLower().Equals("left"))
                        {
                            await LeftWebView.ExecuteScriptAsync(methodCall);
                        }
                        else
                        {
                            await RightWebView.ExecuteScriptAsync(methodCall);
                        }
                    }
                });
            });

            ServiceLocatorService.GetInstance<ISignalRService>().RegisterCallback("ScrollToPercent",
            (string origin, int percentage) =>
            {
                Dispatcher.InvokeAsync(async () =>
                {
                    var method = ServiceLocatorService.GetInstance<JsInteractionService>().ExecuteScrollToEntry(percentage);
                    var control = origin.ToLower().Equals("left") ? LeftWebView : RightWebView;

                    await control.ExecuteScriptAsync(method);
                });
            });

            ServiceLocatorService.GetInstance<ISignalRService>().RegisterCallback("ToggleQrCode", () =>
            {
                Dispatcher.Invoke(() =>
                    mainViewModel.ClientEndpointOverlayViewModel.IsVisible =
                    !mainViewModel.ClientEndpointOverlayViewModel.IsVisible);
            });

            ServiceLocatorService.GetInstance<IHotKeyRegistrationService>().RegisterHotKey(Key.F3, ModifierKeys.None, "Update entries" , UpdateEntries);

            DataContext = mainViewModel;
        }

        private async Task UpdateEntries()
        {
            _entries.Clear();

            var leftRawEntries = await LeftWebView.ExecuteScriptAsync("getEntries();");
            _entries.AddRange(ServiceLocatorService.GetInstance<DtoFactory>().CreateArmyListEntry(leftRawEntries, "left"));

            var rightRawEntries = await RightWebView.ExecuteScriptAsync("getEntries();");
            _entries.AddRange(ServiceLocatorService.GetInstance<DtoFactory>().CreateArmyListEntry(rightRawEntries, "right"));

            await ServiceLocatorService.GetInstance<ISignalRService>().SendMessage("UpdateArmyListEntries", _entries);
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

        private void StateChangeEvent(object? sender, EventArgs e)
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
            ServiceLocatorService.GetInstance<IHotKeyService>().ExecuteHotkey(e.Key, Keyboard.Modifiers, e);
        }
    }
}
