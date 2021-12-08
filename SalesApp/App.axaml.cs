using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SalesApp.Views;
using ShowcaseApplication.Core;

namespace SalesApp
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var viewModel = Program.ServiceLocator.ServiceProvider.GetService<ViewModelBase>("MainWindowViewModel");

                desktop.MainWindow = new MainWindowView()
                {
                    DataContext = viewModel,
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}