using BattleBuddy.ViewModel;
using System.Windows;

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
            DataContext = new MainViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //HotKeyControl.Visibility = HotKeyControl.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            if(DataContext is MainViewModel viewModel)
            {
                viewModel.IsHotKeyPanelVisible = !viewModel.IsHotKeyPanelVisible;
            }
        }
    }
}
