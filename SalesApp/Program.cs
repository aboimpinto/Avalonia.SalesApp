using System;
using Avalonia;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using SalesApp.ViewModels;
using ShowcaseApplication.Core;

namespace SalesApp
{
    class Program
    {
        public static IServiceLocator ServiceLocator = new ServiceLocator();

        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) 
        {
            ServiceLocator.ServiceCollection.AddSingleton<INavigationService, NavigationService>();
            ServiceLocator.ServiceCollection.AddScoped<ViewModelBase, MainWindowViewModel>("MainWindowViewModel");
            ServiceLocator.ServiceCollection.AddScoped<ViewModelBase, ClientsViewModel>("ClientsViewModel");
            ServiceLocator.ServiceCollection.AddScoped<ViewModelBase, DashboardViewModel>("DashboardViewModel");
            ServiceLocator.ServiceCollection.AddScoped<ViewModelBase, OrdersViewModel>("OrdersViewModel");
            ServiceLocator.ServiceCollection.AddScoped<ViewModelBase, ProductsViewModel>("ProductsViewModel");
            ServiceLocator.ServiceCollection.AddScoped<ViewModelBase, SettingsViewModel>("SettingsViewModel");

            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        } 
        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
    }
}
