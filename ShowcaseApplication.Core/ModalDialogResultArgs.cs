namespace ShowcaseApplication.Core
{
    public class ModalDialogResultArgs : EventArgs
    {
        public int ExitCode { get; }

        public ModalDialogResultArgs(int exitCode)
        {
            this.ExitCode = exitCode;
        }
    }
}
