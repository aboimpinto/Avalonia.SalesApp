using ShowcaseApplication.Controls;

namespace ShowcaseApplication.Core
{
    public class ModalDialogViewModalBase<TResult> : ModalDialogViewModalBase
    {
        public EventHandler<ModalDialogResult<TResult>> Closed { get; set; }

        protected IEnumerable<object> Parameters { get; private set; }

        public void Close(ModalDialogResult<TResult> result)
        {
            this.Closed?.Invoke(this, result);
        }
    }
}
