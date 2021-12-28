namespace ShowcaseApplication.Core
{
    public interface IModalDialogService
    {
        Task<ModalDialogResult> Show(ModalDialogViewModalBase viewModel, Action<string> closeCallback);
    }
}
