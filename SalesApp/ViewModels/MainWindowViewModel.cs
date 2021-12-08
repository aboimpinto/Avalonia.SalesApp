using System.Windows.Input;
using ReactiveUI;
using ShowcaseApplication.Core;

namespace SalesApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _closeApplication;
        private ViewModelBase _navigationContent;

        public ICommand CloseWindowCommand { get; }
        public ICommand DashboardNavigationCommand { get; }
        public ICommand OrdersNavigationCommand { get; }
        public ICommand ClientsNavigationCommand { get; }
        public ICommand ProductsNavigationCommand { get; }
        public ICommand SettingsNavigationCommand { get; }
        
        public ViewModelBase NavigationContent 
        { 
            get => this._navigationContent; 
            set => this.RaiseAndSetIfChanged(ref this._navigationContent, value); 
        }

        public bool CloseApplication
        {
            get => this._closeApplication;
            set => this.RaiseAndSetIfChanged(ref this._closeApplication, value);
        }

        public MainWindowViewModel()
        {
            this.CloseWindowCommand = ReactiveCommand.Create(this.OnCloseWindow);

            this.DashboardNavigationCommand = ReactiveCommand.Create(this.OnDashboardNavigationClick);
            this.OrdersNavigationCommand = ReactiveCommand.Create(this.OnOrdersNavigationClick);
            this.ClientsNavigationCommand = ReactiveCommand.Create(this.onClientsNavigationClick);
            this.ProductsNavigationCommand = ReactiveCommand.Create(this.OnProductsNavigationClick);
            this.SettingsNavigationCommand = ReactiveCommand.Create(this.OnSettingsNavigationClick);
        }

        private void OnDashboardNavigationClick()
        {
            this.NavigationContent = new DashboardViewModel();
        }

        private void OnOrdersNavigationClick()
        {
            this.NavigationContent = new OrdersViewModel();
        }

        private void onClientsNavigationClick()
        {
            this.NavigationContent = new ClientsViewModel();
        }

        private void OnProductsNavigationClick()
        {
            this.NavigationContent = new ProductsViewModel();
        }

        private void OnSettingsNavigationClick()
        {
            this.NavigationContent = new SettingsViewModel();
        }

        private void OnCloseWindow()
        {
            this.CloseApplication = true;
        }
    }
}
