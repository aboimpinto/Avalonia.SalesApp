using System.Reactive.Subjects;

namespace ShowcaseApplication.Core
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceLocator _serviceLocator;

        public Subject<ViewModelBase> OnNavigation { get; }

        public Subject<ViewModelBase> OnModalNavigation  { get; }

        public NavigationService(IServiceLocator serviceLocator)
        {
            this._serviceLocator = serviceLocator;

            this.OnNavigation = new Subject<ViewModelBase>();
            this.OnModalNavigation = new Subject<ViewModelBase>();
        }

        public Task Navigate(string navigationContext)
        {
            var viewModel = this._serviceLocator.ServiceProvider.GetService<ViewModelBase>(navigationContext);

            this.OnNavigation.OnNext(viewModel);

            return Task.CompletedTask;
        }   

        public Task ShowModalWindow(string navigationContext)
        {
            var viewModel = this._serviceLocator.ServiceProvider.GetService<ViewModelBase>(navigationContext);

            this.OnModalNavigation.OnNext(viewModel);

            return Task.CompletedTask;
        }
    }
}
