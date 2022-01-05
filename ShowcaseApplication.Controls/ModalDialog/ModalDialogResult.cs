namespace ShowcaseApplication.Controls
{
    public class ModalDialogResult
    {
        public int ExitCode { get; }

        public ModalDialogResult(int exitCode)
        {
            this.ExitCode = exitCode;
        }
    }
}
