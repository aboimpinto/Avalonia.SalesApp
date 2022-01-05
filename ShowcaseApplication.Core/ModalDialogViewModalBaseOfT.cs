using ShowcaseApplication.Controls;

namespace ShowcaseApplication.Core
{
    public class ModalDialogViewModalBase<TResult> : ModalDialogViewModalBase
    {
        public EventHandler<ModalDialogResult<TResult>> Closed { get; set; }

        public ModalDialogArgs Args { get; set; }

        public void SetArgs(ModalDialogArgs args)
        {
            this.Args = args;
        }

        public void Close(ModalDialogResult<TResult> result)
        {
            this.Closed?.Invoke(this, result);
        }
    }
}
