using System.Reactive.Subjects;

namespace ShowcaseApplication.Core
{
    public interface INavigationService
    {
        Subject<ViewModelBase> OnNavigation { get; }

        Subject<ViewModelBase> OnModalNavigation  { get; }

        Task Navigate(string navigationContext);

        Task ShowModalWindow(string navigationContext);
    }
}
