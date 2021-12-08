using System.Reactive.Subjects;

namespace ShowcaseApplication.Core
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceLocator _serviceLocator;

        public Subject<ViewModelBase> OnNavigation { get; }

        public NavigationService(IServiceLocator serviceLocator)
        {
            this._serviceLocator = serviceLocator;

            this.OnNavigation = new Subject<ViewModelBase>();
        }

        public Task Navigate(string navigationContext)
        {
            var viewModel = this._serviceLocator.ServiceProvider.GetService<ViewModelBase>(navigationContext);

            this.OnNavigation.OnNext(viewModel);

            return Task.CompletedTask;
        }   
    }
}
