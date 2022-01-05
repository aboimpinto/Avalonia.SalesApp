using ShowcaseApplication.Controls;

namespace ShowcaseApplication.Core
{
    public interface IModalDialogService
    {
        Task<ModalDialogResult> Show(
            ModalDialogViewModalBase viewModel, 
            ModalDialogArgs args);

        Task<ModalDialogResult<TResult>> Show<TResult>(
            ModalDialogViewModalBase<TResult> viewModel, 
            ModalDialogArgs args);
    }
}
