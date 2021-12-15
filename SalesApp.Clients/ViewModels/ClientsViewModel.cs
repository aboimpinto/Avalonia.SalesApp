using ShowcaseApplication.Core;

namespace SalesApp.Clients.ViewModels
{
    public class ClientsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ClientsViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public void AddClientCommand()
        {
            this._navigationService.Navigate("AddUpdateClientViewModel");
        }
    }
}
