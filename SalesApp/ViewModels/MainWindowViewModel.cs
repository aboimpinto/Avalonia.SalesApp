using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FluentAvalonia.UI.Controls;
using ReactiveUI;
using ShowcaseApplication.Core;

namespace SalesApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _closeApplication;
        private ViewModelBase _navigationContent;
        private readonly INavigationService _navigationService;
        private readonly IModalDialogService _modalNavigationService;
        private readonly ModalDialogViewModalBase _dialogViewModel;

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

        public MainWindowViewModel(
            INavigationService navigationService,
            IModalDialogService modalNavigationService,
            ModalDialogViewModalBase dialogViewModel)
        {
            this._navigationService = navigationService;
            this._modalNavigationService = modalNavigationService;
            this._dialogViewModel = dialogViewModel;

            this.CloseWindowCommand = ReactiveCommand.Create(this.OnCloseWindow);

            this.DashboardNavigationCommand = ReactiveCommand.Create(this.OnDashboardNavigationClick);
            this.OrdersNavigationCommand = ReactiveCommand.Create(this.OnOrdersNavigationClick);
            this.ClientsNavigationCommand = ReactiveCommand.Create(this.onClientsNavigationClick);
            this.ProductsNavigationCommand = ReactiveCommand.Create(this.OnProductsNavigationClick);
            this.SettingsNavigationCommand = ReactiveCommand.Create(this.OnSettingsNavigationClick);

            this._navigationService
                .OnNavigation
                .Subscribe(x => this.NavigationContent = x);

            this._navigationService
                .OnModalNavigation
                .Subscribe(async x =>
                {
                    await new ContentDialog()
                    {
                        Title = "New client",
                        Content = "Content of the new client",
                        CloseButtonText = "Close",
                    }.ShowAsync();
                });

            this.OnDashboardNavigationClick();
        }

        private void OnDashboardNavigationClick()
        {
            this._navigationService.Navigate("DashboardViewModel");
        }

        private async Task OnOrdersNavigationClick()
        {
            var result = await this._modalNavigationService.Show(this._dialogViewModel, result => 
            {
                var test = result;
            });

            this._navigationService.Navigate("OrdersViewModel");
        }

        private void onClientsNavigationClick()
        {
            this._navigationService.Navigate("ClientsViewModel");
        }

        private void OnProductsNavigationClick()
        {
            this._navigationService.Navigate("ProductsViewModel");
        }

        private void OnSettingsNavigationClick()
        {
            this._navigationService.Navigate("SettingsViewModel");
        }

        private void OnCloseWindow()
        {
            this.CloseApplication = true;
        }
    }
}
