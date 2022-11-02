using BattleBuddy.Services;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace BattleBuddy.ViewModels
{
    public class ClientEndpointOverlayViewModel : Base.ViewModel
    {
        private readonly IClientEndpointService _clientEndpointService;
        private readonly IQRCodeService _qRCodeService;

        public ClientEndpointOverlayViewModel(IHotKeyRegistrationService hotKeyRegistrationService, IClientEndpointService clientEndpointService, IQRCodeService qRCodeService)
        {
            if (hotKeyRegistrationService is null)
            {
                throw new ArgumentNullException(nameof(hotKeyRegistrationService));
            }

            _clientEndpointService = clientEndpointService ?? throw new ArgumentNullException(nameof(clientEndpointService));
            _qRCodeService = qRCodeService ?? throw new ArgumentNullException(nameof(qRCodeService));
            _clientEndpointService.SetPort(500);
            hotKeyRegistrationService.RegisterHotKey(Key.F5, ModifierKeys.None, "Display connection options", () => IsVisible = !IsVisible);
        }

        public ObservableCollection<string> Endpoints { get; } = new();

        public string SelectedEndpoint
        {
            get => GetValue<string>() ?? string.Empty;
            set
            {
                SetValue(value);
                UpdateQRCode();
            }
        }

        public bool IsVisible
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        public BitmapSource? QRCode
        {
            get => GetValue<BitmapSource>();
            set
            {
                if (value != null)
                {
                    SetValue(value);
                }
            }
        }

        public void UpdateQRCode()
        {
            // TODO: extract to service!
            var bitmap = _qRCodeService.RenderQRCode(SelectedEndpoint);
            MemoryStream ms = new MemoryStream();
            ((Bitmap)bitmap).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();

            QRCode = image;
        }

        public async Task Setup()
        {
            var endpoints = await _clientEndpointService.GetEndpointOptions();

            Endpoints.Clear();
            foreach(var endpoint in endpoints)
            {
                Endpoints.Add(endpoint);
            }

            if (Endpoints.Any() && string.IsNullOrEmpty(SelectedEndpoint))
            {
                Application.Current.Dispatcher.Invoke(() => SelectedEndpoint = Endpoints.First());
            }
        }
    }
}
