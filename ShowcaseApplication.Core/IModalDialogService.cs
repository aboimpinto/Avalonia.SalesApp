using ShowcaseApplication.Controls;

namespace ShowcaseApplication.Core
{
    public interface IModalDialogService
    {
        Task<ModalDialogResult> Show(
            ModalDialogViewModalBase viewModel, 
            params object[] parameters);

        Task<ModalDialogResult<TResult>> Show<TResult>(
            ModalDialogViewModalBase<TResult> viewModel, 
            params object[] parameters);
    }
}
