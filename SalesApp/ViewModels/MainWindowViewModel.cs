using System.Windows.Input;
using ReactiveUI;
using ShowcaseApplication.Core;

namespace SalesApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _closeApplication;

        public ICommand CloseWindowCommand { get; }

        public bool CloseApplication 
        { 
            get => this._closeApplication; 
            set => this.RaiseAndSetIfChanged(ref this._closeApplication, value); 
        }

        public MainWindowViewModel()
        {
            this.CloseWindowCommand = ReactiveCommand.Create(this.OnCloseWindow);
        }

        private void OnCloseWindow()
        {
            this.CloseApplication = true;
        }
    }
}
