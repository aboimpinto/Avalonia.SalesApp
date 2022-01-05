using ShowcaseApplication.Controls;

namespace ShowcaseApplication.Core
{
    public class ModalDialogViewModalBase : ViewModelBase
    {
        public EventHandler<ModalDialogResult> Closed { get; set; }

        public ModalDialogArgs Args { get; set; }

        public void SetArgs(ModalDialogArgs args)
        {
            this.Args = args;
        }

        public void Close(ModalDialogResult result)
        {
            this.Closed?.Invoke(this, result);
        }
    }
}
