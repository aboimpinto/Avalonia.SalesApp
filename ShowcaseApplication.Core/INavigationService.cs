using System.Reactive.Subjects;

namespace ShowcaseApplication.Core
{
    public interface INavigationService
    {
        Subject<ViewModelBase> OnNavigation { get; }

        Task Navigate(string navigationContext);
    }
}
