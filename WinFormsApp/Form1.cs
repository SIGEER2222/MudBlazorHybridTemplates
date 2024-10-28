using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using MudBlazorHybridTemplates.RazorClassLib;

namespace WinFormsApp;
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        var webView = new BlazorWebView
        {
            Dock = DockStyle.Fill,
            HostPage = @"wwwroot\index.html"
        };

        webView.Services = Startup.Services;
        webView.RootComponents.Add(new RootComponent("#app", typeof(Root), null));

        Controls.Add(webView);
    }
}
