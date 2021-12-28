using ShowcaseApplication.Core;

namespace SalesApp.ViewModels
{
    public class DialogViewModel : ModalDialogViewModalBase
    {
        public void CloseCommand()
        {
            this.Close(new ModalDialogResultArgs(99));
        }
    }
}
