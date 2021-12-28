namespace ShowcaseApplication.Core
{
    public class ModalDialogViewModalBase : ViewModelBase
    {
        public EventHandler<ModalDialogResultArgs> Closed { get; set; }

        public void Close(ModalDialogResultArgs result)
        {
            this.Closed?.Invoke(this, result);
        }
    }
}
