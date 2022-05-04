
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BattleBuddyPrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string JS_SCROLL_FUNCTION = "function scrollToPercent(percent){var body = document.body;var html = document.documentElement;var height = Math.max(body.scrollHeight, body.offsetHeight,html.clientHeight, html.scrollHeight, html.offsetHeight);var factor = percent/100.0;var pixelTarget = height * factor;window.scrollTo({top: pixelTarget,behavior: 'smooth',});console.log(\"scrolled to \" + pixelTarget + \"px(\" + + percent + \"%) of max height \" + height + \"px\");}";
        const string JS_SCROLL_TO = "scrollToPercent({0});";

        const string JS_SCROLL_TO_INDEX_FUNCTION = "function scrollToIndex(index){$(\".wh40k_unit_sheet > table > thead.unit_header > tr:nth-child(1) > td:nth-child(2)\")[index].scrollIntoView({ behavior: 'smooth' });}";
        const string JS_SCROLL_TO_INDEX = "scrollToIndex({0});";
        
        const string JS_SCROLL_TO_ENTRY_FUNCTION = "function scrollToEntry(entry){ var found; $(\".wh40k_unit_sheet > table > thead.unit_header > tr:nth-child(1) > td:nth-child(2)\").each(function(index, element){ if($(element).text() == entry){ found = $(element); return false; } }); if(found != undefined){ $(found).get(0).scrollIntoView({ behavior: 'smooth' });}};";
        const string JS_SCROLL_TO_ENTRY = "scrollToEntry(\"{0}\");";

        const string JS_GET_ENTRIES = "function getEntries(){ var entries = []; $(\".wh40k_unit_sheet > table > thead.unit_header > tr:nth-child(1) > td:nth-child(2)\").each(function(index, element){ entries.push($(element).text()); }); return entries;}; getEntries();";

        HubConnection connection;
        private List<string> _leftEntries = new ();
        private List<string> _rightEntries = new();

        public MainWindow()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5000/ChatHub")
            .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            connection.On<SideIdentifier, string>("ScrollToEntry", async (side, entry)  => {
                if(side == SideIdentifier.Left)
                {
                    if(entry == "top")
                    {
                        await leftWebView.ExecuteScriptAsync(string.Format(JS_SCROLL_TO, 0));
                    }
                    else if(entry == "bottom")
                    {
                        await leftWebView.ExecuteScriptAsync(string.Format(JS_SCROLL_TO, 100));
                    }
                }
                else if(side == SideIdentifier.Right)
                {
                    if (entry == "top")
                    {
                        await rightWebView.ExecuteScriptAsync(string.Format(JS_SCROLL_TO, 0));
                    }
                    else if (entry == "bottom")
                    {
                        await rightWebView.ExecuteScriptAsync(string.Format(JS_SCROLL_TO, 100));
                    }
                }
            });

            connection.On<SideIdentifier, int>("ScrollToIndex", async (side, index) =>
            {
                var control = side == SideIdentifier.Left ? leftWebView : rightWebView;

                if (control != null)
                {
                    await control.ExecuteScriptAsync(string.Format(JS_SCROLL_TO_INDEX, index));
                }
            });

            connection.On<string>("Focus", (target) =>
            {
                switch (target)
                {
                    case "left":
                        FocusLeft(this, new RoutedEventArgs());
                        break;
                    case "right":
                        FocusRight(this, new RoutedEventArgs());
                        break;
                    case "none":
                        ResetView(this, new RoutedEventArgs());
                        break;
                }
            });
        }

        private void ZoomTo0(object sender, RoutedEventArgs e)
        {
            rightWebView.ExecuteScriptAsync(string.Format(JS_SCROLL_TO, 0));
            leftWebView.ExecuteScriptAsync(string.Format(JS_SCROLL_TO, 0));
        }

        private async void GetEntries(object sender, RoutedEventArgs e)
        {
            await leftWebView.ExecuteScriptAsync(string.Format(JS_SCROLL_TO_ENTRY, "Tyranid Warriors"));
        }

        private async void SendEntries(object sender, RoutedEventArgs e)
        {
            await SendLeftEntries();
            await SendRightEntries();
        }

        async Task SendLeftEntries()
        {
            var html = await leftWebView.CoreWebView2.ExecuteScriptAsync(JS_GET_ENTRIES);
            _leftEntries = JsonConvert.DeserializeObject<List<string>>(html);

            if (connection.State == HubConnectionState.Disconnected)
            {
                await connection.StartAsync();
            }

            await connection.InvokeAsync("RegisterEntries", SideIdentifier.Left, _leftEntries);
        }

        async Task SendRightEntries()
        {
            var html = await rightWebView.CoreWebView2.ExecuteScriptAsync(JS_GET_ENTRIES);
            _rightEntries = JsonConvert.DeserializeObject<List<string>>(html);

            if (connection.State == HubConnectionState.Disconnected)
            {
                await connection.StartAsync();
            }

            await connection.InvokeAsync("RegisterEntries", SideIdentifier.Right, _rightEntries);
        }

        private void ZoomTo100(object sender, RoutedEventArgs e)
        {
            rightWebView.ExecuteScriptAsync(string.Format(JS_SCROLL_TO, 100));
            leftWebView.ExecuteScriptAsync(string.Format(JS_SCROLL_TO, 100));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rightWebView.Loaded += RightWebView_Loaded;
            leftWebView.Loaded += LeftWebView_Loaded;
        }

        private async void LeftWebView_Loaded(object sender, RoutedEventArgs e)
        {
            await leftWebView.EnsureCoreWebView2Async();
            leftWebView.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded;
        }

        private async void RightWebView_Loaded(object sender, RoutedEventArgs e)
        {
            await rightWebView.EnsureCoreWebView2Async();
            rightWebView.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded;
        }

        private void CoreWebView2_DOMContentLoaded(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            if(sender is CoreWebView2 webView)
            {
                webView.ExecuteScriptAsync(JS_SCROLL_FUNCTION);
                webView.ExecuteScriptAsync(JS_SCROLL_TO_INDEX_FUNCTION);
            }
        }

        private void FocusLeft(object sender, RoutedEventArgs e)
        {
            LeftColumn.Width = new GridLength(2, GridUnitType.Star);
            RightColumn.Width = new GridLength(1, GridUnitType.Star);
        }

        private void FocusRight(object sender, RoutedEventArgs e)
        {
            LeftColumn.Width = new GridLength(1, GridUnitType.Star);
            RightColumn.Width = new GridLength(2, GridUnitType.Star);
        }

        private void ResetView(object sender, RoutedEventArgs e)
        {
            LeftColumn.Width = new GridLength(1, GridUnitType.Star);
            RightColumn.Width = new GridLength(1, GridUnitType.Star);
        }
    }
}
