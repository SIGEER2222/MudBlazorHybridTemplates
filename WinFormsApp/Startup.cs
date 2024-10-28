using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using MudBlazorHybridTemplates.Application;

namespace WinFormsApp;

public static class Startup
{
    public static IServiceProvider? Services { get; private set; }

    public static void Init()
    {
        var host = Host.CreateDefaultBuilder()
                       .ConfigureServices(WireupServices)
                       .Build();
        Services = host.Services;
    }

    private static void WireupServices(IServiceCollection services)
    {
        services.AddWindowsFormsBlazorWebView();

        services.AddMudServices();
        services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
        services.AddBlazorWebViewDeveloperTools();


#if DEBUG
        services.AddBlazorWebViewDeveloperTools();
#endif
    }
}
