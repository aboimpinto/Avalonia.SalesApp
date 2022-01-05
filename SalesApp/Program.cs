using System;
using Avalonia;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using SalesApp.Clients;
using SalesApp.DbAccess;
using SalesApp.Orders;
using SalesApp.Products;
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
            ServiceLocator.ServiceCollection.AddSingleton<IModalDialogService, ModalDialogService>();

            ServiceLocator.ServiceCollection.AddScoped<ViewModelBase, MainWindowViewModel>("MainWindowViewModel");
            ServiceLocator.ServiceCollection.AddScoped<ViewModelBase, DashboardViewModel>("DashboardViewModel");
            ServiceLocator.ServiceCollection.AddScoped<ViewModelBase, SettingsViewModel>("SettingsViewModel");

            ServiceLocator.ServiceCollection.AddScoped<ModalDialogViewModalBase<DialogResult>, DialogViewModel>();

            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        } 
        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI()
                .RegisterClientsModule(ServiceLocator)
                .RegisterProductsModule(ServiceLocator)
                .RegisterOrdersModule(ServiceLocator)
                .RegisterDbAccessModule(ServiceLocator);

        // TODO: One alternative is to discover the modules and use Assembly Scanning method discussed here:
        // https://www.youtube.com/watch?v=_YkvFQ1-Lt0
    }
}
