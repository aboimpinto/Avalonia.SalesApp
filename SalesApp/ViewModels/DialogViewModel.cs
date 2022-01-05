using ShowcaseApplication.Controls;
using ShowcaseApplication.Core;

namespace SalesApp.ViewModels
{
    public class DialogViewModel : ModalDialogViewModalBase<DialogResult>
    {
        public void CloseCommand()
        {
            var test = this.Args as DialogViewModelArgs;

            var result = new ModalDialogResult<DialogResult>(new DialogResult(test.UserId), 99);

            this.Close(result);
        }
    }
}
