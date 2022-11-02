using BattleBuddy.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace BattleBuddy.Ui
{
    /// <summary>
    /// Interaction logic for ClientConnectionOverlay.xaml
    /// </summary>
    public partial class ClientEndpointOverlay : UserControl
    {
        public ClientEndpointOverlay()
        {
            InitializeComponent();
            LayoutUpdated += (_, __) => FocusSelectedElement();
        }
        
        private void FocusSelectedElement()
        {
            if (DataContext is not ClientEndpointOverlayViewModel viewModel)
            {
                return;
            }
            
            if (viewModel.IsVisible && ActualHeight > 0 || ActualWidth > 0 && !IsKeyboardFocusWithin)
            {
                var itemToFocus = viewModel.SelectedEndpoint;
                if (string.IsNullOrEmpty(itemToFocus))
                {
                    return;
                }

                if (EndpointList.ItemContainerGenerator.ContainerFromItem(itemToFocus) is ListViewItem lvi)
                {
                    Keyboard.Focus(lvi);
                }
            }
        }
    }
}
