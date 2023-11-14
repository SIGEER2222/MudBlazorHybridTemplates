using System;
using System.Windows;
using Microsoft.AspNetCore.Components.WebView.Wpf;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using MudBlazorHybridTemplates.Application;
using MudBlazorHybridTemplates.RazorClassLib;
namespace MudBlazorHybridTemplates.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var webView = new BlazorWebView
            {
                HostPage = @"wwwroot\index.html"
            };
            var services = new ServiceCollection();
            services.AddWpfBlazorWebView();
            services.AddMudServices();
            services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
            services.AddBlazorWebViewDeveloperTools();
            webView.Services = services.BuildServiceProvider();
            webView.RootComponents.Add(new RootComponent
            {
                ComponentType = typeof(Root),
                Selector = "#app"
            });
            Content = webView;
            AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            {
                MessageBox.Show(error.ExceptionObject.ToString(), "Unhandled Exception", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            };
        }
    }
}