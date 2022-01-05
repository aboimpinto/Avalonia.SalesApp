using ShowcaseApplication.Controls;

namespace ShowcaseApplication.Core
{
    public class ModalDialogViewModalBase : ViewModelBase
    {
        public EventHandler<ModalDialogResult> Closed { get; set; }

        public void Close(ModalDialogResult result)
        {
            this.Closed?.Invoke(this, result);
        }
    }
}
